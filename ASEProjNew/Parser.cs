using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

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

        parseCommand(String line)
        {
            line = line.ToLower(0.trim());
            split = line.split('')
        }

            
    }
}
