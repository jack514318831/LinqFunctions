using System.Collections.Generic;

namespace LinqFunctions
{
    public class Storage
    {
        public int StorageID { get; set;}
        public string Name { get; set; }
        public int MarkeID { get; set; }

        public Storage(int sid, string name, int mid)
        {
            StorageID = sid;
            Name = name;
            MarkeID = mid;
        }

        public static List<Storage> Build()
        {
            List<Storage> list = new List<Storage>();

            list.Add(new Storage(1, "LG Chem", 1));
            list.Add(new Storage(2, "LG ESS", 1));
            list.Add(new Storage(3, "Varta Family", 2));
            list.Add(new Storage(4, "Varta Egion", 2));
            list.Add(new Storage(5, "Senec Lithum", 3));
            list.Add(new Storage(6, "eco 4", 4));
            list.Add(new Storage(7, "eco 6", 4));
            list.Add(new Storage(8, "eco 8", 4));
            list.Add(new Storage(9, "Powerwall", 6));

            return (list);
        }

        public override string ToString()
        {
            return this.Name;
        }

    }

    public class Marke
    {
        public int MarkeID;
        public string Name;

        public Marke(int mid, string name)
        {
            MarkeID = mid;
            Name = name;
        }

        public static List<Marke> Build()
        {
            List<Marke> list = new List<Marke>();

            list.Add(new Marke(1, "LG"));
            list.Add(new Marke(2, "Varta"));
            list.Add(new Marke(3, "Senec"));
            list.Add(new Marke(4, "Sonnen"));
            list.Add(new Marke(5, "Samsung"));

            return (list);
        }
    }

}
