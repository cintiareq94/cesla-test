﻿namespace CollaboratorTest.Application.Commands.CollaboratorCommands
{
    public class UpdateCollaboratorCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
    }
}