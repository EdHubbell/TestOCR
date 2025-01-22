namespace TestOCR
{
    partial class fmrMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRunOCR = new Button();
            txtResults = new TextBox();
            txtScore = new TextBox();
            btnSelectFile = new Button();
            txtImagePath = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnRunOCR
            // 
            btnRunOCR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRunOCR.Location = new Point(12, 204);
            btnRunOCR.Name = "btnRunOCR";
            btnRunOCR.Size = new Size(107, 23);
            btnRunOCR.TabIndex = 0;
            btnRunOCR.Text = "RunOCR";
            btnRunOCR.UseVisualStyleBackColor = true;
            btnRunOCR.Click += button1_Click;
            // 
            // txtResults
            // 
            txtResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtResults.Location = new Point(143, 205);
            txtResults.Name = "txtResults";
            txtResults.Size = new Size(338, 23);
            txtResults.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtScore.Location = new Point(143, 234);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(338, 23);
            txtScore.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectFile.Location = new Point(12, 163);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(107, 23);
            btnSelectFile.TabIndex = 3;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // txtImagePath
            // 
            txtImagePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtImagePath.Location = new Point(143, 163);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(503, 23);
            txtImagePath.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(634, 145);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 278);
            Controls.Add(pictureBox1);
            Controls.Add(txtImagePath);
            Controls.Add(btnSelectFile);
            Controls.Add(txtScore);
            Controls.Add(txtResults);
            Controls.Add(btnRunOCR);
            Name = "Form1";
            Text = "Test OCR";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRunOCR;
        private TextBox txtResults;
        private TextBox txtScore;
        private Button btnSelectFile;
        private TextBox txtImagePath;
        private PictureBox pictureBox1;
    }
}
