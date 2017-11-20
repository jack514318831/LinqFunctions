using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LinqFunctions.WPFClass.CodeOnly
{
    class Programm:Application
    {
        [STAThread()]
        static void Main()
        {
            Programm app = new Programm();
            app.MainWindow = new Window1();
            app.MainWindow.ShowDialog();
        }
    }
}
