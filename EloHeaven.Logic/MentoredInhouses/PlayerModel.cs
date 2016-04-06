namespace EloHeaven.Logic.MentoredInhouses
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Rank { get; set; }
        public int Rating { get; set; }
        public RegionModel Region { get; set; }
        public string Status { get; set; }
    }
}
