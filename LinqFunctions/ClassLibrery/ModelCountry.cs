namespace LinqFunctions
{
    public class ModelCountry
    {
        public string countryname { get; set; }
        public string cityname { get; set; }

        public ModelCountry(string cn, string cityn)
        {
            countryname = cn;
            cityname = cityn;
        }
    }
}
