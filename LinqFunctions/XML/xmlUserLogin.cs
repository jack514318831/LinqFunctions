using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LinqFunctions.XML
{
    public partial class xmlUserLogin : Form
    {
        public xmlUserLogin()
        {
            InitializeComponent();
        }

        private void xmlUserLogin_Load(object sender, EventArgs e)
        {
            XmlDocument root = new XmlDocument();
            root.Load(@"E:/Csharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            XmlNodeList xmllist = root.SelectNodes("/Users/user");
            foreach (XmlNode node in xmllist)
            {
                ListViewItem item = new ListViewItem(node.Attributes["id"].Value);
                item.SubItems.Add(node.SelectSingleNode("name").InnerText);
                item.SubItems.Add(node.SelectSingleNode("password").InnerText);
                listView1.Items.Add(item);
            }
        }
    }
}
