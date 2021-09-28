using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipBoardForm
{  
    public partial class Form1 : Form
    {
        private string[] ImageExt = new[] { ".jpg", ".png" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(textBox1.Text);

            MessageBox.Show($"{textBox1.Text} : 복사되었습니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Clipboard.GetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var form = new OpenFileDialog())
            {
                form.ShowDialog();

                if (ImageExt.Contains(Path.GetExtension(form.FileName)))
                {
                    var image = Image.FromFile(form.FileName);
                    Clipboard.SetImage(image);
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = image;
                }
            }                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var getImage = Clipboard.GetImage();

            if (getImage != null)
            {
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = getImage;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var form = new OpenFileDialog())
            {
                form.Multiselect = true;

                form.ShowDialog();

                var collection = new StringCollection();

                collection.AddRange(form.FileNames);

                Clipboard.SetFileDropList(collection);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Clipboard.GetFileDropList().Cast<object>().ToArray());  
        } 
    } 
}
