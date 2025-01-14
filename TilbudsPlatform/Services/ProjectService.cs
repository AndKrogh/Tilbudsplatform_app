using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Interfaces;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Model;

namespace TilbudsPlatform.core.Services
{
    public class ProjectService : IProjectInterface
    {
        private readonly TilbudsPlatformContext _context;

        public ProjectService(TilbudsPlatformContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            var totalCost = project.EstimatedHours * project.HourlyRate;
            var estimate = new Estimate
            {
                ProjectId = project.Id,
                EstimatedHours = project.EstimatedHours,
                HourlyRate = project.HourlyRate,
                TotalCost = totalCost
            };

            _context.Estimates.Add(estimate);
            await _context.SaveChangesAsync();

            return project;
        }


        public async Task UpdateProjectAsync(Project project)
        {
            var existingProject = await _context.Projects.FindAsync(project.Id);
            if (existingProject == null)
                throw new KeyNotFoundException($"Project with ID {project.Id} not found.");

            _context.Entry(existingProject).CurrentValues.SetValues(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                throw new KeyNotFoundException($"Project with ID {id} not found.");

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Customer)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                throw new KeyNotFoundException($"Project with ID {id} not found.");

            return project;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects
                .Include(p => p.Customer)
                .ToListAsync();
        }
    }
}
