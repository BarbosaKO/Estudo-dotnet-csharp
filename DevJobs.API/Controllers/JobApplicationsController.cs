namespace JobApplicationsController.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly DevJobsContext _context;
        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _context.JobVacancies != null ? _context.JobVacancies
            .FirstOrDefault(jv => jv.Id == id) : null;

            if(jobVacancy == null)
                return NotFound();

            var jobApplication = new JobApplication(
                    model.ApplicantName, model.ApplicantEmail, id
                );

            if(_context.JobApplications != null)
            {
                _context.JobApplications.Add(jobApplication);  
                _context.SaveChanges();
            }
            
            return NoContent();
        }
    }
}