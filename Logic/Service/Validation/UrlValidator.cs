﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Controls;
using TextBox = System.Windows.Controls.TextBox;


namespace Logic.Service.Validation
{
    public class UrlValidator
    {
        public bool Validate(string url)
        {
            bool resultat = false;
            const string reg = @"^(ht|f|sf)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
            
            
            if (Regex.IsMatch(url, reg))
            {
                resultat = true;
            }
            else if(!Regex.IsMatch(url, reg))
            {
                MessageBox.Show("Din angivna URL är inkorrekt");
            }
            return resultat;
        }

        public bool EmptyTextBox(TextBox tb)
        {
            bool resultat;
            if (String.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Det finns ett fält som inte är ifyllt.");
                resultat = false;
            }
            else
            {
                resultat = true;
            }
            return resultat;

        }
    }

   
}