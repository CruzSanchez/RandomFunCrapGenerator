namespace RandomFunCrapGeneratorLibrary.Models
{
    public class ValidationTicket
    {
        public bool PassedValidationCheck { get; set; } = default;
        public string DenialReason { get; set; } = string.Empty;
    }
}
