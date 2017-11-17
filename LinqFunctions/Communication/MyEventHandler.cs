using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFunctions
{
    public class MyEventArgs : EventArgs
    {
        public string Text;
        public MyEventArgs(string str)
        {
            Text = str;
        }
    }
}
