using System.Text.Json;

namespace BestPractice.Database
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AnnualIncome { get; set; }
        public JsonDocument? AdditionalInformation { get; set; }
    }
}
