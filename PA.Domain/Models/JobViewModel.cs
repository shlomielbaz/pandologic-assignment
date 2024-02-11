using Newtonsoft.Json;

namespace PA.Domain;
public class JobViewModel
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("totalJobs")]
    public int TotalJobs { get; set; }

    [JsonProperty("totalViews")]
    public int TotalViews { get; set; }

    [JsonProperty("predictedViews")]
    public int PredictedViews { get; set; }
}