using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Windows.Shapes;

namespace LinqFunctions
{
    /// <summary>
    /// Interaktionslogik für ThreadWindow.xaml
    /// </summary>
    public partial class ThreadWindow : Window
    {
        public ThreadWindow()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            Process[] ps = Process.GetProcesses();
            foreach(var p in ps)
            {
                tb_output.Text += p.Id;
            }
            Process.Start("chrome", "www.google.de");
        }

        private void btnThreadpool_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem((obj)=> {
                SetText(obj as string);
            },tbUsers.Text);
        }

        private void SetText(string str)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(new Action<string>(s => { tb_output.Text = s; }),str);
                return;
            }
            tb_output.Text = str;
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            int product = Convert.ToInt32(tbProducts.Text);
            int user = Convert.ToInt32(tbUsers.Text);

            for (int i = 0; i < user; i++)
            {
                Thread oThread = new Thread(()=> {
                    while (true)
                    {
                        lock (this)
                        {
                            if (product >= 0)
                            {
                                product--;
                                SetTbProductsText(product.ToString());
                            }
                        }
                        Thread.Sleep(500);
                    }

                });
                oThread.IsBackground = true;
                oThread.Start();
            }
        }

        private void SetTbProductsText(string str)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() =>
                {
                   this.tbProducts.Text = str;
                }
                );
                return;
            }
            tbProducts.Text = str;
        }


        private void btnDelegateInvoke_Click(object sender, RoutedEventArgs e)
        {
            #region Solution
            //Func<int, int, string> del = (a, b) => (a + b).ToString();
            //IAsyncResult asy = del.BeginInvoke(3, 4, null, null);

            //Thread.Sleep(500);

            //tb_output.Text = del.EndInvoke(asy); 
            #endregion
            Func<int, int, string> del = (a, b) => (a + b).ToString();
            IAsyncResult result = del.BeginInvoke(3, 4, null, null);
            Thread.Sleep(500);
            string str = del.EndInvoke(result);
        }

        private void btnCallBack_Click(object sender, RoutedEventArgs e)
        {
            Func<int, int, string> del = (a, b) => { return (a + b).ToString(); };
            del.BeginInvoke(3, 4, Mycallback, del);
        }

        private void Mycallback(IAsyncResult ar)
        {
            Func<int, int, string> del = ar.AsyncState as Func<int, int, string>;
            var result = del.EndInvoke(ar);
            MessageBox.Show(result);
        }


        public ManualResetEvent StopEvent = new ManualResetEvent(false);
        private void btnStartThread_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(tbManualWait.Text);
           
            Thread oThread = new Thread(()=> {
                StartThread(num);
            });
            oThread.IsBackground = true;
            oThread.Start();
        }

        private void SetWaitOneText(string str)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => {
                    tbManualWait.Text = str;
                });
                return;
            }
        }

        private void StartThread(int num) {
            int n = num;
            StopEvent.Reset();
            while (true)
            {
                n++;
                SetWaitOneText(n.ToString());
                Thread.Sleep(1000);
            }
        }

        private void btnEndThread_Click(object sender, RoutedEventArgs e)
        {
            StopEvent.WaitOne();
        }
    }
}
