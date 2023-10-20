// Ignore Spelling: Validator

using RandomFunCrapGeneratorLibrary.Models;

namespace RandomFunCrapGeneratorLibrary
{
    public static class ActivityValidator
    {
        public static void Validate(Activity activityToValidate)
        {
            if (activityToValidate == null)
            {
                activityToValidate.ValidationTicket.DenialReason = "Activity was null, please try again";
                return;
            }

            ValidationTicket ticket = new ValidationTicket();
            activityToValidate.ValidationTicket = ticket;

            if (string.IsNullOrEmpty(activityToValidate.Name) || string.IsNullOrWhiteSpace(activityToValidate.Name))
            {
                activityToValidate.ValidationTicket.DenialReason = "Name was not given or in the correct format. Please try again";
                return;
            }

            activityToValidate.ValidationTicket.PassedValidationCheck = true;
        }
    }
}
