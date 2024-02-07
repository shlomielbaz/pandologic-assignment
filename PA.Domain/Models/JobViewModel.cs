namespace PA.Domain;
public class JobViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int TotalJobs { get; set; }
    public int TotalViews { get; set; }
    public int PredictedViews { get; set; }
}