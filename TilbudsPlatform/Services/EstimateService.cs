using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Data;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Interfaces;

namespace TilbudsPlatform.core.Services
{
    public class EstimateService : IEstimateInterface
    {
        private readonly TilbudsPlatformContext _context;

        public EstimateService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task PopulateEstimatesFromProjectsAsync()
        {
            var projectsWithoutEstimates = _context.Projects
                .Where(p => !_context.Estimates.Any(e => e.ProjectId == p.Id))
                .ToList();

            foreach (var project in projectsWithoutEstimates)
            {
                var totalCost = project.EstimatedHours * project.HourlyRate;

                var estimate = new Estimate
                {
                    ProjectId = project.Id,
                    EstimatedHours = project.EstimatedHours,
                    HourlyRate = project.HourlyRate,
                    TotalCost = totalCost
                };

                _context.Estimates.Add(estimate);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Estimate> GetByProjectIdAsync(int projectId)
        {
            var estimate = await _context.Estimates
                .FirstOrDefaultAsync(e => e.ProjectId == projectId);

            if (estimate == null)
            {
                throw new KeyNotFoundException($"Estimate for project with ID {projectId} not found.");
            }

            return estimate;
        }

        public Task<int?> GetEstimateByProjectIdAsync(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
