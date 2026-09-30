using Microsoft.EntityFrameworkCore;
using NBC_CMS.Data;
using NBC_CMS.Models;
using NBC_CMS.Requests;
using NBC_CMS.Responses;

namespace NBC_CMS.Services
{
    public class ClaimCorrectionService
    {
        private readonly ApplicationDbContext _context;

        public ClaimCorrectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all correction requests
        public async Task<List<ClaimCorrectionResponse>> GetAllAsync()
        {
            return await _context.ClaimCorrections
                .Select(c => new ClaimCorrectionResponse
                {
                    correctionID = c.correctionID,
                    claimID = c.claimID,
                    requestedBy = c.requestedBy,
                    correctionComment = c.correctionComment,
                    requestedAt = c.requestedAt,
                    correctedAt = c.correctedAt
                })
                .ToListAsync();
        }

        // Get one correction request by ID
        public async Task<ClaimCorrectionResponse?> GetByIdAsync(int id)
        {
            return await _context.ClaimCorrections
                .Where(c => c.correctionID == id)
                .Select(c => new ClaimCorrectionResponse
                {
                    correctionID = c.correctionID,
                    claimID = c.claimID,
                    requestedBy = c.requestedBy,
                    correctionComment = c.correctionComment,
                    requestedAt = c.requestedAt,
                    correctedAt = c.correctedAt
                })
                .FirstOrDefaultAsync();
        }

        // Get all correction requests for a particular claim
        public async Task<List<ClaimCorrectionResponse>> GetByClaimIdAsync(int claimId)
        {
            return await _context.ClaimCorrections
                .Where(c => c.claimID == claimId)
                .Select(c => new ClaimCorrectionResponse
                {
                    correctionID = c.correctionID,
                    claimID = c.claimID,
                    requestedBy = c.requestedBy,
                    correctionComment = c.correctionComment,
                    requestedAt = c.requestedAt,
                    correctedAt = c.correctedAt
                })
                .ToListAsync();
        }

        // Create a correction request
        public async Task<ClaimCorrectionResponse> CreateAsync(
            ClaimCorrectionRequest request)
        {
            var correction = new ClaimCorrection
            {
                claimID = request.claimID,
                requestedBy = request.requestedBy,
                correctionComment = request.correctionComment,
                requestedAt = DateTime.Now,
                correctedAt = null
            };

            _context.ClaimCorrections.Add(correction);
            await _context.SaveChangesAsync();

            return new ClaimCorrectionResponse
            {
                correctionID = correction.correctionID,
                claimID = correction.claimID,
                requestedBy = correction.requestedBy,
                correctionComment = correction.correctionComment,
                requestedAt = correction.requestedAt,
                correctedAt = correction.correctedAt
            };
        }

        // Mark a correction as completed
        public async Task<bool> MarkCorrectedAsync(int id)
        {
            var correction = await _context.ClaimCorrections.FindAsync(id);

            if (correction == null)
            {
                return false;
            }

            correction.correctedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}