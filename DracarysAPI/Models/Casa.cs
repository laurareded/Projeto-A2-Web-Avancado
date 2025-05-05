using System.Text.Json.Serialization;
namespace DracarysAPI.Models;

public class Casa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Regiao { get; set; }

    [JsonIgnore]
    public List<Personagem> Characters { get; set; }

    [JsonIgnore]
    public List<Dragao> Dragoes { get; set; }

}