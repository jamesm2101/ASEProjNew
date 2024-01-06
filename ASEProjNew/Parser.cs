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
        /// <summary>
        /// Turns the input from the user into all lower case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        private HashSet<string> commands = new HashSet<string>
        {
            "moveto", "drawto", "clear", "reset", "circle", "rectangle", "triangle", "pen", "fill", "colour"
        };

        String command;
        String Parameter1;
        public void ParseCommand(string Input)
        {
            string[] split = Input.Split(' ');
            command = split[0];
            Parameter1 = (split[1]);
            Parameter2 = split[2];
            Parameter3 = split[3];
            Parameter4 = split[4];
            Parameter5 = split[5];
            Parameter6 = split[6];
        
            if
                (Input.Equals("circle") == true)
            {
                return new Circle();
            }
                
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
                        int paramnumbers = ParseIntegerParameters(connectedparams, command, lineNumber, variables);
                        ExecuteCommandWithParams(command, paramnumbers);
                        break;
                }
            }

           }

        }
        
        

                  
    }
}
