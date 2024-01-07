using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace ASEProjNew
{
    /// <summary>
    /// Collection of the commands through the textbox for command lines
    /// </summary>
    public class Parser
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

        private string ExecuteCommand(string commandLine, int lineNumber,  Dictionary<string, int> variables)
        {
            string[] split = commandLine.Split(new[] { ' ' }, 2);
            if (split.Length == 0)
                throw new Exception("Enter a command");

            string command = split[0].ToLower();
            string? parameters = split.Length > 1 ? split[1] : null;

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
                    case "green":
                    case "blue":
                    case "black":

                        if (command.Equals("reset"))
                            myCanvas.Reset();
                            myCanvas.UpdateCursor();
                        if (command.Equals("clear"))
                            myCanvas.Clear();
                        if (command.Equals("red"))
                            myCanvas.ColourRedPen();
                        if (command.Equals("green"))
                            myCanvas.ColourGreenPen();
                        if (command.Equals("blue"))
                            myCanvas.ColourBluePen();
                        if (command.Equals("black"))
                            myCanvas.ColourBlackPen();
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

        public string ParseCommand(string[] lines, int CurrentLine, ref int LineNumber, out bool NoExecution)
        {
            NoExecution = false;
            LineNumber = CurrentLine;
            string line = lines[CurrentLine].Trim();

            if (string.IsNullOrWhiteSpace(line))
            {
                return $"Empty command written";
            }

            else
            {
                return ExecuteCommand(line, CurrentLine, variables);
            }

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

        public string ProgramProcessor(string process)
        {
            string[] lines = process.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder error = new StringBuilder();
            int i = 0;
            while (i < lines.Length)
            {

                int NextLine = i;
                bool NoExecution;

                string result = ParseCommand(lines, i, ref NextLine, out NoExecution);

                if(!string.IsNullOrEmpty(result))
                {
                    error.Append(result);
                }
                if (NoExecution)
                {
                    i = NextLine;
                }
                else
                {
                    i++;
                }

            }
            return error.ToString();
        }

        }
        
        

                  
}

