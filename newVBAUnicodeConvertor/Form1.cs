using System.Text.RegularExpressions;
using System.Linq;
using Microsoft.VisualBasic;
using System.Text;
using System.Diagnostics;

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
            customFunction = "Chrw";
        }

        private void edMaxRowLength_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(edMaxRowLength.Text, out maxRowLength))
            {
                edMaxRowLength.Text = "100";
                maxRowLength = 100;
            }
        }
        private void edInput_TextChanged(object sender, EventArgs e)
        {
            this.input = edInput.Text;
        }

        private string splitString(string inputStr, int maxLen)
        {
            inputStr = inputStr.Trim();
            if (string.IsNullOrEmpty(inputStr))
                return string.Empty;

            List<string> operands = new List<string>();
            int i = 0;
            while (i < inputStr.Length)
            {
                while (i < inputStr.Length && char.IsWhiteSpace(inputStr[i]))
                    i++;
                if (i >= inputStr.Length) break;

                if (inputStr[i] == '"')
                {
                    int start = i;
                    i++;
                    while (i < inputStr.Length)
                    {
                        if (inputStr[i] == '"')
                        {
                            if (i + 1 < inputStr.Length && inputStr[i + 1] == '"')
                            {
                                i += 2;
                                continue;
                            }
                            else
                            {
                                i++;
                                break;
                            }
                        }
                        i++;
                    }
                    operands.Add(inputStr.Substring(start, i - start));
                }
                else
                {
                    int start = i;
                    while (i < inputStr.Length && inputStr[i] != '(') i++;
                    if (i >= inputStr.Length || inputStr[i] != '(')
                        break;
                    i++;
                    int parenCount = 1;
                    while (i < inputStr.Length && parenCount > 0)
                    {
                        char ch = inputStr[i];
                        if (ch == '(') parenCount++;
                        else if (ch == ')') parenCount--;
                        i++;
                    }
                    string chunk = inputStr.Substring(start, i - start).Trim();
                    if (!string.IsNullOrEmpty(chunk))
                        operands.Add(chunk);
                }

                while (i < inputStr.Length && char.IsWhiteSpace(inputStr[i]))
                    i++;
                if (i < inputStr.Length && inputStr[i] == '&')
                    i++;
            }

            var lines = new List<string>();
            var current = new StringBuilder();
            int idx = 0;
            while (idx < operands.Count)
            {
                string operand = operands[idx];
                string sep = (current.Length == 0) ? "" : " & ";
                int available = maxLen - current.Length - sep.Length;

                if (available <= 0 && current.Length > 0)
                {
                    string currStr = current.ToString().TrimEnd();
                    lines.Add(currStr + " & _\r\n");
                    current.Clear();
                    continue;
                }

                if (operand.Length > available)
                {
                    bool isQuoted = operand.StartsWith("\"") && operand.EndsWith("\"") && operand.Length >= 2;
                    if (isQuoted)
                    {
                        string content = operand.Substring(1, operand.Length - 2);
                        if (available < 2)
                        {
                            current.Append(sep + operand);
                            idx++;
                            continue;
                        }

                        int take = available - 2;
                        int pos = 0;
                        int count = 0;
                        while (pos < content.Length && count < take)
                        {
                            if (content[pos] == '"' && pos + 1 < content.Length && content[pos + 1] == '"')
                            {
                                if (count + 2 > take) break;
                                pos += 2;
                                count += 2;
                            }
                            else
                            {
                                pos++;
                                count++;
                            }
                        }

                        if (pos == 0)
                        {
                            current.Append(sep + operand);
                            idx++;
                            continue;
                        }

                        string chunk = content.Substring(0, pos);
                        string piece = "\"" + chunk + "\"";
                        current.Append(sep + piece);
                        operands[idx] = "\"" + content.Substring(pos) + "\"";
                        continue;
                    }
                    else
                    {
                        current.Append(sep + operand);
                        idx++;
                    }
                }
                else
                {
                    current.Append(sep + operand);
                    idx++;
                }
            }

            if (current.Length > 0)
                lines.Add(current.ToString().TrimEnd());

            return string.Join("", lines);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string convertedRes = convertToUtf32(input, cbHexFlag.Checked);
            string result = convertedRes.Length > maxRowLength ? splitString(convertedRes, maxRowLength) : convertedRes;
            edOutput.Text = result;
        }

        private string convertToUtf32(string str, bool useHex = false)
        {

            bool firstPart = true;
            var sb = new StringBuilder();
            var currentAscii = new StringBuilder();

            if (string.IsNullOrEmpty(str)) return string.Empty;

            customFunction = customFunction.Replace('('.ToString(), string.Empty);
            customFunction = customFunction.Replace(')'.ToString(), string.Empty);

            if (customFunction.Length > 4 || !Regex.IsMatch(customFunction, @"^[A-Za-z]+$"))
            {
                edFunction.Text = "";
                customFunction = "ChrW";
            }

            foreach (char c in str)
            {
                if (c <= 127)
                {
                    currentAscii.Append(c);
                }
                else
                {
                    if (currentAscii.Length > 0)
                    {
                        if (!firstPart)
                            sb.Append(" & ");
                        string escaped = currentAscii.ToString().Replace("\"", "\"\"");
                        sb.Append($"\"{escaped}\"");
                        currentAscii.Clear();
                        firstPart = false;
                    }

                    if (!firstPart)
                        sb.Append(" & ");

                    string code = useHex ? $"&H{((int)c).ToString("X")}" : ((int)c).ToString();
                    sb.Append($"{customFunction}({code})");
                    firstPart = false;
                }
            }

            if (currentAscii.Length > 0)
            {
                if (!firstPart)
                    sb.Append(" & ");
                string escaped = currentAscii.ToString().Replace("\"", "\"\"");
                sb.Append($"\"{escaped}\"");
            }

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
    }
}