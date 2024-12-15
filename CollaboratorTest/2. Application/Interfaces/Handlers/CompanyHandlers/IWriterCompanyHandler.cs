using CollaboratorTest.Application.DTO.Requests;

namespace CollaboratorTest._2._Application.Interfaces.Handlers.CompanyHandlers
{
    public interface IWriterCompanyHandler
    {
        Task<long> HandleAddAsync(CompanyRequestDto dto);

        Task HandleUpdateAsync(long companyId, CompanyRequestDto dto);

        Task HandleDeleteAsync(long companyId);
    }
}
