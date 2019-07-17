﻿using System;
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
                            s += Convert.ToInt32(cArray[12 - i]);
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
            if (Regex.IsMatch(_value, @"9[0-9]{9}")) return true;

            return false;
        }

        public static bool UserName(string value)
        {
            var _value = value.Trim();
            if (Regex.IsMatch(_value, @"[A-Za-z][A-Za-z0-9]")) return true;

            return false;
        }

        public static bool IBAN(string value)
        {

            var _value = value.Trim();
            var a = _value.Substring(4);
            var b = _value.Substring(0, 4);

            var x = b.Replace("A", "10")
                  .Replace("B", "11")
                  .Replace("C", "12")
                  .Replace("D", "13")
                  .Replace("E", "14")
                  .Replace("F", "15")
                  .Replace("G", "16")
                  .Replace("H", "17")
                  .Replace("I", "18")
                  .Replace("J", "19")
                  .Replace("K", "20")
                  .Replace("L", "21")
                  .Replace("M", "22")
                  .Replace("N", "23")
                  .Replace("O", "24")
                  .Replace("P", "25")
                  .Replace("Q", "26")
                  .Replace("R", "27")
                  .Replace("S", "28")
                  .Replace("T", "29")
                  .Replace("U", "30")
                  .Replace("V", "31")
                  .Replace("W", "32")
                  .Replace("X", "33")
                  .Replace("Y", "34")
                  .Replace("Z", "35");

            var c = a + x;

            if (c.Length != 28)
                return false;

            return Convert.ToInt64(c) % 97 == 1;

        }
    }
}
