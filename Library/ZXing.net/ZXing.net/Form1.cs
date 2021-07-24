using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZXing.net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeImageBox();
        }

        private void InitializeImageBox()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            using (var openform = new OpenFileDialog())
            {
                openform.Filter = "ALL|*.*|JPG|*.jpg|PNG|*.png";

                if (openform.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openform.FileName;
                    pictureBox1.Image = Image.FromFile(openform.FileName);

                    var reader = new BarcodeReader()
                    { 
                        Options =
                        {
                            PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.All_1D, BarcodeFormat.QR_CODE },
                            TryHarder = true, 
                        }
                    };
                    
                    // barcode result.
                    var results = reader.DecodeMultiple((Bitmap)pictureBox1.Image);
                    
                    //if (result != null)
                    //    textBox2.Text = result.Text;                     
                }
            }
        }
    }
}
