namespace SeyidogluTestCaseAPI.DTO
{
    public class AddCustomerRequestModel
    {
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string? GsmNumber { get; set; }
    }
}
