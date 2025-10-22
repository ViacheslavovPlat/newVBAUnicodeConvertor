namespace newVBAUnicodeConvertor
{
    partial class frmJNTConvertor
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
        /// Required method for Designer support — do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbInput = new GroupBox();
            orangeLine = new Panel();
            btnConvert = new Button();
            pnlControls = new Panel();
            edFunction = new TextBox();
            edMaxRowLength = new TextBox();
            label2 = new Label();
            label1 = new Label();
            edInput = new TextBox();
            cbHexFlag = new CheckBox();
            gbOutput = new GroupBox();
            btnClipBoard = new Button();
            edOutput = new TextBox();
            cbMsgBox = new CheckBox();
            gbInput.SuspendLayout();
            orangeLine.SuspendLayout();
            pnlControls.SuspendLayout();
            gbOutput.SuspendLayout();
            SuspendLayout();
            // 
            // gbInput
            // 
            gbInput.BackColor = Color.FromArgb(50, 50, 50);
            gbInput.Controls.Add(orangeLine);
            gbInput.Controls.Add(pnlControls);
            gbInput.Dock = DockStyle.Top;
            gbInput.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            gbInput.ForeColor = Color.FromArgb(250, 180, 85);
            gbInput.Location = new Point(0, 0);
            gbInput.Name = "gbInput";
            gbInput.Size = new Size(1179, 300);
            gbInput.TabIndex = 0;
            gbInput.TabStop = false;
            gbInput.Text = "Vstupný Text";
            gbInput.Paint += PaintBorderlessGroupBox;
            gbInput.Layout += gbInput_Layout;
            // 
            // orangeLine
            // 
            orangeLine.BackColor = Color.FromArgb(250, 180, 85);
            orangeLine.Controls.Add(btnConvert);
            orangeLine.Dock = DockStyle.Bottom;
            orangeLine.Location = new Point(3, 238);
            orangeLine.Name = "orangeLine";
            orangeLine.Size = new Size(1173, 59);
            orangeLine.TabIndex = 8;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.None;
            btnConvert.BackColor = Color.WhiteSmoke;
            btnConvert.FlatAppearance.BorderColor = Color.FromArgb(250, 180, 85);
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.ForeColor = Color.FromArgb(50, 50, 50);
            btnConvert.Location = new Point(486, 0);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(240, 50);
            btnConvert.TabIndex = 6;
            btnConvert.Text = "Konvertovať";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.FromArgb(50, 50, 50);
            pnlControls.Controls.Add(cbMsgBox);
            pnlControls.Controls.Add(edFunction);
            pnlControls.Controls.Add(edMaxRowLength);
            pnlControls.Controls.Add(label2);
            pnlControls.Controls.Add(label1);
            pnlControls.Controls.Add(edInput);
            pnlControls.Controls.Add(cbHexFlag);
            pnlControls.Dock = DockStyle.Fill;
            pnlControls.Location = new Point(3, 27);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(1173, 270);
            pnlControls.TabIndex = 12;
            // 
            // edFunction
            // 
            edFunction.Location = new Point(660, 98);
            edFunction.Name = "edFunction";
            edFunction.Size = new Size(125, 31);
            edFunction.TabIndex = 7;
            edFunction.TextChanged += edFunction_TextChanged;
            // 
            // edMaxRowLength
            // 
            edMaxRowLength.Location = new Point(316, 98);
            edMaxRowLength.Name = "edMaxRowLength";
            edMaxRowLength.Size = new Size(125, 31);
            edMaxRowLength.TabIndex = 2;
            edMaxRowLength.Text = "100";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(488, 102);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 5;
            label2.Text = "Vlastná Chr funkcia:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 101);
            label1.Name = "label1";
            label1.Size = new Size(201, 25);
            label1.TabIndex = 2;
            label1.Text = "Maximálna dĺžka riadku:";
            // 
            // edInput
            // 
            edInput.Location = new Point(10, 3);
            edInput.Multiline = true;
            edInput.Name = "edInput";
            edInput.ScrollBars = ScrollBars.Both;
            edInput.Size = new Size(1160, 90);
            edInput.TabIndex = 0;
            // 
            // cbHexFlag
            // 
            cbHexFlag.AutoSize = true;
            cbHexFlag.Location = new Point(10, 100);
            cbHexFlag.Name = "cbHexFlag";
            cbHexFlag.Size = new Size(64, 29);
            cbHexFlag.TabIndex = 1;
            cbHexFlag.Text = "Hex";
            cbHexFlag.UseVisualStyleBackColor = true;
            // 
            // gbOutput
            // 
            gbOutput.BackColor = Color.FromArgb(50, 50, 50);
            gbOutput.Controls.Add(btnClipBoard);
            gbOutput.Controls.Add(edOutput);
            gbOutput.Dock = DockStyle.Fill;
            gbOutput.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            gbOutput.ForeColor = Color.FromArgb(250, 180, 85);
            gbOutput.Location = new Point(0, 300);
            gbOutput.Name = "gbOutput";
            gbOutput.Size = new Size(1179, 293);
            gbOutput.TabIndex = 1;
            gbOutput.TabStop = false;
            gbOutput.Text = "Výstupný text";
            gbOutput.Paint += PaintBorderlessGroupBox;
            // 
            // btnClipBoard
            // 
            btnClipBoard.BackColor = Color.WhiteSmoke;
            btnClipBoard.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
            btnClipBoard.FlatStyle = FlatStyle.Flat;
            btnClipBoard.ForeColor = Color.FromArgb(50, 50, 50);
            btnClipBoard.Location = new Point(13, 224);
            btnClipBoard.Name = "btnClipBoard";
            btnClipBoard.Size = new Size(138, 40);
            btnClipBoard.TabIndex = 1;
            btnClipBoard.Text = "Kopírovať";
            btnClipBoard.UseVisualStyleBackColor = false;
            btnClipBoard.Click += btnClipBoard_Click;
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
            // cbMsgBox
            // 
            cbMsgBox.AutoSize = true;
            cbMsgBox.Location = new Point(823, 98);
            cbMsgBox.Name = "cbMsgBox";
            cbMsgBox.Size = new Size(98, 29);
            cbMsgBox.TabIndex = 8;
            cbMsgBox.Text = "MsgBox";
            cbMsgBox.UseVisualStyleBackColor = true;
            // 
            // frmJNTConvertor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1179, 593);
            Controls.Add(gbOutput);
            Controls.Add(gbInput);
            ForeColor = Color.FromArgb(250, 180, 85);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmJNTConvertor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "new VBA Unicode Convertor";
            gbInput.ResumeLayout(false);
            orangeLine.ResumeLayout(false);
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            gbOutput.ResumeLayout(false);
            gbOutput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            Rectangle rect = box.ClientRectangle;

            SizeF textSize = p.Graphics.MeasureString(box.Text, box.Font);
            Rectangle titleRect = new Rectangle(0, 0, rect.Width, (int)(textSize.Height * 1.8));

            using (SolidBrush headerBrush = new SolidBrush(box.BackColor))
                p.Graphics.FillRectangle(headerBrush, titleRect);

            using (SolidBrush textBrush = new SolidBrush(box.ForeColor))
            {
                int textX = 10;
                int textY = (int)(textSize.Height / 10);
                p.Graphics.DrawString(box.Text, box.Font, textBrush, textX, textY);
            }
            p.Graphics.Clear(box.BackColor);
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
        private Panel orangeLine;
        private Panel pnlControls;
        private CheckBox cbMsgBox;
    }
}
