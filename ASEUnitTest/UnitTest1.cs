using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASEProjNew;

namespace ASEUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Run_WhenCompleteCommandBoxIsInvalid_ShouldThrowException()
        {
            //Arrange
            Form1 form1 = new Form1();
            string completelines = "";
         
            //Act and assert
            Assert.ThrowsException<ArgumentException>(() => { });
        }
    }
}