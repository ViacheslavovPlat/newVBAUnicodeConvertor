using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.VisualBasic;

namespace newVBAUnicodeConvertor
{
    public partial class frmJNTConvertor : Form
    {
        private int maxRowLength;
        private string input;
        public frmJNTConvertor()
        {
            InitializeComponent();
            int.TryParse(edMaxRowLength.Text, out maxRowLength);
            input = string.Empty;
        }

        private void edMaxRowLength_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(edMaxRowLength.Text, out maxRowLength))
            {
                edMaxRowLength.Text = "100";
                maxRowLength = 100;
            }
        }

        private string splitString(string inputStr, int maxLen)
        {
            string result;

            inputStr = inputStr.Trim();
            if (String.IsNullOrEmpty(inputStr))
            {
                return string.Empty;
            }

            IEnumerable<Match> matches = Regex.Matches(inputStr, $@".{{1,{maxLen}}}");
            result = string.Join(" & _\r\n", matches.Cast<Match>().Select(m => "\"" + m.Value + "\""));
            return result;
        }

        private void edInput_TextChanged(object sender, EventArgs e)
        {
            this.input = edInput.Text;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(input)) 
            { 
                MessageBox.Show("Vstup nesmie byť prázdny");
                return;
            }

            if (input.Length > maxRowLength) 
            {
                input = splitString(input, maxRowLength);
                edOutput.Text = input;
            }
        }
    }
}
