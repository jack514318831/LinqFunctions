using Microsoft.Win32;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Collections;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using LinqFunctions.XML;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LinqFunctions
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        #region LinqToXML
        private void CB_XML_DropDownClosed(object sender, EventArgs e)
        {
            string CBstr = CB_XML.Text;
            if (CBstr.Equals("Create XML"))
            {
                CreateXML();
                MessageBox.Show("Fertig");
            }
            else if (CBstr.Equals("Read XML"))
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == true)
                {
                    ReadXML(open.FileName);
                }

                MessageBox.Show("Fertig");
            }
            else if (CBstr.Equals("XML to string"))
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == true)
                {
                    XmlToString(open.FileName);
                }
                MessageBox.Show("Fertig");
            }
            else if (CBstr.Equals("UserFenster"))
            {
                xmlUserLogin xmlf = new xmlUserLogin();
                xmlf.ShowDialog();
            }
            else if (CBstr.Equals("Serializer"))
            {
                Serializer(@"E:\");
            }
        }

        private void CreateXML()
        {
            List<ModelEmployee> list = EmployeeListBuider.Buil();

            var result = new XElement("emps", from emp in list
                                              select new XElement("emp",
                                              new XAttribute("ID", emp.EmpployeeID),
                                              new XAttribute("DID", emp.DepartmentID),
                                              new XElement("Sal", emp.Salary)
                                              ));

            result.Save(@"E:\Test.xml");
        }

        private void ReadXML(string path)
        {
            XDocument xdoc = XDocument.Load(@"E:\countries.xml");

            var result = from country in xdoc.Descendants().Elements("country")
                         from city in country.Elements("city")
                         select new
                         {
                             country = country.Attribute("name").Value,
                             city = city.Value
                         };

            DG_Data.ItemsSource = result;
        }

        private void XmlToString(string path)
        {
            string lines = File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(lines);

            List<ModelCountry> list = new List<ModelCountry>();

            var citylist = from country in xdoc.Descendants().Elements("country")
                           from city in country.Elements("city")
                           select new
                           {
                               countryname = country.Attribute("name").Value,
                               cityname = city.Value
                           };

            foreach (var item in citylist)
            {
                list.Add(new ModelCountry(item.countryname, item.cityname));
            }
            DG_Data.ItemsSource = list;
        }

        private void Serializer(string path)
        {
            Buch buch = new Buch();
            buch.Autor = "Json";
            buch.Year = 2010;
            buch.Name = "Eupd";
            buch.Context = "Photovotaik";

            #region Solution
            ////JSon Serializer
            //JavaScriptSerializer jsonserializer = new JavaScriptSerializer();
            //tb_output.Text = jsonserializer.Serialize(buch);

            ////XML Serializer
            //XmlSerializer xmlserializer = new XmlSerializer(typeof(Buch));
            //using (FileStream fs = new FileStream(path + "xmlserializer.xml", FileMode.Create))
            //{
            //    xmlserializer.Serialize(fs, buch);
            //}

            ////Binary Serializer
            //BinaryFormatter binaryformatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(path + "BinarySerializer.bin", FileMode.Create))
            //{
            //    binaryformatter.Serialize(fs, buch);
            //} 
            #endregion
            JavaScriptSerializer jsonserializer = new JavaScriptSerializer();
            tb_output.Text = jsonserializer.Serialize(buch);

            using (FileStream fs = new FileStream(path + "xmlserializer.xml", FileMode.Create))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Buch));
                xmlserializer.Serialize(fs, buch);
            }

            using (FileStream fs = new FileStream(path + "Binaryserializer.xml", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, buch);
            }

        }

        [Serializable]
        public class Buch
        {
            public string Name;
            public int Year;
            public string Autor;
            [NonSerialized]
            public string Context;
        }

        #endregion

        #region StringAnalyse
        private void CB_String_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_String.Text;
            if (cbstr.Equals("To String A"))
            {
                stringA();
            }
            else if (cbstr.Equals("To String B"))
            {
                stringB();
            }
            else if (cbstr.Equals("To String C"))
            {
                stringC();
            }
            else if (cbstr.Equals("Check String no double char"))
            {
                stringD(tb_input.Text);
            }
            else if (cbstr.Equals("String Format"))
            {
                StringFormat();
            }
        }

        private void StringFormat()
        {
            DateTime date = DateTime.Now;
            //Culture Kurs Format
            string result = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0,10:C}{1,-10:d}{2}", 1.1, date.ToString(), "one");
            MessageBox.Show(result);
        }

        private void stringA()
        {
            string input = "linq to        string              example";

            var result = from word in input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                         select word;

            DG_Data.ItemsSource = result;

        }

        private void stringB()
        {
            string input = "hi Hellow HI world hellow world world hi hi";

            var result = from word in input.Split(' ').Distinct()
                         select word;

            DG_Data.ItemsSource = result;
        }

        private void stringC()
        {
            string input = "This sentance contains duplicate words and the following linq query will find the duplicate words in this sentance";

            var result = from word in input.Split(' ')
                         group word by word into words
                         select new
                         {
                             word = words.Key,
                             count = words.Count()
                         };

            DG_Data.ItemsSource = result;
        }

        private void stringD(string str)
        {
            // Find the Max Length of the substring of inputString
            string s = str;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int max = 0;
            for (int i = 0, j = 0; i <= s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    j = Math.Max(j, dic[s[i]]);
                }
                dic[s[i]] = i;
                max = Math.Max(max, i - j + 1);
            }
            tb_output.Text = max.ToString();
        }
        #endregion

        #region Linq Grund
        private void CB_Array_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_Array.Text;
            if (cbstr.Equals("String Array"))
            {
                ArrayA();
            }
            else if (cbstr.Equals("Int Array"))
            {
                ArrayB();
            }
            else if (cbstr.Equals("Type Of"))
            {
                ArrayD();
            }
            else if (cbstr.Equals("Let"))
            {
                ArrayC();
            }
            else if (cbstr.Equals("ArrayList"))
            {
                ArraylistFunc();
            }
            else if (cbstr.Equals("Innen Join"))
            {
                InnenJoin();
            }
            else if (cbstr.Equals("Links Join"))
            {
                LinksJoin();
            }
            else if (cbstr.Equals("Group Join"))
            {
                GroupJoin();
            }
            else if (cbstr.Equals("Right Join"))
            {
                RightJoin();
            }


        }

        private void ArrayA()
        {
            string[] ary = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            Func<string, bool> vergleich = s => s.StartsWith("J") && s.EndsWith("n");
            var result = ary.Where(vergleich);

        }

        private void ArrayB()
        {
            int[] ary = new int[] { 10, 27, 35, 40, 50, 11, 23, 25, 39, 22, 36 };

            var result = (from num in ary
                          orderby num
                          select num).Take(3);

            DG_Data.ItemsSource = result;
        }
        private void ArrayC()
        {
            string[] strings =
            {
                "A penny saved is a penny earned.",
                "The early bird catches the worm.",
                "The pen is mightier than the sword."
            };

            // what I need, is word begin with 't'/'T', but I don't want all words change as low invariant.
            var result = from sentence in strings
                         let words = sentence.Split(' ')
                         from word in words
                         let w = word.ToLower()
                         where w.StartsWith("t")
                         select sentence;

            DG_Data.ItemsSource = result;

        }

        private void ArrayD()
        {
            IList arr = new ArrayList();
            arr.Add(1.1);
            arr.Add(10);
            arr.Add("One");

            var result = arr.OfType<string>();

        }

        private void ArraylistFunc()
        {
            ArrayList list = new ArrayList();
            list.Add(new int[] { 31, 2, 34, 53, 1, 5 });

            // ascending sort
            list.Sort();

            // Descending sort
            list.Reverse();
        }

        private void InnenJoin()
        {
            StringBuilder output = new StringBuilder();
            List<Storage> slist = Storage.Build();
            List<Marke> mlist = Marke.Build();

            var result = from s in slist
                         join m in mlist on s.MarkeID equals m.MarkeID
                         where m.Name.Equals("SMA")
                         select s;

            DG_Data.ItemsSource = result;
        }

        private void LinksJoin()
        {
            StringBuilder output = new StringBuilder();
            List<Storage> slist = Storage.Build();
            List<Marke> mlist = Marke.Build();

            var result = from m in mlist
                         join s in slist on m.MarkeID equals s.MarkeID into storages
                         from item in storages.DefaultIfEmpty(new Storage(0, "", 0))
                         select new
                         {
                             mark = m.Name,
                             storage = item.Name
                         };

            DG_Data.ItemsSource = result;
        }

        private void RightJoin()
        {
            StringBuilder output = new StringBuilder();
            List<Storage> slist = Storage.Build();
            List<Marke> mlist = Marke.Build();

            var result = from s in slist
                         join m in mlist on s.MarkeID equals m.MarkeID into ms
                         from item in ms.DefaultIfEmpty()
                         select new
                         {
                             marke = item != null ? item.Name : string.Empty,
                             storage = s.Name
                         };

            DG_Data.ItemsSource = result;
        }

        private void GroupJoin()
        {
            StringBuilder output = new StringBuilder();
            List<Storage> slist = Storage.Build();
            List<Marke> mlist = Marke.Build();

            var result = from marke in mlist
                         join storage in slist on marke.MarkeID equals storage.MarkeID into storages
                         select new
                         {
                             MarkeName = marke.Name,
                             Storages = storages
                         };

            foreach (var marke in result)
            {
                output.AppendLine().Append(marke.MarkeName);
                foreach (var storage in marke.Storages)
                {
                    output.AppendLine().Append(" ").Append(storage.Name);
                }
            }

            tb_output.Text = output.ToString();

        }


        #endregion

        #region LambdaExp
        private void CB_Lambda_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_Lambda.Text;
            if (cbstr.Equals("Odd Average"))
            {
                LamdaOddAverage();
            }
            else if (cbstr.Equals("Expession Tree"))
            {
                LambdaTree();
            }
            else if (cbstr.Equals("ThenBy"))
            {
                LamdaThenby();
            }
            else if (cbstr.Equals("Aggregate"))
            {
                Aggregtion();
            }
            else if (cbstr.Equals("AggregationWith"))
            {
                AggregtionWith();
            }
            else if (cbstr.Equals("Skip While"))
            {
                SkipWhile();
            }
            else if (cbstr.Equals("Take While"))
            {
                TakeWhile();
            }
        }

        private void LamdaOddAverage()
        {
            int[] fibNum = { 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            var result = fibNum.Average();

            MessageBox.Show(result.ToString());
        }

        private void LambdaTree()
        {
            int[] source = new[] { 3, 8, 4, 6, 1, 7, 9, 2, 4, 8 };
            StringBuilder outstr = new StringBuilder();

            var result = source.Where((num) => {
                if (num >= 3 && num <= 7)
                    return true;
                return false;
            });

            foreach (var num in result)
            {
                outstr.Append(" ").Append(num.ToString());
            }

            tb_output.Text = outstr.ToString();
        }

        private void LamdaThenby()
        {
            IList<ModelEmployee> elist = EmployeeListBuider.Buil();

            var result = elist.OrderByDescending(emp => emp.DepartmentID).ThenBy(emp => emp.Salary);

            DG_Data.ItemsSource = result;
        }

        private void Aggregtion()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            //Weil S2 benutzt wird , das ist eine Rekursion. Ausgang ist s2 = null
            #region Komantar
            /*
             Function List<string> Aggregate(List<string> L)
             {
                string str = L.First();
                if(str != null)
                {
                    result = result + "," +str;
                    L.Remove(L.First());
                    Aggregate(L);
                }
             }
             */

            #endregion

            var result = strList.Aggregate((a, b) => a + b);
            MessageBox.Show(result.ToString());
        }

        private void SkipWhile()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            var result1 = strList.Skip(3);
            var result2 = strList.SkipWhile((s) => s.Length > 4);

            MessageBox.Show(result1.ToString());
            MessageBox.Show(result2.ToString());
        }

        private void TakeWhile()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            Func<string, string, string> aggregate = ((s1, s2) => s1 + " " + s2);

            var result = strList.TakeWhile(s => s.Length > 4).Aggregate(aggregate);

            MessageBox.Show(result.ToString());
        }

        private void AggregtionWith()
        {
            IList<ModelEmployee> eList = EmployeeListBuider.Buil();

            var result = eList.Aggregate<ModelEmployee, string, string>(string.Empty, (str, s) => str += s + ",", (s) => s.Substring(0, s.Length - 1));

            MessageBox.Show(result);
        }
        #endregion

        #region LinqToDataset/Regex
        private void CB_DataSet_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_DataSet.Text;
            if (cbstr.Equals("Create DataSet"))
            {
                CreateDS();
            }
            else if (cbstr.Equals("Linq to DataSet"))
            {
                LinqToDataSet();
            }
            else if (cbstr.Equals("Card Number"))
            {
                CardNumber();
            }
            else if (cbstr.Equals("Url Reader"))
            {
                URLReader();
            }
            else if (cbstr.Equals("Regex Grund"))
            {
                Pattern();
            }
        }

        private DataSet CreateDS()
        {
            List<ModelDepartment> dlist = EmployeeListBuider.DepartmentBuild();
            List<ModelEmployee> elist = EmployeeListBuider.Buil();

            DataSet ds = new DataSet();
            DataTable dtd = new DataTable("dp");
            DataTable dte = new DataTable("emp");

            dtd.Columns.Add(new DataColumn("DID"));
            dtd.Columns.Add(new DataColumn("name"));
            dte.Columns.Add(new DataColumn("ID"));
            dte.Columns.Add(new DataColumn("DID"));
            dte.Columns.Add(new DataColumn("Sal", System.Type.GetType("Int32")));

            foreach (var dp in dlist)
            {
                DataRow row = dtd.NewRow();
                row[0] = dp.DepartmentID;
                row[1] = dp.DepartmentName;
                dtd.Rows.Add(row);
            }
            foreach (var emp in elist)
            {
                DataRow row = dte.NewRow();
                row[0] = emp.EmpployeeID;
                row[1] = emp.DepartmentID;
                row[2] = emp.Salary;
                dte.Rows.Add(row);
            }

            ds.Tables.Add(dtd);
            ds.Tables.Add(dte);
            return ds;
        }

        private void LinqToDataSet()
        {
            DataSet ds = CreateDS();

            var result = from emp in ds.Tables["emp"].AsEnumerable()
                         join dp in ds.Tables["dp"].AsEnumerable() on emp.Field<string>("DID") equals dp.Field<string>("DID")
                         select new
                         {
                             emp = emp.Field<Int32>("Sal")
                         };


            DG_Data.ItemsSource = result;

        }

        #region Regex Grund Functions
        //Regex.IsMatch()
        //Regex.Match()
        //Regex.Matches()
        //Regex.Replace()
        //group 0(1(2)(3))(4)
        #endregion

        private void Pattern()
        {
            //PLZ
            string pattern = "^0-9{6}$";

            //10-25
            pattern = "^1[0-9]|2[0-5]$";
            bool b = Regex.IsMatch("", pattern, RegexOptions.ECMAScript);

            //Personal ID
            pattern = @"^([1-9]\d{14})|([1-9]\d{16}[1-9xX])$";

            //E-mail
            pattern = @"^[-a-zA-Z0-9_\.]+@[a-zA-Z0-9]+[\.a-zA-Z0-9]{1,2}$";

            //Televon nummer
            pattern = @"^\d{3,4}-?\d{7,8}$";

            //Datum
            pattern = @"^[0-9]{4}-(0[1-9]|1[0-2])-[0-9]{2}$";

            //Machtes Ip
            string msg = "196.168.10.5[port=21,type=ftp]";
            Match mt = Regex.Match(msg, @"(.+)\[port=([0-9]+),type=(.+)\]");
            string result = string.Format("ip:{0} port:{1} type:{2}", mt.Groups[1], mt.Groups[2], mt.Groups[3]);

            //Replace *+ as %
            string str = "how###are##you####";
            result = Regex.Replace(str, "#+", "%");

            //Replace Kammel
            str = "hallo 'welcome' to 'China'";
            result = Regex.Replace(str, "'(.+?)'", "[$1]");

            //Tel. verstecken
            str = "He:17680923124 Gang:15634566774";
            result = Regex.Replace(str, "([0-9]{3})[0-9]{4}([0-9]{4})", "$1****$2");

            //Email with *
            str = "ganghe@gmx.de";
            string s = "*********************************";

            MatchEvaluator matchEvaluator = mt1 => s.Substring(0,mt1.Groups[1].Length)+mt1.Groups[2];
            result = Regex.Replace(str, @"(\w+)(@\w+\.\w+)", matchEvaluator, RegexOptions.ECMAScript);

            // row as line
            str = "Temorrow is good day, row is row 10";
            result = Regex.Replace(str, @"\brow\b", "line");

            //wiederholt word
            str = "aabb ccddd";
            result = Regex.Replace(str, @"(.)\1+", "$1");

            //Match word with doppelt char
            str = "one two three zoo";
            MatchCollection rmt = Regex.Matches(str, @"[a-z]*[a-z]\1+[a-z]*");
        }

        private void CardNumber()
        {
            string str = "hier ist a card num : 4444-3333-2222-1111";

            string pattern = @"(\d{4}[ ,-]){3}\d{4}";
            Match mt = Regex.Match(str, pattern);
            foreach (Group g in mt.Groups)
            {
                MessageBox.Show(g.ToString());
            }
        }

        private void URLReader()
        {
            // two things, Regular Exp. plus HttpWebRequest
            string url = tb_input.Text;
            string htmlstr = "";
            List<string> slist = new List<string>();
            StringBuilder buider = new StringBuilder();

            try
            {
                HttpWebRequest httpwebrequest = (HttpWebRequest)WebRequest.Create(url);
                WebRequest webrequest = (WebRequest)httpwebrequest;
                webrequest.Proxy = null;
                WebResponse wr = webrequest.GetResponse();
                StreamReader sr = new StreamReader(wr.GetResponseStream());
                htmlstr = sr.ReadToEnd();
            }
            catch
            {
            }

            string pattern = "(?<=<a href=('|\")).*?(?=('|\")>(.|\\n)*?</a>)";
            MatchCollection mtc = Regex.Matches(htmlstr, pattern);

            foreach (Match mt in mtc)
            {
                buider.AppendLine(mt.ToString());
            }

            tb_output.Text = buider.ToString();
        }

        #endregion

        #region WPF
        private void CB_wpf_DropDownClosed(object sender, EventArgs e)
        {
            if (CB_wpf.Text.Equals("Keydown"))
            {
                WPFClass.Keydown kf = new WPFClass.Keydown();
                kf.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("MouseOver"))
            {
                WPFClass.MouseOverWindow mf = new WPFClass.MouseOverWindow();
                mf.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("CodeOnly"))
            {
                WPFClass.CodeOnly.Window1 window = new WPFClass.CodeOnly.Window1();
                window.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Ex XAML"))
            {
                WPFClass.ExXaml.WindowMain window = new WPFClass.ExXaml.WindowMain();
                window.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Content Element"))
            {
                WPFClass.ContentElement.Window1 window = new WPFClass.ContentElement.Window1();
                window.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Area Element"))
            {
                WPFClass.DataBinding window = new WPFClass.DataBinding();
                window.Owner = this;
                window.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Resource"))
            {
                WPFClass.Resource window = new WPFClass.Resource();
                window.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Trigger"))
            {
                WPFClass.Trigger win = new WPFClass.Trigger();
                win.ShowDialog();
            }
            else if (CB_wpf.Text.Equals("Visual Object"))
            {
                WPFClass.VisualObject win = new WPFClass.VisualObject();
                win.ShowDialog();
            }
        }


        #endregion

        #region Excel/Stream
        private void cb_excel_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = cb_excel.Text;
            if (cbstr.Equals("ExcelReader"))
            {
                ExcelRead();
            }
            else if (cbstr.Equals("ExcelWriter"))
            {
                ExcelWrite();
                MessageBox.Show("Fertig");
            }
            else if (cbstr.Equals("StreamReader"))
            {
                StreamRead();
                MessageBox.Show("Fertig");
            }
            else if (cbstr.Equals("StreamWriter"))
            {
                StreamWrite();
                MessageBox.Show("Fertig");
            }
        }

        private void ExcelRead()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != true)
            {
                return;
            }
            IWorkbook wk = new XSSFWorkbook(open.FileName);
            ISheet sheet = wk.GetSheetAt(0);
            for (int r = 0; r <= sheet.LastRowNum; r++)
            {
                IRow row = sheet.GetRow(r);
                for (int c = 0; c <= row.LastCellNum; c++)
                {
                    ICell cell = row.GetCell(c);
                    MessageBox.Show(string.Format("Row: {0} Cell:{1} ", r, cell.StringCellValue));
                }

            }

        }

        private void ExcelWrite()
        {
            //set values , set formula, and save the data
            string path = @"E:\test.xlsx";

            IWorkbook wk = new XSSFWorkbook();
            ISheet sheet = wk.CreateSheet("test");
            for (int r = 0; r < 5; r++)
            {
                IRow row = sheet.CreateRow(r);
                for (int c = 0; c < 5; c++)
                {
                    ICell cell = row.CreateCell(c);
                    cell.SetCellValue(c + r);
                }
                ICell cell1 = row.CreateCell(5);
                cell1.SetCellFormula("=SUM(A1:E1)");
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                wk.Write(fs);
            }

        }

        private void StreamRead()
        {
            OpenFileDialog open = new OpenFileDialog();
            string str = "";

            open.Filter = "Excel (*.xlsx)| *.xlsx | Text (*.txt)|*.txt";
            if (open.ShowDialog() == false)
                return;
            using (StreamReader sr = new StreamReader(open.FileName, Encoding.Default, false, 1024))
            {
                while (sr.EndOfStream)
                {
                    str += sr.ReadLine();
                }
            }
            tb_output.Text = str;
        }

        private void StreamWrite()
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() != true)
            { return; }
            string path = save.FileName;
            string str = tb_input.Text;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                fs.Write(Encoding.Default.GetBytes(str), 0, 1024);
            }
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default, 1024))
            {
                sw.Write(str.ToCharArray());
                sw.Flush();
            }
        }

        #endregion

        #region sql

        /// <summary>
        /// With Ado.Net Data Load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cb_sql_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = cb_sql.Text;
            if (cbstr.Equals("Select All"))
            {
                SQLA();
            }
            else if (cbstr.Equals("Insert"))
            {
                SQLInsert();
                MessageBox.Show("fertig");
            }
            else if (cbstr.Equals("Update"))
            {
                SqlUpdate();
                MessageBox.Show("fertig");
            }

        }


        private void SQLA()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            string result = "";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from aaa";
                    SqlDataReader sr = cmd.ExecuteReader();
                    while (!sr.HasRows)
                    {
                        result += sr[0];
                    }
                }
            }
        }

        private void SQLInsert()
        {
            const int CourseID = 5000;
            const string title = "PV Storage";
            const int Credit = 4;
            const int DpID = 7;

            // Insert into DB
            #region Solution
            //string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //using (SqlConnection conn = new SqlConnection(connstr))
            //{
            //    conn.Open();
            //    StringBuilder cmdstrBuider = new StringBuilder();
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.Connection = conn;
            //        cmdstrBuider.Append("insert into Course (CourseID,Title,Credits,DepartmentID) values (@CourseID,@Title,@Credits,@DepartmentID)");
            //        cmd.CommandText = cmdstrBuider.ToString();
            //        SqlParameter[] plist = new SqlParameter[] {new SqlParameter("@CourseID", SqlDbType.Int){ Value =CourseID },
            //            new SqlParameter("@Title",title), new SqlParameter("@Credits", SqlDbType.Int){ Value = Credit},
            //            new SqlParameter("@DepartmentID",SqlDbType.Int){ Value = DpID} };

            //        cmd.Parameters.AddRange(plist);
            //        cmd.ExecuteNonQuery();
            //    }
            //} 
            #endregion

            string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string cmdstr = "insert into Course (CourseID, Credit, DepartmentID) values (@CourseID, @Credit, @DepartmentID)";
                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                    SqlParameter[] pars = new SqlParameter[] {
                        new SqlParameter("@CourseID",SqlDbType.Int){  Value= CourseID },
                        new SqlParameter("@Credit",SqlDbType.Int){ Value = Credit},
                        new SqlParameter("@DepartmentID",SqlDbType.Int){ Value = DpID}
                    };
                    cmd.Parameters.AddRange(pars);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void SqlUpdate()
        {
            string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                StringBuilder cmdbuider = new StringBuilder();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmdbuider.Append("Update Course set Title = @title where CourseID = @courseID");
                    cmd.CommandText = cmdbuider.ToString();

                    cmd.Parameters.AddRange(new SqlParameter[]{ new SqlParameter("@title", SqlDbType.NVarChar, 60) { Value = "Photovotaic" },
                                             new SqlParameter("@courseID", SqlDbType.Int) { Value = 5000 } });
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private void btn_delegate_Click(object sender, RoutedEventArgs e)
        {
            InfoTrans iw = new InfoTrans();
            iw.Show();
        }

        private void btn_Thread_Click(object sender, RoutedEventArgs e)
        {
            ThreadWindow tw = new ThreadWindow();
            tw.ShowDialog();
        }

        private void cb_anorders_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = cb_anorders.Text;
            if (cbstr.Equals("Socket"))
            {
                SocketServer sw = new SocketServer();
                sw.Show();
            }
            else if (cbstr.Equals("WPF"))
            {
                WPFFunctions wf = new WPFFunctions();
                wf.ShowDialog();
            }
        }
        #endregion

        #region Grundelage
        private void cb_Grundlage_DropDownClosed(object sender, EventArgs e)
        {
            if (cb_Grundlage.Text.Equals("Access modifier"))
            {

            }
            else if (cb_Grundlage.Text.Equals(""))
            {
                //   BaseThis();
            }
            else if (cb_Grundlage.Text.Equals("virtual method"))
            {
                VirtualMethod();
            }
            else if (cb_Grundlage.Text.Equals("Exception Handle"))
            {
                ExceptionHandler();
            }
            else if (cb_Grundlage.Text.Equals("Klasse Sort"))
            {
                KlasseSort();
            }
            else if (cb_Grundlage.Text.Equals("Reflector"))
            {
                Reflector();
            }
            else if (cb_Grundlage.Text.Equals("Foreach"))
            {
                tb_output.Text = ForeachContent();
            }
        }

        #region Reflector
        private void Reflector()
        {
            //Load Assembly
            string path = @"C:\Users\g.he\Documents\CSharp\Git\LinqFunctions\LinqFunctions\PersonClass.dll";

            #region Solution
            ////Create Assembly
            //Assembly asm = Assembly.LoadFile(path);

            ////Get Types
            //Type[] types = asm.GetTypes();

            ////Get one type
            //Type typePerson = asm.GetType("PersonClass.Person");

            ////Get Method
            //MethodInfo method = typePerson.GetMethod("SayHi", new Type[] { });

            ////Create Instanze
            //object obj = Activator.CreateInstance(typePerson);

            ////Method Invoke
            //method.Invoke(obj, null);

            ////Get Method with parameter
            //MethodInfo method1 = typePerson.GetMethod("SayHi", new Type[] { typeof(string) });
            //method1.Invoke(obj, new object[] { "aaa" });

            ////Get Construtor
            //ConstructorInfo construtor = typePerson.GetConstructor(new Type[] { typeof(string) });

            ////Instanze with Construtor
            //object obj1 = construtor.Invoke(new object[] { "bbb" });

            ////Get Properties
            //PropertyInfo property = typePerson.GetProperty("Name");
            //string name = property.GetValue(obj1, null).ToString();

            ////entscheiden, ob Reference accept
            //Type typeFather = typeof(Father);
            //Type typeSon = typeof(Son);
            //bool b = typeFather.IsAssignableFrom(typeSon);

            ////Is Instance
            //b = typeFather.IsInstanceOfType(obj);

            ////Is subClass
            //b = typeSon.IsSubclassOf(typeFather);

            ////Get Private Method
            //Type typePerson1 = typeof(Person);
            //MethodInfo privatemethod = typePerson1.GetMethod("SayHi", BindingFlags.NonPublic | BindingFlags.Instance);
            //privatemethod.Invoke(Activator.CreateInstance(typePerson1), null);
            #endregion
            Assembly asm = Assembly.LoadFile(path);

            //Get types
            Type[] types = asm.GetTypes();

            //Get Public Type
            Type[] publicTypes = asm.GetExportedTypes();

            //Get type
            Type typePerson = asm.GetType("PersionClass.Person");

            //Get Method
            MethodInfo method = typePerson.GetMethod("SayHi", new Type[] { });

            //Get Method with parameter
            MethodInfo Method1 = typePerson.GetMethod("SayHi", new Type[] { typeof(string) });

            //Create Instance
            object obj = Activator.CreateInstance(typePerson);

            //Get Construtor
            ConstructorInfo construtor = typePerson.GetConstructor(new Type[] { typeof(string) });

            //Get Instance
            object obj1 = construtor.Invoke(new object[] { "Lithum" });

            //Invoke method
            Method1.Invoke(obj1, new object[] { "SMA" });

            //Get Property
            string name = typePerson.GetProperty("Name").ToString();

            //Is Assignable From
            Type typeFather = typeof(Father);
            bool b1 = typeFather.IsAssignableFrom(typeof(Son));

            //Is Instance
            bool b2 = typePerson.IsInstanceOfType(obj1);

            //Is subClass
            bool b3 = typePerson.IsSubclassOf(typeof(object));

            //Get private Method
            MethodInfo privateinfo = typePerson.GetMethod("SayA", BindingFlags.NonPublic | BindingFlags.Instance);

        }
        #endregion

        #region Enum
        public string SeeEnum()
        {
            string result = (charator.Lithum | charator.Lead).ToString();

            return result;
        }

        [Flags]
        public enum charator
        {
            Lithum = 1,
            Lead = 2,
            Ion = 4
        }
        #endregion

        #region Extention Method
        #region Solution
        //public static class stringExtrention
        //{
        //    public static bool isEmail(this String str)
        //    {
        //        return true;
        //    }

        //}  
        #endregion

        //public static class PersonExtention
        //{
        //    public static bool isEail(this Person p)
        //    {
        //        return false;
        //    }
        //}
        #endregion

        #region Access Modifier
        public class MyClass
        {
            //public
            //protected internal
            //protected
            //internal
            //private

            // intern Class Access
            private int num = 0;

            // intern Sub Class auch Access
            protected int num1 = 0;

            // in dieselbem Programm
            internal int num2 = 100;

            // internal und protected beide access
            protected internal int num3 = 1000;

            // anywhere access
            public int num4 = 1000;

            //operator
            #region Operator
            #region Solution
            //public static bool operator ==(MainWindow.MyClass a, MainWindow.MyClass b)
            //{
            //    if (a.num4 == b.num4)
            //    { return true; }
            //    return false;
            //}

            //public static bool operator !=(MyClass a, MyClass b)
            //{ return false; } 
            #endregion

            public static bool operator ==(MyClass a, MyClass b)
            {
                return true;
            }
            public static bool operator !=(MyClass a, MyClass b)
            {
                return false;
            }
            #endregion
        }
        #endregion

        #region BaseThis
        public class Father
        {
            public string Nachname { get; set; }
            public int Age { get; set; }
            public Father(string n, int a)
            {
                Nachname = n;
                Age = a;
            }
        }

        public class Son : Father
        {
            public Son(string n, int a) : base(n, a)
            { }
        }

        #endregion

        #region Sort Compare

        public void KlasseSort()
        {
            ArrayList list = new ArrayList();
            list.Add(new Klasse("aaa", 30));
            list.Add(new Klasse("ccc", 20));
            list.Add(new Klasse("bbb", 10));
            list.Sort();

            foreach (Klasse k in list)
            {
                tb_input.Text += k.name;
            }

            tb_input.Text += "/r/n";

            IComparer comparer = new KlasseComparer();
            list.Sort(comparer);

            foreach (Klasse k in list)
            {
                tb_input.Text += k.name;
            }
        }

        #region Solution
        ////1. Mit IComparable
        //public class Klasse : IComparable
        //{
        //    public string Name { get; set; }
        //    public int Con { get; set; }
        //    public Klasse(string n, int c)
        //    {
        //        Name = n;
        //        Con = c;
        //    }

        //    public int CompareTo(object obj)
        //    {
        //        return this.Con - ((Klasse)obj).Con;
        //    }
        //}

        ////2. Mit IComparer
        //public class KlassComparer : IComparer
        //{
        //    public int Compare(object x, object y)
        //    {
        //        return (x as Klasse).Name[0] - (y as Klasse).Name[0];
        //    }
        //} 
        #endregion

        public class Klasse : IComparable
        {
            public string name;
            public int num;
            public Klasse(string n, int c)
            {
                name = n; num = c;
            }

            public int CompareTo(object obj)
            {
                return name[0] - ((Klasse)obj).name[0];
            }
        }

        public class KlasseComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (x as Klasse).num - (y as Klasse).num;
            }
        }

        #endregion

        #region vitual method and WeakReference

        private void VirtualMethod()
        {
            Person[] p = new Person[2];
            p[0] = new Chinese();
            p[1] = new American();

            foreach (var ps in p)
            {
                tb_output.Text += ps.SayNationality();
            }

            // WeakReference
            #region WeakReference Solution
            //WeakReference wk = new WeakReference(p);
            //p = null;

            //if (wk.IsAlive)
            //{
            //    object obj = wk.Target;
            //    if (obj != null)
            //    {
            //        Person p1 = obj as Person;
            //    }
            //}    
            #endregion
            WeakReference wk = new WeakReference(p);
            p = null;
            if (wk.IsAlive)
            {
                object obj = wk.Target;
                p = obj as Person[];
            }
        }

        #region Solution
        //public class Person
        //{
        //    public virtual string SayNationality()
        //    {
        //        return "I come from..";
        //    }
        //}

        //public class Chinese : Person
        //{
        //    public override string SayNationality()
        //    {
        //        return "China";
        //    }
        //}

        //public class American : Person
        //{
        //    public override string SayNationality()
        //    {
        //        return "USA";
        //    }
        //} 
        #endregion

        public class Person
        {
            public virtual string SayNationality()
            {
                return "";
            }
        }

        public class Chinese : Person
        {
            public override string SayNationality()
            {
                return "c";
            }
        }

        public class American : Person
        {
            public override string SayNationality()
            {
                return "a";
            }
        }

        #endregion

        #region AbstractClass
        abstract class Animal
        {
            public string Name { get; set; }
            public abstract void SayHi();
        }

        class Cat : Animal
        {
            public override void SayHi()
            {
                MessageBox.Show("Cat");
            }
        }

        #endregion

        #region TryParse
        public int ParseTryParse(string numstr)
        {
            int result;
            result = int.Parse(numstr);

            if (int.TryParse(numstr, out result)) MessageBox.Show("erfolg");

            return result;
        }

        #endregion

        #region Exception
        private void ExceptionHandler()
        {
            int i = 1, j = 0;
            try
            {
                int r = i / j;
            }
            catch (NullReferenceException ex) { }
            catch (DivideByZeroException ex) { }
            catch (ArgumentException ex) {
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

        }
        #endregion

        #region Foreach
        private string ForeachContent()
        {
            string result = "";
            foreach (string item in new EnumClass())
            {
                result += item + " ";
            }
            return result;
        }

        #region Method 1
        //public class EnumClass:IEnumerable
        //{
        //    string[] NameList = new string[] { "SMA", "Solarwatt", "Sonnen" };
        //    public string this[int index]
        //    {
        //        get
        //        {
        //            return NameList[index];
        //        }

        //        set
        //        {
        //            NameList[index] = value;
        //        }
        //    }

        //    public IEnumerator GetEnumerator()
        //    {
        //        return new ClassEnumerator(NameList);
        //    }
        //}

        //public class ClassEnumerator : IEnumerator
        //{
        //    string[] _namelist;
        //    public ClassEnumerator(string[] NameList)
        //    {
        //        _namelist = NameList;
        //    }
        //    private int index=-1;

        //    public object Current
        //    {
        //        get
        //        {
        //            if (index < -1 || index > _namelist.Length - 1) return null;
        //            return _namelist[index];
        //        }
        //    }

        //    public bool MoveNext()
        //    {
        //        if (index < -1 || index > _namelist.Length-1) return false;
        //        index++;
        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        index = -1;
        //    }
        //} 
        #endregion

        #region Method 2
        //public class EnumClass
        //{
        //    string[] NameList = new string[] { "SMA", "Solarwatt", "Sonnen" };
        //    public string this[int index]
        //    {
        //        get
        //        {
        //            return NameList[index];
        //        }

        //        set
        //        {
        //            NameList[index] = value;
        //        }
        //    }
        //    public IEnumerable GetEnumerable()
        //    {
        //        for (int i = 0; i < NameList.Length - 1; i++)
        //        {
        //            yield return NameList[i];
        //        }
        //    }
        //} 
        #endregion

        #region Method 3
        public class EnumClass
        {
            string[] NameList = new string[] { "SMA", "Solarwatt", "Sonnen" };
            public string this[int index]
            {
                get
                {
                    return NameList[index];
                }

                set
                {
                    NameList[index] = value;
                }
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < NameList.Length; i++)
                {
                    yield return NameList[i];
                }
            }
        } 
        #endregion
    }
    #endregion

        #region Genetic
        public class GeneticClass<T, K, V, X, Y, Z>
        where T : struct
        where K : class
        where V : IComparable
        where X : K
        where Y : class, new()
        { } 
    #endregion
    #endregion
}
