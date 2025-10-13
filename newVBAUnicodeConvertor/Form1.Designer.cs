namespace newVBAUnicodeConvertor
{
    partial class frmJNTConvertor
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
            gbInput = new GroupBox();
            edFunction = new TextBox();
            edMaxRowLength = new TextBox();
            btnConvert = new Button();
            label2 = new Label();
            label1 = new Label();
            cbHexFlag = new CheckBox();
            edInput = new TextBox();
            gbOutput = new GroupBox();
            btnClipBoard = new Button();
            edOutput = new TextBox();
            gbInput.SuspendLayout();
            gbOutput.SuspendLayout();
            SuspendLayout();
            // 
            // gbInput
            // 
            gbInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbInput.BackColor = Color.FromArgb(50, 50, 50);
            gbInput.Controls.Add(edFunction);
            gbInput.Controls.Add(edMaxRowLength);
            gbInput.Controls.Add(btnConvert);
            gbInput.Controls.Add(label2);
            gbInput.Controls.Add(label1);
            gbInput.Controls.Add(cbHexFlag);
            gbInput.Controls.Add(edInput);
            gbInput.ForeColor = Color.FromArgb(250, 180, 85);
            gbInput.Location = new Point(-1, -2);
            gbInput.Name = "gbInput";
            gbInput.Size = new Size(1183, 300);
            gbInput.TabIndex = 0;
            gbInput.TabStop = false;
            gbInput.Text = "Vstupný Text";
            gbInput.Paint += PaintBorderlessGroupBox;
            // 
            // edFunction
            // 
            edFunction.Location = new Point(669, 149);
            edFunction.Name = "edFunction";
            edFunction.Size = new Size(125, 27);
            edFunction.TabIndex = 7;
            // 
            // edMaxRowLength
            // 
            edMaxRowLength.Location = new Point(377, 149);
            edMaxRowLength.Name = "edMaxRowLength";
            edMaxRowLength.Size = new Size(125, 27);
            edMaxRowLength.TabIndex = 2;
            edMaxRowLength.Text = "100";
            edMaxRowLength.TextChanged += edMaxRowLength_TextChanged;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(471, 206);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(240, 59);
            btnConvert.TabIndex = 6;
            btnConvert.Text = "Konvertovať";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(526, 155);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 5;
            label2.Text = "Vlastná Chr funkcia:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 155);
            label1.Name = "label1";
            label1.Size = new Size(169, 20);
            label1.TabIndex = 2;
            label1.Text = "Maximálna dĺžka riadku:";
            // 
            // cbHexFlag
            // 
            cbHexFlag.AutoSize = true;
            cbHexFlag.Location = new Point(13, 151);
            cbHexFlag.Name = "cbHexFlag";
            cbHexFlag.Size = new Size(57, 24);
            cbHexFlag.TabIndex = 1;
            cbHexFlag.Text = "Hex";
            cbHexFlag.UseVisualStyleBackColor = true;
            // 
            // edInput
            // 
            edInput.Location = new Point(13, 55);
            edInput.Multiline = true;
            edInput.Name = "edInput";
            edInput.ScrollBars = ScrollBars.Both;
            edInput.Size = new Size(1160, 90);
            edInput.TabIndex = 0;
            edInput.TextChanged += edInput_TextChanged;
            // 
            // gbOutput
            // 
            gbOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbOutput.BackColor = Color.FromArgb(50, 50, 50);
            gbOutput.Controls.Add(btnClipBoard);
            gbOutput.Controls.Add(edOutput);
            gbOutput.ForeColor = Color.FromArgb(250, 180, 85);
            gbOutput.Location = new Point(-1, 295);
            gbOutput.Name = "gbOutput";
            gbOutput.Size = new Size(1183, 300);
            gbOutput.TabIndex = 1;
            gbOutput.TabStop = false;
            gbOutput.Text = "Výstupný text";
            gbOutput.Paint += PaintBorderlessGroupBox;
            // 
            // btnClipBoard
            // 
            btnClipBoard.Location = new Point(13, 224);
            btnClipBoard.Name = "btnClipBoard";
            btnClipBoard.Size = new Size(138, 40);
            btnClipBoard.TabIndex = 1;
            btnClipBoard.Text = "Kopírovať";
            btnClipBoard.UseVisualStyleBackColor = true;
            // 
            // edOutput
            // 
            edOutput.Location = new Point(13, 59);
            edOutput.Multiline = true;
            edOutput.Name = "edOutput";
            edOutput.ScrollBars = ScrollBars.Both;
            edOutput.Size = new Size(1160, 159);
            edOutput.TabIndex = 0;
            // 
            // frmJNTConvertor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 593);
            Controls.Add(gbOutput);
            Controls.Add(gbInput);
            Name = "frmJNTConvertor";
            Text = "new VBA Unicode Convertor";
            gbInput.ResumeLayout(false);
            gbInput.PerformLayout();
            gbOutput.ResumeLayout(false);
            gbOutput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p) 
        {
            GroupBox box = (GroupBox)sender;
            Rectangle rect = box.ClientRectangle;

            using (SolidBrush solidBrush = new SolidBrush(box.BackColor))
                p.Graphics.FillRectangle(solidBrush, rect);

            using (SolidBrush textBrush = new SolidBrush(box.ForeColor)) 
            {
                SizeF textSize = p.Graphics.MeasureString(box.Text, box.Font);
                int textX = 10;
                int textY = (int)(textSize.Height / 10);

                p.Graphics.DrawString(box.Text, box.Font, textBrush, textX, textY);
            }
        }
        private GroupBox gbInput;
        private TextBox edInput;
        private CheckBox cbHexFlag;
        private Label label2;
        private Label label1;
        private Button btnConvert;
        private GroupBox gbOutput;
        private TextBox edOutput;
        private Button btnClipBoard;
        private TextBox edFunction;
        private TextBox edMaxRowLength;
    }
}
