using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PA.Domain;
using PA.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https=//go.microsoft.com/fwlink/?LinkID=397860

namespace PA.Api.Controllers;


[EnableCors("CorsApi")]
[Route("api/[controller]")]
[ApiController]
public class JobsController : Controller
{
    private readonly JobsService _jobs;

    public JobsController(IJobsService jobs)
    {
        _jobs = (JobsService)jobs;
    }

    [HttpGet]
    public IEnumerable<JobViewModel> Get()    {
        var jobs = _jobs.Get();

        foreach(var job in _jobs.Get())
        {
            yield return new JobViewModel()
            {
                Id = job.Id,
                Date = job.Date,
                TotalJobs = job.TotalJobs,
                TotalViews = job.TotalViews,
                PredictedViews = job.PredictedViews
            };
        }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public JobViewModel Get(int id)
    {
        var job = _jobs.Get(id);
        return new JobViewModel()
        {
            Id = job.Id,
            Date = job.Date,
            TotalJobs = job.TotalJobs,
            TotalViews = job.TotalViews,
            PredictedViews = job.PredictedViews
        };
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post(JobViewModel model)
    {
        _jobs.Add(new Job()
        {
            Id = model.Id,
            Date = model.Date,
            TotalJobs = model.TotalJobs,
            TotalViews = model.TotalViews,
            PredictedViews = model.PredictedViews
        });

        return Ok();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, JobViewModel model)
    {
        _jobs.Update(new Job()
        {
            Id = model.Id,
            Date = model.Date,
            TotalJobs = model.TotalJobs,
            TotalViews = model.TotalViews,
            PredictedViews = model.PredictedViews
        });

        return Ok();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _jobs.Delete(id);

        return Ok();
    }

    [HttpGet()]
    [Route("/jobs/init-data")]
    public IActionResult Init()
    {
        _jobs.Add(new Job()
        {
            Id = 1,
            Date = new DateTime(2014, 2, 12),
            TotalJobs = 3,
            TotalViews = 0,
            PredictedViews = 0,
        });
        _jobs.Add(new Job()
            {
                Id = 2,
                Date = new DateTime(2014, 2, 13),
                TotalJobs = 3,
                TotalViews = 1,
                PredictedViews = 1,
            });
        _jobs.Add(new Job()
            {
                Id = 3,
                Date = new DateTime(2014, 2, 14),
                TotalJobs = 3,
                TotalViews = 2,
                PredictedViews = 3,
            });
        _jobs.Add(new Job()
            {
                Id = 4,
                Date = new DateTime(2014, 2, 15),
                TotalJobs = 11,
                TotalViews = 5,
                PredictedViews = 3,
            });
        _jobs.Add(new Job()
            {
                Id = 5,
                Date = new DateTime(2014, 2, 16),
                TotalJobs = 2,
                TotalViews = 6,
                PredictedViews = 4,
            });
        _jobs.Add(new Job()
            {
                Id = 6,
                Date = new DateTime(2014, 2, 17),
                TotalJobs = 6,
                TotalViews = 7,
                PredictedViews = 8,
            });

        return Ok();

    }
}

