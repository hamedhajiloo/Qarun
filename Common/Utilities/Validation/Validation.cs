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
    }
}
