using System.Text.Json.Serialization;

namespace CollaboratorTest.Application.DTO.Requests
{
    public class CollaboratorRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Document { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }

        [JsonIgnore]
        public bool IsEnabled { get; set; } = true;
    }
}
