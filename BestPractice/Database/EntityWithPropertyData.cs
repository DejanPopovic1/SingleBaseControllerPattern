using System.Text.Json;

namespace BestPractice.Database;

public class EntityWithPropertyData
{
    public Guid Id { get; set; }
    public required string test1 { get; set; }
    public required string test2 { get; set; }
    public JsonDocument test3 { get; set; }



}
