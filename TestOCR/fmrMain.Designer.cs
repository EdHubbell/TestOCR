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
            cbxRotationDetection = new CheckBox();
            imageBox = new Cyotek.Windows.Forms.ImageBox();
            SuspendLayout();
            // 
            // btnRunOCR
            // 
            btnRunOCR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRunOCR.Location = new Point(17, 573);
            btnRunOCR.Margin = new Padding(4, 5, 4, 5);
            btnRunOCR.Name = "btnRunOCR";
            btnRunOCR.Size = new Size(153, 38);
            btnRunOCR.TabIndex = 0;
            btnRunOCR.Text = "RunOCR";
            btnRunOCR.UseVisualStyleBackColor = true;
            btnRunOCR.Click += button1_Click;
            // 
            // txtResults
            // 
            txtResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtResults.Location = new Point(204, 575);
            txtResults.Margin = new Padding(4, 5, 4, 5);
            txtResults.Name = "txtResults";
            txtResults.Size = new Size(481, 31);
            txtResults.TabIndex = 1;
            // 
            // txtScore
            // 
            txtScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtScore.Location = new Point(204, 623);
            txtScore.Margin = new Padding(4, 5, 4, 5);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(481, 31);
            txtScore.TabIndex = 2;
            // 
            // btnSelectFile
            // 
            btnSelectFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelectFile.Location = new Point(17, 505);
            btnSelectFile.Margin = new Padding(4, 5, 4, 5);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(153, 38);
            btnSelectFile.TabIndex = 3;
            btnSelectFile.Text = "Select File";
            btnSelectFile.UseVisualStyleBackColor = true;
            btnSelectFile.Click += btnSelectFile_Click;
            // 
            // txtImagePath
            // 
            txtImagePath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtImagePath.Location = new Point(204, 505);
            txtImagePath.Margin = new Padding(4, 5, 4, 5);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.Size = new Size(717, 31);
            txtImagePath.TabIndex = 4;
            // 
            // cbxRotationDetection
            // 
            cbxRotationDetection.Checked = true;
            cbxRotationDetection.CheckState = CheckState.Checked;
            cbxRotationDetection.Location = new Point(17, 623);
            cbxRotationDetection.Name = "cbxRotationDetection";
            cbxRotationDetection.Size = new Size(182, 57);
            cbxRotationDetection.TabIndex = 6;
            cbxRotationDetection.Text = "Enable Rotation Detection";
            cbxRotationDetection.UseVisualStyleBackColor = true;
            cbxRotationDetection.Visible = false;
            // 
            // imageBox
            // 
            imageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imageBox.Location = new Point(12, 12);
            imageBox.Name = "imageBox";
            imageBox.Size = new Size(909, 485);
            imageBox.TabIndex = 7;
            // 
            // fmrMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 697);
            Controls.Add(imageBox);
            Controls.Add(cbxRotationDetection);
            Controls.Add(txtImagePath);
            Controls.Add(btnSelectFile);
            Controls.Add(txtScore);
            Controls.Add(txtResults);
            Controls.Add(btnRunOCR);
            Margin = new Padding(4, 5, 4, 5);
            Name = "fmrMain";
            Text = "Test OCR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRunOCR;
        private TextBox txtResults;
        private TextBox txtScore;
        private Button btnSelectFile;
        private TextBox txtImagePath;
        private CheckBox cbxRotationDetection;
        private Cyotek.Windows.Forms.ImageBox imageBox;
    }
}
