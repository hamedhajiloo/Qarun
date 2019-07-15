using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utilities.Validation
{
    public static class Validation
    {
        public static bool ISBN(string value)
        {
            var _value = value.Trim();
            if (Regex.IsMatch(_value, @"[0-9]{13}||[0-9]{10}"))
            {
                var count = _value.Length;
                var cArray = _value.ToCharArray();
                if (count == 10)
                {
                    var s = 0;
                    for (int i = 10; i >= 1; i--)
                    {
                        s += Convert.ToInt32(i * cArray[10 - i]);
                    }
                    if (s % 11 == 0)
                        return true;
                    else
                        return false;
                }
                else if (count == 13)
                {
                    var s = 0;
                    for (int i = 12; i >= 1; i--)
                    {
                        if (i % 2 == 0)
                            s += Convert.ToInt32(cArray[12-i]);
                        else
                            s += Convert.ToInt32((3 * cArray[12 - i]));
                    }
                    s -= Convert.ToInt32(cArray[12]);
                    if (s % 10 == 0)
                        return true;
                    else if (s % 10 != 0)
                        return false;

                }
                else
                    return false;

            }
            else
            {
                return false;
            }
            return false;
        }

        public static bool StudentNumber(string value)
        {
            var _value = value.Trim();
            if (Regex.IsMatch(_value, @"9[0-9]{9}"))  return true;
            
            return false;
        }

        public static bool UserName(string value)
        {
            var _value = value.Trim();
            if (Regex.IsMatch(_value, @"[A-Za-z][A-Za-z0-9]")) return true;

            return false;
        }

        public static bool Shaba(string value)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            keyValuePairs.Add("A", 10);
            keyValuePairs.Add("B", 11);
            keyValuePairs.Add("C", 12);
            keyValuePairs.Add("D", 13);
            keyValuePairs.Add("E", 14);
            keyValuePairs.Add("F", 15);
            keyValuePairs.Add("G", 16);
            keyValuePairs.Add("H", 17);
            keyValuePairs.Add("I", 18);
            keyValuePairs.Add("J", 19);
            keyValuePairs.Add("K", 20);
            keyValuePairs.Add("L", 21);
            keyValuePairs.Add("M", 22);
            keyValuePairs.Add("N", 23);
            keyValuePairs.Add("O", 24);
            keyValuePairs.Add("P", 25);
            keyValuePairs.Add("Q", 26);
            keyValuePairs.Add("R", 27);
            keyValuePairs.Add("S", 28);
            keyValuePairs.Add("T", 29);
            keyValuePairs.Add("U", 30);
            keyValuePairs.Add("V", 31);
            keyValuePairs.Add("W", 32);
            keyValuePairs.Add("X", 33);
            keyValuePairs.Add("Y", 34);
            keyValuePairs.Add("Z", 35);


            var _value = value.Trim();
            var a = _value.Substring(4);
            var b= _value.Substring(0,4);
            foreach (var item in keyValuePairs)
            {
                foreach (var item2 in b)
                {
                    item2.ToString().Replace(item.Key, item.Value.ToString());
                }
            }
            if (Regex.IsMatch(_value, @"[A-Za-z][A-Za-z0-9]")) return true;

            return false;
        }
    }
}
