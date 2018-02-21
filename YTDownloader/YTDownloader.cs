using CliWrap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace YTDownloader
{
    public partial class YTDownloader : Form
    {
        private static readonly Cli FfmpegCli = new Cli("ffmpeg.exe");
        private static readonly string TempDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Temp");
        private readonly YoutubeClient YoutubeClient = new YoutubeClient();
        private readonly string startedFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Muza z Youtube'a";
        private List<string> errorList = new List<string>();

        public YTDownloader()
        {
            InitializeComponent();
            SetStartedFolder();
            stateLabel.Text = "Wklej link do filmu z YouTube'a";
        }

        private void SetStartedFolder()
        {
            chooseTextBox.Text = startedFolder;
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderDialog.SelectedPath = desktopPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    chooseTextBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void downloadButton_ClickAsync(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            // Try to determine the type of the URL/ID that was given

            // Playlist URL
            if (YoutubeClient.TryParsePlaylistId(urlTextBox.Text, out var playlistId))
            {
                await SavePlaylist(playlistId);
            }

            // Video URL
            else if (YoutubeClient.TryParseVideoId(urlTextBox.Text, out var videoId))
            {
                try
                {
                    await SaveTrackAudioAsync(videoId, -1, -1);
                }
                catch
                {

                    MessageBox.Show($"Niestety wystąpił błąd :( Z utworu: {videoId} nic nie będzie :(");
                }
                
            }

            // Unknown
            else
            {
                MessageBox.Show("Błędny adres URL :( Wklej poprawny link!");
            }

            downloadButton.Enabled = true;
            urlTextBox.Text = "";
            stateLabel.Text = "Udało się! Wklej kolejny link :)";
        }

        private async Task SaveTrackAudioAsync(string id, int index, int all, string playlistTitle = "",  bool isFromPlaylist=false)
        {
            if (index != -1)
                stateLabel.Text = $"Ściągam playlistę. Aktualnie utwór nr {index} z {all}";
            else
                stateLabel.Text = $"Ściągam utwór...";

            var url = urlTextBox.Text;
            var video = await YoutubeClient.GetVideoAsync(id);

            //replace invalid character for '_'
            var cleanTitle = video.Title;
            for (int i = 0; i < cleanTitle.Length -1; i++)
            {
                if (Path.GetInvalidFileNameChars().Contains(cleanTitle[i]))
                    cleanTitle = cleanTitle.Replace(cleanTitle[i], ' ');
            }

            var streamInfoSet = await YoutubeClient.GetVideoMediaStreamInfosAsync(id);
            var streamInfo = streamInfoSet.Audio.WithHighestBitrate();

            //temp
            Directory.CreateDirectory(TempDirectoryPath);
            var streamFileExt = streamInfo.Container.GetFileExtension();
            var streamFilePath = Path.Combine(TempDirectoryPath, $"{Guid.NewGuid()}.{streamFileExt}");
            var progressHandler = new Progress<double>(p => progressBar.Value = (int)p * 100);
            await YoutubeClient.DownloadMediaStreamAsync(streamInfo, streamFilePath, progressHandler);

            // Convert to mp3
            stateLabel.Text = "Konwertuję utwór na mp3...";
            string directory = chooseTextBox.Text;
            if (playlistTitle != "")
                directory += "\\" + playlistTitle;
            Directory.CreateDirectory(directory);
            var ext = streamInfo.Container.GetFileExtension();
            var outputFilePath = directory + "\\" + cleanTitle + ".mp3";
            //await YoutubeClient.DownloadMediaStreamAsync(streamInfo, outputFilePath, progressHandler);
            await FfmpegCli.ExecuteAsync($"-i \"{streamFilePath}\" -q:a 0 -map a \"{outputFilePath}\" -y");

            File.Delete(streamFilePath);

            // Edit mp3 metadata
            var idMatch = Regex.Match(video.Title, @"^(?<artist>.*?)-(?<title>.*?)$");
            var artist = idMatch.Groups["artist"].Value.Trim();
            var titleAfter = idMatch.Groups["title"].Value.Trim();
            try
            {
                using (var meta = TagLib.File.Create(outputFilePath))
                {
                    meta.Tag.Performers = new[] { artist };
                    meta.Tag.Title = titleAfter;
                    meta.Save();
                }
            }
            catch
            {

            }

            stateLabel.Text = "Udało się!";
            if (!isFromPlaylist)
                MessageBox.Show("Zakończono pobieranie utworu", "Zakończono");
            progressBar.Value = 0;
            
        }

        private async Task SavePlaylist(string id)
        {
            // Get playlist info
            var playlist = await YoutubeClient.GetPlaylistAsync(id);

            // Clear error list on new playlist
            errorList.Clear();

            // Work on the videos
            int index = 1;
            foreach (var video in playlist.Videos)
            {
                try
                {
                    await SaveTrackAudioAsync(video.Id, index, playlist.Videos.Count, playlist.Title, true);
                }
                catch
                {
                    //MessageBox.Show($"Niestety wystąpił błąd :( Z utworu: {video.Title} nic nie będzie :(");//tutaj sie nie udalo
                    errorList.Add(video.Title);
                }
                index++;
            }

            MessageBox.Show("Zakończono pobieranie playlisty", "Zakończono");
            if (errorList.Count != 0)
            {
                string titles = "";
                foreach (var title in errorList)
                {
                    titles += title + "\n";
                }
                titles = titles.Trim();
                MessageBox.Show("Niestety nie udało się pobrać następujących tytułów: \n" + titles, "Błąd w pobieraniu");
            } 
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            urlTextBox.Text = Clipboard.GetText();
        }

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            stateLabel.Text = "OK! :) Naciśnij przycisk \"Sciągnij\"";
        }

        private void folderExplorerButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@chooseTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Folder jeszcze nie istnieje. Zostanie utworzony wraz z pierwszym pobranym utworem.", "Błąd");
            }
            
        }

        private void YTDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(TempDirectoryPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
 