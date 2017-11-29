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

        public delegate void SendMessage(string messeage);
        public SendMessage sendmessage;
        public event EventHandler SendMessageEvent;
        List<ISendmassege> SendList = new List<ISendmassege>();
        private void btn_new_Click(object sender, RoutedEventArgs e)
        {
            Thread oThread = new Thread(() => {
                Kind kf = new Kind();
                sendmessage += kf.SetText;
                SendMessageEvent += kf.SetTextFromEvent;
                SendList.Add(kf);

                System.Windows.Threading.Dispatcher.Run();
            });
            oThread.SetApartmentState(ApartmentState.STA);
            oThread.Start();
        }

        private void btn_trans_Click(object sender, RoutedEventArgs e)
        {
            if (sendmessage == null) return;
            sendmessage(tb_info.Text);
        }

        private void btn_Event_Click(object sender, RoutedEventArgs e)
        {
            if (SendMessageEvent == null) return;
            SendMessageEvent(this, new MyEventArgs(tb_info.Text));
        }

        private void btn_Abont_Click(object sender, RoutedEventArgs e)
        {
            foreach (ISendmassege k in SendList)
            {
                k.SetTextAbont(tb_info.Text);
            }
        }
    }
}
