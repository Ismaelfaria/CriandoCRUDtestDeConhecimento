using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CriandoCRUD
{
    internal class Validation
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

        public Validation(string Nome, string Email, string Telefone)
        {
            this.nome = Nome;
            this.email = Email;
            this.telefone = Telefone;
        }
        public static bool valid(string nome, string email, string telefone)
        {
            if (checkNumber(telefone) == true && checkFields(nome, email, telefone) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool validcamp(string nome, string email, string telefone)
        {
            if (checkFields(nome, email, telefone) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool checkNumber(string telefone)
            { 
                string input = telefone;
                if (Regex.IsMatch(input, @"^[0-9]+$"))
                {
                    return true;
                }
                else 
                { 
                    return false;
                }
            }
        private static bool checkFields(string nome, string email, string telefone)
        {
            if (string.IsNullOrEmpty(nome) &&
                string.IsNullOrEmpty(email) &&
                string.IsNullOrEmpty(telefone))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
