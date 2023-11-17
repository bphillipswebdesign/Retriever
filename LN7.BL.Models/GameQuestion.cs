namespace LN7.BL.Models
{
    public class GameQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string UniqueToken { get; set; }
        public int Trait_Id { get; set; }
        public int Answer { get; set; }

        public static implicit operator GameQuestion(List<int> v)
        {
            throw new NotImplementedException();
        }
    }
}