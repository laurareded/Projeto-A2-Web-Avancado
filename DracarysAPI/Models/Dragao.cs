using System.Text.Json.Serialization;
namespace DracarysAPI.Models;

public class Dragao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Montador { get; set; }
    public int CasaId { get; set; }

    [JsonIgnore]
    public Casa Casa { get; set; }

}
