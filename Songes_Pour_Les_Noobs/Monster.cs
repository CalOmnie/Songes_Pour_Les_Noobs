using YamlDotNet.Serialization;

namespace Songes_Pour_Les_Noobs
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Difficulty { get; set; }
        public int ImmediateFocus { get; set; }
        public int Evasion { get; set; }
        public int Tanking { get; set; }
        public string Information { get; set; }
        public string? Mechanic { get; set; }
        public string Advice { get; set; }

        public string? InformationShort { get; set; }
        public string? MechanicShort { get; set; }
        public string? AdviceShort { get; set; }

        public string? Illustration { get; set; } = null;
        public string? Caption { get; set; } = null;
    }

    public class MonsterService
    {
        private readonly HttpClient http;
        private Dictionary<int, Monster>? monsters;

        public MonsterService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<Dictionary<int, Monster>> GetMonstersAsync()
        {
            if (monsters == null)
            {
                var yamlText = await http.GetStringAsync("Data/monsters.yaml");
                var deserializer = new DeserializerBuilder().Build();
                List<Monster> initial = deserializer.Deserialize<List<Monster>>(yamlText);
                monsters = initial.ToDictionary(m => m.Id);
            }

            return monsters;
        }
    }
}
