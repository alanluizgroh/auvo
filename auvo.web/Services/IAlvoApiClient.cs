using auvo.domain;

namespace auvo.web.Services
{
    public interface IAlvoApiClient
    {
        Task<List<Department>> GetDepartmentsAsync();
    }
}
