﻿using CollaboratorTest.Domain.Models.Entities;

namespace CollaboratorTest.Domain.Interfaces
{
    public interface ICollaboratorCompanyLinkRepository
    
    {
        Task<List<Collaborator>> GetAllAsync();
        Task<Collaborator?> GetByIdAsync(long id);
        Task AddAsync(Collaborator collaborator);
        Task UpdateAsync(Collaborator collaborator);
        Task DeleteAsync(long id);
    }
}
