namespace LN7.BL.Models
{
    public class Dog
    {
        //public List<GameQuestion> Questions { get; set; } = new List<GameQuestion>();
        public Guid Dog_Id { get; set; }

        public string BreedName { get; set; }
        public string Imagepath { get; set; }
        public int DogGroup { get; set; }
        public int CoatColor { get; set; }
        public int CoatType { get; set; }
        public int CoatLength { get; set; }
        public int EarType { get; set; }
        public int EarLength { get; set; }
        public int LegLength { get; set; }
        public int BodyType { get; set; }
        public int MuzzleType { get; set; }
        public int MuzzleLength { get; set; }
        public int Origin { get; set; }
        public int TailType { get; set; }
        public int TailLength { get; set; }
        public int WeightClass { get; set; }
    }
}