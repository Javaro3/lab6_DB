using System.Text.Json.Serialization;

namespace lab6.Models;

public class Client {
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string MobilePhone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public DateTime PassportIssueDate { get; set; }

    [JsonIgnore]
    public virtual ICollection<InsuranceCase> InsuranceCases { get; set; } = new List<InsuranceCase>();
}