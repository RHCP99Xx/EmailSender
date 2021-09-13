using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailSender
{
    public class TextBoxValidators
    {
        public bool EmailStructureValidator(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CompleteTextbox(string message, string subject)
        {
            if (message.Length > 3 && subject.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
