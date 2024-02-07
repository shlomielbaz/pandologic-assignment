namespace PA.Domain;

public class OperationStatus
{
    public bool Status { get; set; } = default(bool);

    public string? Message { get; set; } = default(string);

    public object? Model { get; set; } = default;

    public Exception? Exception { get; set; } = default(Exception);
}

