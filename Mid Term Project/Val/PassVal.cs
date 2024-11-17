using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_Term_Project.Val
{
    public class PassVal : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            try
            {
                bool containsInt = value.ToString().Any(char.IsDigit);

                if (containsInt)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;

            }

            return false;
            
        }
    }
}