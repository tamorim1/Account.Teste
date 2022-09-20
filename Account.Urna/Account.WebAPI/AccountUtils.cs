using Mapster;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Account.WebAPI
{
    public static class AccountUtils
    {
        public static TClass Convert<TClass>(this object objectConvert)
        {

            return objectConvert.Adapt<TClass>();

        }

        public static void Validate(this object objectValidate)
        {
            var stringBuilder = new StringBuilder();

            try
            {

               
                var validationContext = new ValidationContext(objectValidate, null, null);
                var validationResults = new Collection<ValidationResult>();
                var isValid = Validator.TryValidateObject(validationContext.ObjectInstance, validationContext, validationResults, true);

                foreach (var vr in validationResults)
                {
                    stringBuilder.AppendLine($"{string.Join(" | ",vr.MemberNames)} - {vr.ErrorMessage}");
                }


            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine(ex.Message);
            }
            finally
            {
                if (stringBuilder.Length > 0)
                {
                    throw new Exception(stringBuilder.ToString());
                }
            }
        }
    }
}
