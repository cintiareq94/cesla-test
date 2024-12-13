using System.Text.Json.Serialization;

namespace CollaboratorTest.Application.DTO.Requests
{
    public class CompanyRequestDto
    {
        public string TradeName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public bool IsEnabled { get; set; } = true;
    }
}
