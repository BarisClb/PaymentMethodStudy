using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.FluentValidation.Helpers
{
    public static class GuidCheck
    {
        public static bool IsValid(Guid unValidatedGuid)
        {
            try
            {
                if (unValidatedGuid != Guid.Empty && unValidatedGuid != null)
                {
                    if (Guid.TryParse(unValidatedGuid.ToString(), out Guid validatedGuid))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static bool IsGuid(string bar)
        {
            return Guid.TryParse(bar, out var result);
        }


        public readonly static Regex isGuid =
        new(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

        public static bool IsGuid(string candidate, out Guid output)
        {
            bool isValid = false;
            output = Guid.Empty;

            if (candidate != null)
            {

                if (isGuid.IsMatch(candidate))
                {
                    output = new Guid(candidate);
                    isValid = true;
                }
            }

            return isValid;
        }


        public static bool TryParseGuid(this Guid? guidString)
        {
            if (guidString != null && guidString != Guid.Empty)
            {
                if (Guid.TryParse(guidString.ToString(), out _))
                {
                    return true;
                }
                else
                    return false;
            }

            return false;
        }
    }
}
