using Microsoft.EntityFrameworkCore;
using NBC_CMS.Data;
using NBC_CMS.Models;
using NBC_CMS.Requests;
using NBC_CMS.Responses;

namespace NBC_CMS.Services
{
    public class ProgrammeService
    {
        private readonly ApplicationDbContext _context;

        public ProgrammeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all programmes
        public async Task<List<ProgrammeResponse>> GetAllAsync()
        {
            return await _context.Programmes
                .Select(p => new ProgrammeResponse
                {
                    programmeID = p.programmeID,
                    programmeName = p.programmeName,
                    description = p.description,
                    isActive = p.isActive,
                    createdAt = p.createdAt,
                    updatedAt = p.updatedAt
                })
                .ToListAsync();
        }

        // Get one programme by ID
        public async Task<ProgrammeResponse?> GetByIdAsync(int id)
        {
            return await _context.Programmes
                .Where(p => p.programmeID == id)
                .Select(p => new ProgrammeResponse
                {
                    programmeID = p.programmeID,
                    programmeName = p.programmeName,
                    description = p.description,
                    isActive = p.isActive,
                    createdAt = p.createdAt,
                    updatedAt = p.updatedAt
                })
                .FirstOrDefaultAsync();
        }

        // Create a new programme
        public async Task<ProgrammeResponse> CreateAsync(ProgrammeRequest request)
        {
            var programme = new Programme
            {
                programmeName = request.programmeName,
                description = request.description,
                isActive = true,
                createdAt = DateTime.Now
            };

            _context.Programmes.Add(programme);
            await _context.SaveChangesAsync();

            return new ProgrammeResponse
            {
                programmeID = programme.programmeID,
                programmeName = programme.programmeName,
                description = programme.description,
                isActive = programme.isActive,
                createdAt = programme.createdAt,
                updatedAt = programme.updatedAt
            };
        }

        // Update a programme
        public async Task<bool> UpdateAsync(int id, ProgrammeRequest request)
        {
            var programme = await _context.Programmes.FindAsync(id);

            if (programme == null)
            {
                return false;
            }

            programme.programmeName = request.programmeName;
            programme.description = request.description;
            programme.updatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        // Delete a programme
        public async Task<bool> DeleteAsync(int id)
        {
            var programme = await _context.Programmes.FindAsync(id);

            if (programme == null)
            {
                return false;
            }

            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}