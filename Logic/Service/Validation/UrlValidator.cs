using System;
using System.Text.RegularExpressions;


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
               
            }
            return resultat;
        }
    }

   
}