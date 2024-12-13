﻿using CollaboratorTest.Domain.Interfaces;
using CollaboratorTest.Domain.Models.Entities;
using CollaboratorTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CollaboratorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Collaborator>> GetAllAsync()
        {
            return await _dbContext.Collaborator.ToListAsync();
        }

        public async Task<List<Collaborator>> GetAllEnabledAsync()
        {
            return await _dbContext.Collaborator.Where(c => c.IsEnabled == true).ToListAsync();
        }

        public async Task<Collaborator?> GetByIdAsync(long id)
        {
            return await _dbContext.Collaborator.FindAsync(id);
        }

        public async Task AddAsync(Collaborator collaborator)
        {
            await _dbContext.Collaborator.AddAsync(collaborator);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collaborator collaborator)
        {
            _dbContext.Collaborator.Update(collaborator);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var collaborator = await GetByIdAsync(id);
            if (collaborator != null)
            {
                collaborator.IsEnabled = false;
                _dbContext.Collaborator.Update(collaborator);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
