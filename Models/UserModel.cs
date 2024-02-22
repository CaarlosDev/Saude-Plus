using System.Text.Json.Serialization;

namespace SaudePlus.Models
{
    public class UserModel {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
    }

    public class UserModelRequest {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}