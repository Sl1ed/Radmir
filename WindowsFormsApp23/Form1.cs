using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trans trans = new Trans();
            trans.TextGS = textBox1.Text;
            textBox2.Text = trans.GetResponse();
        }

    }
    class Trans
    {
        private int Iter = 0;
        private string Text;
        private string Response;
        public string reservedsymbols = "*:/()-=[]{}";
        public string punctuationsymbols = ".,?!";

        public int IterGS
        {
            set
            {
                Iter = value;
            }
            get
            {
                return Iter;
            }
        }

        public string TextGS
        {
            set
            {
                Text = value;
            }
            get
            {
                return Text;
            }
        }

        public string ResponseGS
        {
            set
            {
                Response = value;
            }
            get
            {
                return Response;
            }
        }

        public Trans()
        {
        }

        public string GetTypeSymbol(char symbol)
        {

            if (symbol >= 'a' && symbol <= 'z')
            {
                return "Down letter";
            }
            if (symbol >= 'A' && symbol <= 'Z')
            {
                return "Up letter";
            }
            else if (symbol >= '0' && symbol <= '9')
            {
                return "Digit";
            }
            else if (reservedsymbols.Contains(symbol))
            {
                return "Reserved";
            }
            else if (punctuationsymbols.Contains(symbol))
            {
                return "Punctuation";
            }
            else if (symbol == '\r')
            {
                return "End string";
            }
            else if (symbol == '\n')
            {
                return "New String";
            }
            else if (symbol == ' ')
            {
                return "Space";
            }
            else
            {
                return "Неопознанный символ";
            }
        }

        public string GetResponse()
        {
            while (IterGS != TextGS.Length)
            {

                switch (this.GetTypeSymbol(Convert.ToChar(TextGS[IterGS])))
                {
                    case "Down letter": { ResponseGS += "(Down letter)"; break; }
                    case "Up letter": { ResponseGS += "(Up letter)"; break; }
                    case "Digit": { ResponseGS += "(Digit)"; break; }
                    case "Reserved": { ResponseGS += "(Reserved)"; break; }
                    case "Punctuation": { ResponseGS += "(Punctuation)"; break; }
                    case "End string": { ResponseGS += "(End string)"; break; }
                    case "New String": { ResponseGS += "(New String)"; break; }
                    case "Space": { ResponseGS += "(Space)"; break; }
                    case "Неопознанный символ": { ResponseGS += "(Неопознанный символ)"; break; }
                }
                IterGS++;
            }
            ResponseGS += "(End text)";
            return ResponseGS;
        }
    }
}
