﻿using CollaboratorTest.Application.DTO.Responses;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers
{
    public interface IReaderCompanyHandler
    {
        Task<List<CompanyResponseDto>> HandleGetAllAsync();
        Task<CompanyResponseDto> HandleGetByIdAsync(long id);
        Task<List<CompanyResponseDto>> HandleGetAllEnabledAsync();
    }
}