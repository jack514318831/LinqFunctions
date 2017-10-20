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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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
        }

        private void CreateXML()
        {
            List<ModelEmployee> list = EmployeeListBuider.Buil();

            XElement result = new XElement("Employees", from emp in list
                                                        orderby emp.Salary
                                                        select new XElement("Employee",
                                                            new XAttribute("ID", emp.EmpployeeID),
                                                            new XAttribute("Sal", emp.Salary),
                                                            new XElement("Department", new XAttribute("ID", emp.DepartmentID))
                                                            )
                                            );


            result.Save(@"E:\Test.xml");
        }

        private void ReadXML(string path)
        {
            XDocument xdoc = XDocument.Load(@"E:\countries.xml");

            var result = from country in xdoc.Descendants().Elements("country")
                         from city in country.Elements("city")
                         orderby city.Value.First()
                         select new {
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
            string result = string.Format(CultureInfo.CreateSpecificCulture("en-US"),"{0,-10}{1,10}{2,10:C1}", date, "OK",88.12);
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
            string input= "hi Hellow HI world hellow world world hi hi";

            var result = from word in input.Split(' ')
                         let w = word.ToLower()
                         where w.Length > 4
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
                             num = words.Count()
                         };

            DG_Data.ItemsSource = result;
        }

        private void stringD(string str)
        {
            // Find the Max Length of the substring of inputString
            string s = str;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int max = 0;
            for (int i = 0, j = 0; i < s.Length; i++)
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

#region LinqToArray
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
           

        }

        private void ArrayA()
        {
            string[] ary = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            Func<string, bool> withfirst = s => s.First() == 'J';
            var result = ary.Where(withfirst);

            DG_Data.ItemsSource = result;
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
                         where w.First() == 't'
                         select word;

            DG_Data.ItemsSource = result;

        }

        private void ArrayD()
        {

            IList col = new ArrayList();
            col.Add("one");
            col.Add(1);
            col.Add(1.1);

            var result = col.OfType<string>();

            foreach (var s in result)
            {
                MessageBox.Show(s.ToString());
            }       
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

            var result = source.Where<int>((num)=>{
                if (num <= 7 && num >= 3)
                { return true; }
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

            var result = elist.OrderByDescending(emp => emp.EmpployeeID).ThenBy<ModelEmployee, int>(emp => emp.Salary);
           
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

            var result2 = strList.SkipWhile(s => s.Length > 4);

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

            var result = eList.Aggregate<ModelEmployee, string, string>(string.Empty, (str, s) => str += s + ",", s => s.Substring(0, s.Length - 1));

            MessageBox.Show(result);
        }
#endregion

#region LinqToDataset
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
        }

        private DataSet CreateDS()
        {
            List<ModelDepartment> dlist = EmployeeListBuider.DepartmentBuild();
            List<ModelEmployee> elist = EmployeeListBuider.Buil();
            DataTable dtd = new DataTable();
            DataTable dte = new DataTable();
            DataSet ds = new DataSet();

            dtd.Columns.Add(new DataColumn("DID", System.Type.GetType("System.String")));
            dtd.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));

            dte.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
            dte.Columns.Add(new DataColumn("DID", System.Type.GetType("System.String")));
            dte.Columns.Add(new DataColumn("Sal", System.Type.GetType("System.Int32")));

            foreach (var emp in elist)
            {
                DataRow row = dte.NewRow();
                row[0] = emp.EmpployeeID;
                row[1] = emp.DepartmentID;
                row[2] = emp.Salary;
                dte.Rows.Add(row);
            }

            foreach (var dp in dlist)
            {
                DataRow row = dtd.NewRow();
                row[0] = dp.DepartmentID;
                row[1] = dp.DepartmentName;
                dte.Rows.Add(row);
            }

            dtd.TableName = "Department";
            dte.TableName = "Emp";
            ds.Tables.Add(dtd);
            ds.Tables.Add(dte);

            return ds;
        }

        private void LinqToDataSet()
        {
            DataSet ds = CreateDS();

            var result = from emp in ds.Tables["Emp"].AsEnumerable()
                         join dp in ds.Tables["Department"].AsEnumerable() on emp.Field<string>("DID") equals dp.Field<string>("DID")
                         select new
                         {
                             dp = dp.Field<string>("Name"),
                             emp = emp.Field<string>("ID")
                         };

            DG_Data.ItemsSource = result;
           
        }
