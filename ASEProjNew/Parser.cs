using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;
using System.IO;

namespace ASEProjNew
{
    /// <summary>
    /// Parser class to help split the commands from the parameters to use elsewhere
    /// </summary>
    public class Parser
    {
        private Canvas myCanvas;

        //Set of valid commands that are available to the user
        private HashSet<string> commands = new HashSet<string>
        {
            "moveto", "drawto", "clear", "reset", "circle", "rectangle", "triangle", "fill", "colour", "red", "green", "blue", "black"
        };

        //Dictionary for variables
        private Dictionary<string, int> variables = new Dictionary<string, int>();
        public Parser(Canvas canvas)
        {
            myCanvas = canvas;
        }

        /// <summary>
        /// Initial stage of splitting the line of command(s) up into separate commands and parameters
        /// </summary>
        /// <param name="commandLine"></param>
        /// <param name="lineNumber"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string ExecuteCommand(string commandLine, int lineNumber,  Dictionary<string, int> variables)
        {
            //Command is split into an array (using spacebar) in the maximum of two separate parts
            string[] split = commandLine.Split(new[] { ' ' }, 2);
            if (split.Length == 0)
                throw new Exception("Enter a command");

            //The command is set as the first part of the array with the parameters following
            string command = split[0].ToLower();
            string? parameters = split.Length > 1 ? split[1] : null;

            if (!commands.Contains(command))
                throw new Exception("Enter a valid command");

            //Split the commands into two sections depending on whether it needs a parameter following (return for syntax)
            try
            {
                switch (command)
                {
                    case "moveto":
                    case "drawto":
                    case "circle":
                    case "rectangle":
                    case "triangle":
                    case "colour":
                        if (parameters == null)
                            return$"This command needs a parameter following it";

                        string[] connectedparams = split[1].Split(' ');
                        int[] paraminteger = ParseParamNumbers(connectedparams, command, lineNumber, variables);
                        ExecuteCommandParams(command, paraminteger);
                        break;

                    case "reset":
                    case "clear":
                    case "red":
                    case "green":
                    case "blue":
                    case "black":
                        if (split.Length > 1)
                            return $"This command does not need any parameters";

                        //Set up the methods depending on which command is entered
                        if (command.Equals("reset"))
                        {
                            myCanvas.Reset();
                            myCanvas.UpdateCursor();
                        }
                        else if (command.Equals("clear"))
                            myCanvas.Clear();
                        else if (command.Equals("red"))
                        {
                            myCanvas.ColourRedPen();
                            myCanvas.UpdateCursor();
                        }
                        else if (command.Equals("green"))
                        {
                            myCanvas.ColourGreenPen();
                            myCanvas.UpdateCursor();
                        }
                        else if (command.Equals("blue"))
                        {
                            myCanvas.ColourBluePen();
                            myCanvas.UpdateCursor();
                        }
                        else if (command.Equals("black"))
                        { 
                            myCanvas.ColourBlackPen();
                            myCanvas.UpdateCursor();
                        }
                        break;

                    case "fill":
                        if (split.Length != 2)
                            return $"This expects one parameter - on or off";

                        if (command.Equals("fill"))
                            myCanvas.ShapeFill(split[1]);
                        break;
                }
            }

            catch
            {
                //If none of the returns of parameters match then a generic one is output
                return $"The syntax for this command is incorrect";
            }

            return string.Empty;
           }

        /// <summary>
        /// ParseCommand will work with ExecuteCommand above to take Parse the user input
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="CurrentLine"></param>
        /// <param name="LineNumber"></param>
        /// <param name="NoExecution"></param>
        /// <returns></returns>
        public string ParseCommand(string[] lines, int CurrentLine, ref int LineNumber, out bool NoExecution)
        {
            NoExecution = false;

            //The current line is established as the new line number
            LineNumber = CurrentLine;

            //The current line is then trimmed to remove whitespace
            string line = lines[CurrentLine].Trim();


            //Line is noted as empty
            if (string.IsNullOrWhiteSpace(line))
            {
                return $"Empty command written";
            }

            //Passed through the ExecuteCommand if not
            else
            {
                return ExecuteCommand(line, CurrentLine, variables);
            }

        }

        /// <summary>
        /// Once the command has been separated from the parameter, the parameters needs to be potentially sorted into multiple parameters
        /// </summary>
        /// <param name="connectedparams"></param>
        /// <param name="command"></param>
        /// <param name="lineNumber"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private int[] ParseParamNumbers(string[] connectedparams, string command, int lineNumber, Dictionary<string, int> variables)
        {
            
            int[] paraminteger = new int[connectedparams.Length];

            //Make sure all parameters from the array have been used when the command is called
            for(int i = 0; i < connectedparams.Length; i++)
            {
                if (variables.TryGetValue(connectedparams[i], out int value))
                {
                    paraminteger[i] = value;
                
                }
            
            //Exception thrown if parameter is invalid
                else if (!int.TryParse(connectedparams[i], out paraminteger[i]))
                {
                    throw new Exception("Parameter is not an integer");
                }
            }
            return paraminteger;
        }

        /// <summary>
        /// Ties together each individual command to the correct number of parameters
        /// </summary>
        /// <param name="command"></param>
        /// <param name="paraminteger"></param>
        /// <exception cref="Exception"></exception>
        private void ExecuteCommandParams(string command, int[] paraminteger)
        {

            //Each command is broken up into the necessary amount of parameters
            switch (command)
            {
                case "moveto":
                    if (paraminteger.Length != 2)
                        throw new Exception("You need two parameters for this command");
                    myCanvas.moveto(paraminteger[0], paraminteger[1]);
                    myCanvas.UpdateCursor();
                    break;

                case "drawto":
                    if (paraminteger.Length != 2)
                        throw new Exception("You need two parameters for this command");
                    myCanvas.drawto(paraminteger[0], paraminteger[1]);
                    myCanvas.UpdateCursor();
                    break;

                case "circle":
                    if (paraminteger.Length != 1)
                        throw new Exception("You need one parameter for this command");
                    myCanvas.DrawCircle(paraminteger[0]);
                    break;

                case "rectangle":
                    if (paraminteger.Length != 2)
                        throw new Exception("You need two parameters for this command");
                    myCanvas.DrawRectangle(paraminteger[0], paraminteger[1]);
                    break;

                case "triangle":
                    if (paraminteger.Length != 2)
                        throw new Exception("You need two parameters for this command");
                    myCanvas.DrawTriangle(paraminteger[0], paraminteger[1]);
                    break;

                case "colour":
                    if (paraminteger.Length != 3)
                        throw new Exception("You need three parameters for this command");
                    myCanvas.SetColour(paraminteger[0], paraminteger[1], paraminteger[2]);
                    break; 
            }
        }



        /// <summary>
        /// The main processor part which will tie together all of the parsing to the Form1 and Canvas classes
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public string ProgramProcessor(string process)
        {
            //Process of the lines being split and empty entries removed
            string[] lines = process.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            //Build up a string of any error messages for syntax reasons
            StringBuilder errorstring = new StringBuilder();
            int i = 0;

            //Loop around all of the lines to check and potentially add errors
            while (i < lines.Length)
            {

                int NextLine = i;
                bool NoExecution;

                string result = ParseCommand(lines, i, ref NextLine, out NoExecution);

                if(!string.IsNullOrEmpty(result))
                {
                    errorstring.Append(result);
                }
                if (NoExecution)
                { i = NextLine; }
                else
                { i++; }

            }
            //Turns all of the errors into one string so it is more accessible
            return errorstring.ToString();
        }

        }
        
        

                  
}

