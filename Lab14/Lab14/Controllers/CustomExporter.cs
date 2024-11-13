using OpenTelemetry;
using OpenTelemetry.Trace;
using System.Diagnostics;

public class CustomExporter : BaseExporter<Activity>
{
    public override ExportResult Export(in Batch<Activity> batch)
    {
        foreach (var activity in batch)
        {
            Console.WriteLine($"Custom Exporter - TraceId: {activity.TraceId}, Name: {activity.DisplayName}");
            foreach (var tag in activity.Tags)
            {
                Console.WriteLine($"    {tag.Key}: {tag.Value}");
            }
        }
        return ExportResult.Success;
    }
}