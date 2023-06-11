using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace TestProject2
{
    [TestClass]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class UnitTest1
    {
        [AllureTag("Add_ShouldReturnCorrectSum")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureSubSuite("DataProvider")]
        [TestMethod]
        [DataTestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(0, 0, 0)]
        [DataRow(-1, 1, 0)]
        public void Add_ShouldReturnCorrectSum(int a, int b, int expectedSum)
        {
            int sum = Add(a, b);

            Assert.AreEqual(expectedSum, sum);
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}