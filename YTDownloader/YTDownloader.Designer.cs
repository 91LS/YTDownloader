namespace YTDownloader
{
    partial class YTDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YTDownloader));
            this.downloadButton = new System.Windows.Forms.Button();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.chooseLabel = new System.Windows.Forms.Label();
            this.chooseTextBox = new System.Windows.Forms.TextBox();
            this.chooseButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pasteButton = new System.Windows.Forms.Button();
            this.stateLabel = new System.Windows.Forms.Label();
            this.folderExplorerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.downloadButton.Location = new System.Drawing.Point(12, 84);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(479, 40);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Ściągnij";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_ClickAsync);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 30);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(80, 17);
            this.urlLabel.TabIndex = 1;
            this.urlLabel.Text = "Podaj URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Enabled = false;
            this.urlTextBox.Location = new System.Drawing.Point(124, 27);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(449, 22);
            this.urlTextBox.TabIndex = 2;
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            // 
            // chooseLabel
            // 
            this.chooseLabel.AutoSize = true;
            this.chooseLabel.Location = new System.Drawing.Point(12, 59);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(103, 17);
            this.chooseLabel.TabIndex = 3;
            this.chooseLabel.Text = "Wybierz folder:";
            // 
            // chooseTextBox
            // 
            this.chooseTextBox.Enabled = false;
            this.chooseTextBox.Location = new System.Drawing.Point(124, 56);
            this.chooseTextBox.Name = "chooseTextBox";
            this.chooseTextBox.Size = new System.Drawing.Size(449, 22);
            this.chooseTextBox.TabIndex = 4;
            // 
            // chooseButton
            // 
            this.chooseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chooseButton.Location = new System.Drawing.Point(577, 54);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(82, 27);
            this.chooseButton.TabIndex = 5;
            this.chooseButton.Text = "Wybierz";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 130);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(644, 23);
            this.progressBar.TabIndex = 6;
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(577, 25);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(82, 27);
            this.pasteButton.TabIndex = 7;
            this.pasteButton.Text = "Wklej";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(12, 9);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 17);
            this.stateLabel.TabIndex = 8;
            // 
            // folderExplorerButton
            // 
            this.folderExplorerButton.Location = new System.Drawing.Point(497, 84);
            this.folderExplorerButton.Name = "folderExplorerButton";
            this.folderExplorerButton.Size = new System.Drawing.Size(162, 40);
            this.folderExplorerButton.TabIndex = 9;
            this.folderExplorerButton.Text = "Otwórz folder z muzą";
            this.folderExplorerButton.UseVisualStyleBackColor = true;
            this.folderExplorerButton.Click += new System.EventHandler(this.folderExplorerButton_Click);
            // 
            // YTDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 161);
            this.Controls.Add(this.folderExplorerButton);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.chooseTextBox);
            this.Controls.Add(this.chooseLabel);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.downloadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YTDownloader";
            this.Text = "YTDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YTDownloader_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label chooseLabel;
        private System.Windows.Forms.TextBox chooseTextBox;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Button folderExplorerButton;
    }
}

