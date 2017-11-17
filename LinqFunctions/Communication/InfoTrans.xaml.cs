using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für InfoTrans.xaml
    /// </summary>
    public partial class InfoTrans : Window
    {
        public InfoTrans()
        {
            InitializeComponent();
        }

        public Action<string> SendMessageAction { get; set; }
        public EventHandler SentMessageEvent;
        public List<ISendmassege> SendList = new List<ISendmassege>();
        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            Thread oThread = new Thread(() => {
                Kind kf = new Kind();
                SendMessageAction += kf.SetText;
                SentMessageEvent += kf.SetTextFromEvent;
                SendList.Add(kf);
                kf.ShowDialog();
                System.Windows.Threading.Dispatcher.Run();

            });

            oThread.SetApartmentState(ApartmentState.STA);
            oThread.Start();
        }

        private void btn_trans_Click(object sender, RoutedEventArgs e)
        {
            if (SendMessageAction != null)
            {
                SendMessageAction(tb_info.Text);
                return;
            }
        }

        private void btn_Event_Click(object sender, RoutedEventArgs e)
        {
            if (SentMessageEvent != null)
            {
                MyEventArgs m = new MyEventArgs(tb_info.Text);
                SentMessageEvent(this,m);
                return;
            }
        }

        private void btn_Abont_Click(object sender, RoutedEventArgs e)
        {
            foreach (var kf in SendList)
            {
                kf.SetTextAbont(tb_info.Text);
            }
        }
    }
}
