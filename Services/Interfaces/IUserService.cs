using NBC_CMS.Requests;
using NBC_CMS.Responses;

namespace NBC_CMS.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetAllAsync();

        Task<UserResponse?> GetByIdAsync(int id);

        Task<UserResponse> CreateAsync(UserRequest request);

        Task<bool> UpdateAsync(int id, UserRequest request);

        Task<bool> DeleteAsync(int id);
    }
}