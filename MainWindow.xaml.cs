using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadsApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NxButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                MessageBox.Show("Siuncia nx");
                Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://speed.hetzner.de/100MB.bin").Result;

                NxButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                    NxButton.Content = "Done";
                });
            });
        }

        private void NxButton_Click2(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                MessageBox.Show("Siuncia nx");
                Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                HttpClient webClient = new HttpClient();
                string html = webClient.GetStringAsync("https://speed.hetzner.de/100MB.bin").Result;

                NxButton.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                    NxButton.Content = "Done";
                });
            });
        }
    }
}
