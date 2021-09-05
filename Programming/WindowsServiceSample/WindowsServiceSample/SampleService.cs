using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceSample
{
    public partial class SampleService : ServiceBase
    {
        private Timer Timer { get; set; }

        public SampleService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Timer = new Timer();
            Timer.Interval = 2 * 60 * 1000;
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var outPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{DateTime.Now:d}.txt");

            try
            {
                var client = new WebClient();
                client.DownloadFile(@"http://www.naver.com", outPath);
            }
            catch (Exception ex)
            {
                var errorPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{DateTime.Now:d}_error.txt");
                File.WriteAllText(errorPath, ex.Message);
            }
        }

        protected override void OnStop()
        {
            Timer?.Stop();
            Timer?.Dispose();
        }
    }
}
