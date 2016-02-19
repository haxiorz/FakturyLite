using System;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public static class FormsHelpers
    {
       
        public static void validate_textBox(TextBox _text, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                TextBox box = (TextBox)_text;
                int pos = box.SelectionStart;
                box.Text = box.Text.Insert(pos, ",");
                box.SelectionStart = pos + 1;
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (_text.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (_text.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(_text.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (_text.SelectionStart != _text.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = _text.Text.Substring(_text.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(_text.Text, ref sepratorChar))
                {
                    int sepratorPosition = _text.Text.IndexOf(sepratorChar);
                    string afterSepratorString = _text.Text.Substring(sepratorPosition + 1);
                    if (_text.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        public static bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }
            return false;
        }

        public static bool ValidateWhitespace(object sender, KeyPressEventArgs e) //Walidacja podwójnej spacji
        {
            TextBox tb = (TextBox)sender;
            if ((e.KeyChar == ' ') && (tb.Text.Length > 0))
            {
                if (tb.Text[tb.Text.Length - 1] == ' ')
                    e.Handled = true;
            }
            return false;
        }

        public static void ClearAllTextboxes(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllTextboxes(c);
            }
        }

        public static void ClearAllMaskedTextboxes(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is MaskedTextBox)
                    ((MaskedTextBox)c).Clear();
                else
                    ClearAllMaskedTextboxes(c);
            }
        }

    }
}
