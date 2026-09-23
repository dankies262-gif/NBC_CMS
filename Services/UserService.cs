using Microsoft.EntityFrameworkCore;
using NBC_CMS.Data;
using NBC_CMS.Models;
using NBC_CMS.Requests;
using NBC_CMS.Responses;
using NBC_CMS.Services.Interfaces;

namespace NBC_CMS.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL USERS
        public async Task<List<UserResponse>> GetAllAsync()
        {
            return await _context.Users
                .Select(user => new UserResponse
                {
                    userID = user.userID,
                    username = user.username,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    contactNumber = user.contactNumber,
                    roleID = user.roleID,
                    isActive = user.isActive,
                    createdAt = user.createdAt,
                    updatedAt = user.updatedAt
                })
                .ToListAsync();
        }

        // GET USER BY ID
        public async Task<UserResponse?> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.userID == id);

            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                userID = user.userID,
                username = user.username,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                contactNumber = user.contactNumber,
                roleID = user.roleID,
                isActive = user.isActive,
                createdAt = user.createdAt,
                updatedAt = user.updatedAt
            };
        }

        // CREATE USER
        public async Task<UserResponse> CreateAsync(UserRequest request)
        {
            var usernameExists = await _context.Users
                .AnyAsync(u => u.username == request.username);

            if (usernameExists)
            {
                throw new Exception("Username already exists.");
            }

            var emailExists = await _context.Users
                .AnyAsync(u => u.email == request.email);

            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                username = request.username,
                firstName = request.firstName,
                lastName = request.lastName,
                email = request.email,
                contactNumber = request.contactNumber,
                roleID = request.roleID,
                isActive = request.isActive,
                createdAt = DateTime.Now,
                updatedAt = null
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return new UserResponse
            {
                userID = user.userID,
                username = user.username,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                contactNumber = user.contactNumber,
                roleID = user.roleID,
                isActive = user.isActive,
                createdAt = user.createdAt,
                updatedAt = user.updatedAt
            };
        }

        // UPDATE USER
        public async Task<bool> UpdateAsync(int id, UserRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.userID == id);

            if (user == null)
            {
                return false;
            }

            var usernameExists = await _context.Users
                .AnyAsync(u => u.username == request.username && u.userID != id);

            if (usernameExists)
            {
                throw new Exception("Username already exists.");
            }

            var emailExists = await _context.Users
                .AnyAsync(u => u.email == request.email && u.userID != id);

            if (emailExists)
            {
                throw new Exception("Email already exists.");
            }

            user.username = request.username;
            user.firstName = request.firstName;
            user.lastName = request.lastName;
            user.email = request.email;
            user.contactNumber = request.contactNumber;
            user.roleID = request.roleID;
            user.isActive = request.isActive;
            user.updatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        // DELETE USER
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.userID == id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}