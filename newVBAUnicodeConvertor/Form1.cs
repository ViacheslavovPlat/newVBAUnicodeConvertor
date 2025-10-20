using System.Text.RegularExpressions;
using System.Text;

namespace newVBAUnicodeConvertor
{
    public partial class frmJNTConvertor : Form
    {
        private int maxRowLength;
        private string input;
        private string customFunction;
        public frmJNTConvertor()
        {
            InitializeComponent();

            int.TryParse(edMaxRowLength.Text, out maxRowLength);
            input = string.Empty;
            customFunction = "ChrW";

            orangeLine.Layout += (s, e) =>
            {
                btnConvert.Location = new Point((orangeLine.Width - btnConvert.Width) / 2, (orangeLine.Height - btnConvert.Height) / 2);
            };
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(edMaxRowLength.Text, out maxRowLength))
                maxRowLength = 100;

            this.input = edInput.Text;
            string convertedRes = convertToUtf32(input, cbHexFlag.Checked);

            edOutput.Text = convertedRes;
        }
        private void insertMsgBox(string input)
        {

        }

        private string convertToUtf32(string str, bool useHex = false)
        {
            byte convMode = 0;
            int ln = str.Length;
            int c = 0;

            StringBuilder sb = new StringBuilder(ln << 1);

            if (string.IsNullOrEmpty(str))
                return "\"\"";

            if (maxRowLength < 1)
                maxRowLength = 1;

            for (int i = 0; i < ln; ++i)
            {
                char ch = str[i];
                int charVal = (int)ch;
                string s = "";

                if (charVal >= 32 && charVal <= 127)
                {
                    if (convMode == 0)
                        s += "\"";
                    else if (convMode == 2)
                        s += " & \"";

                    if (charVal == 34)
                        s += "\"\"";
                    else
                        s += ch;

                    convMode = 1;
                }
                else if (charVal <= 65535)
                {
                    string code = useHex ? $"&H{charVal:X}" : charVal.ToString();
                    s = (convMode == 1 ? "\" & " : convMode == 2 ? " & " : "") + customFunction + "(" + code + ")";
                    convMode = 2;
                }

                bool hasNext = (i + 1 < ln);

                if (c + s.Length + 4 >= maxRowLength)
                {
                    if (hasNext)
                        s += convMode == 1 ? "\" & _\r\n" : " & _\r\n";

                    convMode = 0;
                    c = 0;
                }
                else
                {
                    c += s.Length;
                }

                if (s.Length > 0)
                    sb.Append(s);
            }

            if (convMode == 1)
                sb.Append('"');

            return sb.ToString();
        }

        private void edFunction_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edFunction.Text))
                customFunction = edFunction.Text;
        }

        private void btnClipBoard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(edOutput.Text);
        }

        /*private void cbMsgBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbMsgBox.Checked)
            {
                cbIfThen.Enabled = false;
                cbIfThen.Checked = false;
            }
            else
                cbIfThen.Enabled = true;
        }*/

        private void gbInput_Layout(object sender, LayoutEventArgs e)
        {
            btnConvert.Location = new Point(btnConvert.Location.X, orangeLine.Top - btnConvert.Height);
        }
    }
}