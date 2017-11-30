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
            //XmlElement root = document.DocumentElement;

            //if (root.SelectNodes(string.Format("user[@id={0}]", tbNewId.Text)).Count > 0)
            //{
            //    MessageBox.Show("Exitiert");
            //    return;
            //}

            //XmlElement node = document.CreateElement("user");
            //node.SetAttribute("id", tbNewId.Text);
            //XmlElement subNode = document.CreateElement("name");
            //subNode.InnerText = tbNeuName.Text;
            //node.AppendChild(subNode);
            //subNode = document.CreateElement("password");
            //subNode.InnerText = tbNewPassword.Text;

            //node.AppendChild(subNode);
            //root.AppendChild(node);
            //document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            #endregion
            string id = tbNewId.Text;
            if (document.SelectNodes("/Users/user[@id='"+id+"']").Count > 0) return;
            XmlElement root = document.DocumentElement;
            XmlElement node = document.CreateElement("user");
            node.SetAttribute("id",id);
            XmlElement Nnode = document.CreateElement("name");
            Nnode.InnerText = tbNeuName.Text;
            node.AppendChild(Nnode);
            XmlElement PWnode = document.CreateElement("password");
            PWnode.InnerText = tbNewPassword.Text;
            node.AppendChild(PWnode);
            root.AppendChild(node);

            document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml"); 
            XMLLoad();
            
        }

        private void XMLLoad()
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");

            #region Solution
            //XmlNodeList nodelist = document.SelectNodes("/Users/user");
            //listView1.Items.Clear();
            //foreach (XmlNode node in nodelist)
            //{
            //    ListViewItem item = new ListViewItem(node.Attributes["id"].Value);
            //    item.SubItems.Add(node.SelectSingleNode("name").InnerText);
            //    item.SubItems.Add(node.SelectSingleNode("password").InnerText);
            //    listView1.Items.Add(item);
            //} 
            #endregion
            XmlNodeList nodelist = document.SelectNodes("/Users/user");
            listView1.Items.Clear();
            foreach(XmlNode node in nodelist)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");

            #region Solution
            //if(listView1.SelectedItems.Count>0)
            //{
            //    string id = listView1.SelectedItems[0].SubItems[0].Text;
            //    XmlNode node= document.SelectSingleNode("/Users/user[@id='" + id + "']");

            //    if(node!=null)
            //    {
            //        document.DocumentElement.RemoveChild(node);
            //        document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            //        XMLLoad();
            //    }
            //} 
            #endregion
            string id = tbEditId.Text;
            XmlNode node = document.SelectSingleNode("/Users/user[@id='"+id+"']");
            if (node == null) return;
            document.DocumentElement.RemoveChild(node);
            document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            XMLLoad();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // XmlNode node = document.SelectSingleNode("/Users/user/name[.='"+nid+"']");
            // node.NextSibling.InnerText;
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");

            #region Solution
            //string nid = tbLoginUsername.Text;
            //XmlNode node = document.SelectSingleNode("/Users/user/name[.='"+ nid +"']");
            //if (node == null) return;
            //string pw = node.NextSibling.InnerText;
            //if (!tbLoginPassword.Text.Equals(pw)) return;
            #endregion
            string nid = tbLoginUsername.Text;
            XmlNode node = document.SelectSingleNode("/Users/user/name[.='" + nid + "']");
            if (node == null) return;
            if(node.NextSibling.InnerText.Equals(tbLoginPassword.Text))
            {
                MessageBox.Show("Angepasst");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");

            #region Solution
            //XmlNode node = document.SelectSingleNode("/Users/user[@id='" + tbEditId.Text + "']");
            //if (node == null) return;
            //node.SelectSingleNode("name").InnerText = tbEditUsername.Text;
            //node.SelectSingleNode("password").InnerText = tbEditPassword.Text;
            #endregion
            XmlNode node = document.DocumentElement.SelectSingleNode("user[@id='"+tbEditId.Text+"']");
            if (node == null) return;
            node.SelectSingleNode("name").InnerText = tbEditUsername.Text;
            node.SelectSingleNode("password").InnerText = tbEditPassword.Text;

            document.Save(@"C:/Users/g.he/Documents/CSharp/Git/LinqFunctions/LinqFunctions/XML/UserXML.xml");
            XMLLoad();
           
        }
    }
}
