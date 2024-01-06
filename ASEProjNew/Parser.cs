using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection.Metadata;


namespace ASEProjNew
{
    /// <summary>
    /// Collection of the commands through the textbox for command lines
    /// </summary>
    public class Parser:Form1
    {
        private Canvas myCanvas;

        private HashSet<string> commands = new HashSet<string>
        {
            "moveto", "drawto", "clear", "reset", "circle", "rectangle", "triangle", "fill", "colour"
        };

        //Dictionary for variables
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        public Parser(Canvas canvas)
        {
            myCanvas = canvas;
        }
        private string ExecuteCommand(string commandLine, Dictionary<string, int> variables, int lineNumber)
        {
            string[] split = commandLine.Split(new[] { ' ' }, 2);
            if (split.Length == 0)
                throw new Exception("Enter a command");

            string command = split[0].ToLower();
            string parameters = split.Length > 1 ? split[1] : null;

            if (!commands.Contains(command))
                throw new Exception("Enter a valid command");

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
                            return $"'{command}' needs a parameter following it";

                        string[] connectedparams = split[1].Split(' ');
                        int[] paraminteger = ParseParamNumbers(connectedparams, command, lineNumber, variables);
                        ExecuteCommandParams(command, paraminteger);
                        break;

                    case "reset":
                    case "clear":
                    case "red":

                        if (command.Equals("reset"))
                            myCanvas.Reset();
                            myCanvas.UpdateCursor();
                        if (command.Equals("clear"))
                            myCanvas.Clear();
                        if (command.Equals("red"))
                            myCanvas.ColourRed();
                        break;

                    case "fill":
                        if (split.Length != 2)
                            return $"{command} expects one parameter";

                        if (command.Equals("fill"))
                            myCanvas.ShapeFill(split[1]);
                        break;
                }
            }

            catch
            {
                return $"Error executing the command";
            }

            return string.Empty;
           }

        private int[] ParseParamNumbers(string[] connectedparams, string command, int lineNumber, Dictionary<string, int> variables)
        {
            int[] paraminteger = new int[connectedparams.Length];
            for(int i = 0; i < connectedparams.Length; i++)
            {
                if (variables.TryGetValue(connectedparams[i], out int value))
                {
                    paraminteger[i] = value;
                
                }

                else if (!int.TryParse(connectedparams[i], out paraminteger[i]))
                {
                    throw new Exception("Parameter is not an integer");
                }
            }
            return paraminteger;
        }

        private void ExecuteCommandParams(string command, int[] paraminteger)
        {
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
                        throw new Exception("You need one parameters for this command");
                    myCanvas.Circle(paraminteger[0]);
                    break;

                case "rectangle":
                    if (paraminteger.Length != 2)
                        throw new Exception("You need two parameters for this command");
                    myCanvas.Rectangle(paraminteger[0], paraminteger[1]);
                    break;

                case "triangle":
                    if (paraminteger.Length != 3)
                        throw new Exception("You need three parameters for this command");
                    myCanvas.Triangle(paraminteger[0], paraminteger[1], paraminteger[2]);
                    break;

                case "colour":
                    if (paraminteger.Length != 3)
                        throw new Exception("You need three parameters for this command");
                    myCanvas.SetColour(paraminteger[0], paraminteger[1], paraminteger[2]);
                    break; 
            }
        }

        }
        
        

                  
}

