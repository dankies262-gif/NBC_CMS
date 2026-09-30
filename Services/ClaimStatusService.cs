using Microsoft.EntityFrameworkCore;
using NBC_CMS.Data;
using NBC_CMS.Models;
using NBC_CMS.Requests;
using NBC_CMS.Responses;

namespace NBC_CMS.Services
{
    public class ClaimStatusService
    {
        private readonly ApplicationDbContext _context;

        public ClaimStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all claim statuses
        public async Task<List<ClaimStatusResponse>> GetAllAsync()
        {
            return await _context.ClaimStatuses
                .Select(s => new ClaimStatusResponse
                {
                    statusID = s.statusID,
                    statusName = s.statusName,
                    description = s.description
                })
                .ToListAsync();
        }

        // Get one claim status by ID
        public async Task<ClaimStatusResponse?> GetByIdAsync(int id)
        {
            return await _context.ClaimStatuses
                .Where(s => s.statusID == id)
                .Select(s => new ClaimStatusResponse
                {
                    statusID = s.statusID,
                    statusName = s.statusName,
                    description = s.description
                })
                .FirstOrDefaultAsync();
        }

        // Create a new claim status
        public async Task<ClaimStatusResponse> CreateAsync(ClaimStatusRequest request)
        {
            var status = new ClaimStatus
            {
                statusName = request.statusName,
                description = request.description
            };

            _context.ClaimStatuses.Add(status);
            await _context.SaveChangesAsync();

            return new ClaimStatusResponse
            {
                statusID = status.statusID,
                statusName = status.statusName,
                description = status.description
            };
        }

        // Update a claim status
        public async Task<bool> UpdateAsync(int id, ClaimStatusRequest request)
        {
            var status = await _context.ClaimStatuses.FindAsync(id);

            if (status == null)
            {
                return false;
            }

            status.statusName = request.statusName;
            status.description = request.description;

            await _context.SaveChangesAsync();

            return true;
        }

        // Delete a claim status
        public async Task<bool> DeleteAsync(int id)
        {
            var status = await _context.ClaimStatuses.FindAsync(id);

            if (status == null)
            {
                return false;
            }

            _context.ClaimStatuses.Remove(status);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}