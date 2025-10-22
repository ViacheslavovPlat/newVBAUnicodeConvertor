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
            byte prevMode = 0, convMode = 0;
            int len = str.Length;
            int rowLen = 0;

            StringBuilder sb = new StringBuilder(len << 1);

            if (string.IsNullOrEmpty(str))
                return "\"\"";

            if (maxRowLength < 20)
                maxRowLength = 20;

            for (int i = 0; i < len; ++i)
            {
                char ch = str[i];
                int charVal = (int)ch;
                string s = "";
                prevMode = convMode;

                if (charVal >= 32 && charVal <= 126)
                {
                    convMode = 1;
                    if (prevMode == 0)
                    {
                        s += "\"";
                    }
                    else if (prevMode == 2) 
                    { 
                        s += " & \"";
                    }

                    if (charVal == 34)
                        s += "\"\"";
                    else
                        s += ch;
                }
                else if (charVal <= 65535)
                {
                    convMode = 2;
                    string code = useHex ? $"&H{charVal:X}" : charVal.ToString();
                    if (prevMode == 1)
                    {
                        s += "\" & ";
                    } 
                    else if (prevMode == 2) 
                    {
                        s += " & ";
                    }
                    s += customFunction + "(" + code + ")";
                }

                bool hasNext = (i + 1 < len);

                if (rowLen + s.Length + 5 >= maxRowLength && hasNext)
                {
                    s += convMode == 1 ? "\" & _\r\n" : " & _\r\n";
                    rowLen = 0;
                    convMode = 0;
                }
                rowLen += s.Length;
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
            if(!string.IsNullOrEmpty(edOutput.Text))
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