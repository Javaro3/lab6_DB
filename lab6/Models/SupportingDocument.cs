using System.Text.Json.Serialization;

namespace lab6.Models;

public class SupportingDocument {
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<InsuranceCase> InsuranceCases { get; set; } = new List<InsuranceCase>();
}
