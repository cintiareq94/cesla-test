﻿using Microsoft.AspNetCore.Identity;

namespace CollaboratorTest.Domain.Models.Entities
{
    public class Collaborator
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Document {  get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public bool IsEnabled { get; set; }

    }
}