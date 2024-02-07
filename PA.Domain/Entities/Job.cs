using System.ComponentModel.DataAnnotations.Schema;

namespace PA.Domain;

[Table("jobs")]
public class Job : BaseEntity
{
    [Column("date")]
    public DateTime Date { get; set; }

    [Column("total_jobs")]
    public int TotalJobs { get; set; }

    [Column("total_views")]
    public int TotalViews { get; set; }

    [Column("predicted_views")]
    public int PredictedViews { get; set; }
}

