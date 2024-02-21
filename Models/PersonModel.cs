using SaudePlus.Enums;

namespace SaudePlus.Models
{
    public class PersonModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string? City { get; set; }
        public bool IfSmoke { get; set; }
        public int SmokeQuantity { get; set; }
        public int UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}