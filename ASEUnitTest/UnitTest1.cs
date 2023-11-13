using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASEProjNew;
using System.Windows.Forms;

namespace ASEUnitTest
{
    /// <summary>
    /// Test Class to hold all tests
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Recognises when the textbox does not include a selected command
        /// </summary>
        [TestMethod]
        public void RecogniseWhenTextBoxDoesNotIncludeCommand()
        {
            //Arrange
            TextBox textBox = new TextBox();
            string input = "movTo";

            //Act and assert
            bool containsCommand = textBox.ContainsCommand(input, "moveTo");
            Assert.IsFalse(containsCommand);
        }

        /// <summary>
        /// Recognises when the textbox does include a selected command
        /// </summary>
        [TestMethod]
        public void RecogniseWhenTextBoxContainsCommand()
        {
            //Arrange
            TextBox textBox = new TextBox();
            string input = "moveTo";

            //Act and assert
            bool containsCommand = textBox.ContainsCommand(input, "moveTo");
            Assert.IsTrue(containsCommand);
        }

        /// <summary>
        /// Recognises when TextBox includes nothing
        /// </summary>
        [TestMethod]
        public void RecogniseWhenTextBoxIncludesNothing() 
        { 
            //Arrange
            TextBox textBox = new TextBox();
            string input = "";

            //Act and assert
            bool containsCommand = textBox.ContainsCommand(input, "moveTo");
            Assert.IsFalse(containsCommand);
        }
    }

    public class TextBox
    {
        public bool ContainsCommand(string input, string command)
        {
            return input.Contains(command);
        }
    }
}