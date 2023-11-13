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
    public static class Parser
    {
        /// <summary>
        /// Turns the input from the user into all lower case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LowerCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
              
       public static System.Action ParseAction(IEnumerable<string> strings)
        {
            var actions = Enum.GetNames(typeof(System.Action));
            var firstaction = strings.Select(LowerCase).FirstOrDefault(strings => actions.Contains(strings));
            return string.IsNullOrEmpty(firstaction) ? Action.Null : (Action)Enum.Parse(typeof(Action), firstaction);
        }

        public static IEnumerable<int> ParseNumbers(IEnumerable<string> strings);

            
    }
}
