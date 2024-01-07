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
            string input = "movto";

            //Act and assert
            bool containsCommand = textBox.ContainsCommand(input, "moveto");
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
            string input = "moveto";

            //Act and assert
            bool containsCommand = textBox.ContainsCommand(input, "moveto");
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

        /// <summary>
        /// Test Method for checking valid coordinates when moving to
        /// </summary>
        [TestMethod]
        public void ValidMoveToCoordinates()
        {
            //Arrange
            Canvas canvas = new Canvas();

            int ValidX = 300; //Setting a valid x and y based on the graphics 400,400
            int ValidY = 300;

            //Act
            canvas.moveto(ValidX, ValidY); //Moving to the set coordinates

            //Assert
            Assert.AreEqual(ValidX, canvas.xPos); //Comparing between the set coordinates and the used ones to check if they are the same
            Assert.AreEqual(ValidY, canvas.yPos);
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