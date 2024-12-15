﻿namespace CollaboratorTest.Application.DTO
{
    public class CollaboratorResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Document { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public DateTime CreationDate { get; set; }
    }
}