using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqFunctions;

namespace LinqFunctionsTests
{
    [TestClass]
    public class StorageTest
    {
        [TestMethod]
        public void ToStringNormolTest()
        {
            Storage st = new Storage(1, "aaa", 1);

            string expected = "aaa";
            string actual = st.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringNullTest()
        {
            Storage st = new Storage(1, string.Empty, 1);

            string expected = string.Empty;
            string actual = st.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
