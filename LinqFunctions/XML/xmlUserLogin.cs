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
            #region LoadXML
            //XmlDocument root = new XmlDocument();
            //root.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            //XmlNodeList xmllist = root.SelectNodes("/Users/user");
            //foreach (XmlNode node in xmllist)
            //{
            //    ListViewItem item = new ListViewItem(node.Attributes["id"].Value);
            //    item.SubItems.Add(node.SelectSingleNode("name").InnerText);
            //    item.SubItems.Add(node.SelectSingleNode("password").InnerText);
            //    listView1.Items.Add(item);
            //} 
            #endregion

            XMLLoad();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");

            #region Solution
            XmlElement root = document.DocumentElement;

            if (root.SelectNodes(string.Format("user[@id={0}]", tbNewId.Text)).Count > 0)
            {
                MessageBox.Show("Exitiert");
                return;
            }

            XmlElement node = document.CreateElement("user");
            node.SetAttribute("id", tbNewId.Text);
            XmlElement subNode = document.CreateElement("name");
            subNode.InnerText = tbNeuName.Text;
            node.AppendChild(subNode);
            subNode = document.CreateElement("password");
            subNode.InnerText = tbNewPassword.Text;

            node.AppendChild(subNode);
            root.AppendChild(node);
            document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml"); 
            #endregion

            XMLLoad();
            
        }

        private void XMLLoad()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            XmlNodeList nodelist = document.SelectNodes("/Users/user");

            listView1.Items.Clear();
            foreach (XmlNode node in nodelist)
            {
                ListViewItem item = new ListViewItem(node.Attributes["id"].Value);
                item.SubItems.Add(node.SelectSingleNode("name").InnerText);
                item.SubItems.Add(node.SelectSingleNode("password").InnerText);
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection itemlist = lv.SelectedItems;

            foreach (ListViewItem item in itemlist)
            {
                tbEditId.Text = item.Text;
                tbEditUsername.Text = item.SubItems[1].Text;
                tbEditPassword.Text = item.SubItems[2].Text; 
            }
        }
    }
}
