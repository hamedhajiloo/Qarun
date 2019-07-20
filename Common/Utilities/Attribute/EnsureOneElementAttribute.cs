using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Sepehran.Pooshako.Utilities.Attribute
{
    /// <summary>
    /// ولیدیشن مخصوص لیست
    /// لیست نباید خالی یا نال باشد
    /// </summary>
    public class EnsureOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }


    public class MaxCount4ListAttribute : ValidationAttribute
    {
        private int _max;
        public MaxCount4ListAttribute(int max)
        {
            _max = max;
        }
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list.Count>_max)
            {
                return false;
            }
            return true;
        }
    }
}