#endregion

#region LinqJoin
        private void CB_join_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_join.Text;
            if (cbstr.Equals("Innen Join"))
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
                         join s in slist on m.MarkeID equals s.MarkeID into sgroup
                         from item in sgroup.DefaultIfEmpty(new Storage(0, "", 0))
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
                         join m in mlist on s.MarkeID equals m.MarkeID into marks
                         from item in marks.DefaultIfEmpty()
                         select new
                         {
                             mark = item != null ? item.Name : "",
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
                         select new {
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

#region regularExp
        private void CB_Regex_DropDownClosed(object sender, EventArgs e)
        {
            string cbstr = CB_Regex.Text;
            if (cbstr.Equals("Card Number"))
            {
                CardNumber();
            }
            else if (cbstr.Equals("Url Reader"))
            {
                URLReader();
            }

        }

        private void CardNumber()
        {
            string str = "hier ist a card num : 4444-3333-2222-1111";

            string pattern = @"(\d{4}[ ,-]){3}\d{4}";
            Regex reg = new Regex(pattern);

            Match mt = reg.Match(str);
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
                WebResponse webresponse = webrequest.GetResponse();
                StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                htmlstr = sr.ReadToEnd();
            }
            catch
            {
            }

            string pattern = "(?<=<a href=(\"|')).*?(?=(\"|')>(.|\n)*?</a>)";
            Regex reg = new Regex(pattern);
            MatchCollection mtc = reg.Matches(htmlstr);

            foreach (Match mt in mtc)
            {
                buider.AppendLine().Append(mt.ToString());
            }

            tb_output.Text = buider.ToString();
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
            ISheet sheet = wk.CreateSheet();

            for (int r = 0; r <= 5; r++)
            {
                IRow row = sheet.CreateRow(r);
                for (int c = 0; c <= 5; c++)
                {
                    ICell cell = row.CreateCell(c);
                    cell.SetCellValue(c);
                }
                ICell cell2 = row.CreateCell(6);
                cell2.SetCellFormula ("SUM(A"+(r+1).ToString()+":E"+(r+1).ToString()+")");
            }
            
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            wk.Write(fs);
            fs.Close();
        }

        private void StreamRead()
        {
            OpenFileDialog open = new OpenFileDialog();
            string str = "";
            open.Filter = "Excel (*|xlsx)|*.xlsx| Txt (*|txt)|*.txt";

            if (open.ShowDialog() != true)
            { return; }
            StreamReader sr = new StreamReader(open.FileName, Encoding.Default, false, 1024);
            while (!sr.EndOfStream)
            {
                str += sr.ReadLine();
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

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(Encoding.Default.GetBytes(str), 0, 1024);
            }

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
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
            string connstr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                StringBuilder cmdstrBuider = new StringBuilder();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmdstrBuider.Append("insert into Course (CourseID,Title,Credits,DepartmentID) values (@CourseID,@Title,@Credits,@DepartmentID)");
                    cmd.CommandText = cmdstrBuider.ToString();
                    SqlParameter[] plist = new SqlParameter[] {new SqlParameter("@CourseID", SqlDbType.Int){ Value =CourseID },
                        new SqlParameter("@Title",title), new SqlParameter("@Credits", SqlDbType.Int){ Value = Credit},
                        new SqlParameter("@DepartmentID",SqlDbType.Int){ Value = DpID} };

                    cmd.Parameters.AddRange(plist);
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

    }
#endregion
}
