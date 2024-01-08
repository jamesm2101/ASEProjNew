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
        /// Test method for an invalid parameter
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InvalidParameter() 
        { 
            Canvas canvas = new Canvas();
            //Arrange
            int ValidParam = 200;
            int InvalidParam = -500; // Set the radius to an invalid parameter

            //Act and Assert (via Exception)
            canvas.DrawRectangle(ValidParam,InvalidParam); //Try draw the rectangle with one Invalid parameter
        }

        /// <summary>
        /// Test Method for checking valid coordinates when moving to
        /// </summary>
        [TestMethod]
        public void ValidMoveToCoordinates()
        {
            //Arrange
            Canvas canvas = new Canvas();

            int ValidX = 300; //Setting a valid x and y based on the graphics 400,400 axis
            int ValidY = 300;

            //Act
            canvas.moveto(ValidX, ValidY); //Moving to the set coordinates

            //Assert
            Assert.AreEqual(ValidX, canvas.xPos); //Comparing between the set coordinates and the used ones to check if they are the same
            Assert.AreEqual(ValidY, canvas.yPos);
        }

        /// <summary>
        /// Test method for checking invalid moveto coordinates
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InValidMoveToCoordinates() 
        {
            Canvas canvas = new Canvas();

            //Arrange
            int InValidX = -200; //Setting a valid x and y based on graphics 400,400 axis
            int InValidY = -200;

            //Act and Assert
            canvas.moveto(InValidX, InValidY); //Moveto the invalid coordinates
            Assert.AreNotEqual(InValidX, canvas.xPos); //Check that the invalid coordinates are not equal to where the cursor is
            Assert.AreNotEqual(InValidY, canvas.yPos);
        }

        /// <summary>
        /// Test method for InValid drawto coordinates
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InValidDrawToCoordinates()
        {
            Canvas canvas = new Canvas();

            //Arrange
            int InValidX = -200; //Set an invalid x and y coordinate
            int InValidY = -200;

            //Act and Assert
            canvas.drawto(InValidX, InValidY); //Try drawto invalid coordinates
            Assert.AreNotEqual(InValidX, canvas.xPos);//Check the invalid coordinates are not equal to where the cursor is
            Assert.AreNotEqual (InValidY, canvas.yPos);
        }

        /// <summary>
        /// Test Method for 
        /// </summary>
        [TestMethod]
        public void InValidClear() 
        {
            Canvas canvas = new Canvas();

            //Arrange
            int DrawToX = 100; // Set an x and y to draw to
            int DrawToY = 100;

            //Act and Assert
            {
                canvas.drawto(DrawToX, DrawToY); //Draw to the coordinates
                canvas.Clear(); //Clear the page
                canvas.drawto(DrawToX, DrawToY);
            }
            Assert.AreEqual(DrawToX,canvas.xPos); //Check that the coordinates are still the same to where was drawn to
            Assert.AreEqual(DrawToY,canvas.yPos);
        }

        /// <summary>
        /// Test Method for checking the Reset Method
        /// </summary>
        [TestMethod]
        public void ValidReset() 
        {
            Canvas canvas = new Canvas();

            //Arrange
            int MoveToX = 100; //x and y variables set
            int MoveToY = 100;

            //Act and Assert
            canvas.moveto(MoveToX, MoveToY); //Move to the set coordinates
            canvas.Reset(); //Reset the page
            Assert.AreNotEqual(MoveToX, canvas.xPos); //Make sure that the coordinates do not match
            Assert.AreNotEqual(MoveToY, canvas.yPos);
        }

        /// <summary>
        /// Test method for and invalid radius for the circle
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InValidCircle() 
        {
            Canvas canvas = new Canvas();
            //Arrange
            int Radius = -20; // Set an invalid radius
            //Act and Assert (via Exception)
            canvas.DrawCircle(Radius);
            
        }

        /// <summary>
        /// Test method for an invalid width and height for the rectangle
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InValidRectangle() 
        { 
            Canvas canvas = new Canvas();
            //Arrange
            int InvalidWidth = -30; //Set an invalid width and height
            int InvalidHeight = -30;

            //Act and Assert (via Exception)
            canvas.DrawRectangle(InvalidWidth, InvalidHeight);
        }

        /// <summary>
        /// Test method for an invalid width and height for the triangle
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InValidTriangle()
        {
            Canvas canvas = new Canvas();
            //Arrange
            int InvalidWidth = -30; // Set an invalid width and height
            int InvalidHeight = -30;

            //Act and Assert (via Exception)
            canvas.DrawTriangle(InvalidWidth, InvalidHeight);
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