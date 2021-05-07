using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomControlLibrary.Controls
{
    public partial class SearchBox : UserControl
    {
        /// <summary>
        /// 초성
        /// </summary>
        private char[] Consonant = { 'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ' };

        /// <summary>
        /// 조합형
        /// </summary>
        private string[] Combinant = { "가", "까", "나", "다", "따", "라", "마", "바", "빠", "사", "싸", "아", "자", "짜", "차", "카", "타", "파", "하" };

        /// <summary>
        /// 조합형 int value
        /// </summary>
        private int[] CombinantInt = { 44032, 44620, 45208, 45796, 46384, 46972, 47560, 48148, 48736, 49324, 49912, 50500, 51088, 51676, 52264, 52852, 53440, 54028, 54616, 55204 };

        /// <summary>
        /// Search Data.
        /// </summary>
        [Category("SearchBox")]
        public List<string> Data { get; set; }

        /// <summary>
        /// Limit Height
        /// </summary>
        [Category("SearchBox")]
        public int DisplayLimitCount { get; set; } = 0;

        /// <summary>
        /// Search Word
        /// </summary>
        [Category("SearchBox")]
        public TextBox TextBox => tb_Text;

        /// <summary>
        /// Searched Box
        /// </summary>
        [Category("SearchBox")]
        public ListBox ListBox => lb_Search;


        /// <summary>
        /// Constructor        
        /// </summary>
        public SearchBox()
        {
            InitializeComponent();
            InitializeControl();
        }

        /// <summary>
        /// Initialize
        /// </summary>
        private void InitializeControl()
        {
            Data = new List<string>();

            // default size
            this.Size = new Size(Width, tb_Text.Height);
        }

        /// <summary>
        /// Auto Complete
        /// </summary>
        /// <param name="contents">Data</param>
        /// <param name="word">Search Text</param>
        /// <returns>Searched Text</returns>
        internal List<string> SearchWord(List<string> contents, string word)
        {
            var pattern = new StringBuilder();
            pattern.Append("");

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] >= 'ㄱ' && word[i] <= 'ㅎ')
                {
                    for (int j = 0; j < Consonant.Length; j++)
                    {
                        if (word[i] == Consonant[j])
                        {
                            pattern.Append($"[{Combinant[j]}-{(char)(CombinantInt[j + 1] - 1)}]");
                        }
                    }
                }
                else if (word[i] >= '가')
                {
                    int magic = ((word[i] - '가') % 588);

                    magic = 27 - (magic % 28);

                    pattern.Append($"[{word[i]}-{(char)(word[i] + magic)}]");
                }
                else if (word[i] >= 'A' && word[i] <= 'z')
                {
                    bool isLower = word[i] >= 'a' ? true : false;

                    pattern.Append($"[{word[i]}{(char)(isLower ? word[i] - 32 : word[i] + 32)}]");
                }
                else if (word[i] >= '0' && word[i] <= '9')
                {
                    pattern.Append(word[i]);
                }
            }

            return contents.Where(e => Regex.IsMatch(e.ToString(), pattern.ToString())).ToList();
        }

        private void tb_Text_TextChanged(object sender, EventArgs e)
        {
            if (Data is null || Data.Count < 1)
                return;

            if (string.IsNullOrEmpty(tb_Text.Text))
            {
                this.Size = new Size(Width, 21);
                lb_Search.Items.Clear();
                return;
            }

            lb_Search.Items.Clear();
            lb_Search.Items.AddRange(SearchWord(Data, tb_Text.Text).ToArray());

            var height = (lb_Search.Items.Count + 1) * 12;

            if (DisplayLimitCount != default(int))
                height = DisplayLimitCount >= lb_Search.Items.Count ? height : (DisplayLimitCount + 1) * 12;

            this.Size = new Size(Width, 21 + height);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Left)
            {
                if (ActiveControl.Name.Equals(nameof(lb_Search)))
                {
                    if (lb_Search.SelectedIndex == 0)
                    {
                        TextBoxFocus(tb_Text);
                        lb_Search.ClearSelected();

                        return true;
                    }
                }
            }
            else if (keyData == Keys.Down || keyData == Keys.Right)
            {
                if (ActiveControl.Name.Equals(nameof(tb_Text)) && lb_Search.Items.Count > 0)
                {
                    lb_Search.Focus();
                    lb_Search.SetSelected(0, true);
                }
            }
            else if (keyData == Keys.Enter)
            {
                if (lb_Search.SelectedIndex > -1)
                {
                    tb_Text.Text = lb_Search.SelectedItem.ToString();
                    this.Size = new Size(Width, 21);
                    lb_Search.Items.Clear();
                    TextBoxFocus(tb_Text);
                }
            }
            else if (keyData == Keys.Tab || keyData == (Keys.Shift | Keys.Tab))
            {
                this.Size = new Size(Width, 21);
                lb_Search.Items.Clear();
            }
            else if (keyData == Keys.Back)
            {
                if (ActiveControl.Name.Equals(nameof(lb_Search)))
                {
                    lb_Search.ClearSelected();

                    if (tb_Text.Text.Length > 0)
                    {
                        tb_Text.Text = tb_Text.Text.Remove(tb_Text.Text.Length - 1, 1);
                    }
                    TextBoxFocus(tb_Text);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TextBoxFocus(TextBox box)
        {
            box.Focus();
            box.SelectionStart = box.Text.Length;
        }

        /// <summary>
        /// Call the tb_Text_TextChanged.
        /// </summary>
        public void ResetSearchWord() => tb_Text_TextChanged(tb_Text, null);
    }
}
