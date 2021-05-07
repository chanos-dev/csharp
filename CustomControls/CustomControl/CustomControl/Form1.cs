using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            searchBox1.DisplayLimitCount = 10;            

            searchBox1.Data = File.ReadAllLines(@"Sample/Sample.txt").ToList();
        }
    }
}
