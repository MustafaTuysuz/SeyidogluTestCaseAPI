using System.ComponentModel.DataAnnotations;

namespace SeyidogluTestCaseAPI.Models
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public string? GsmNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModifyUser { get; set; }
        public bool IsDeleted { get; set; }

    }
}
