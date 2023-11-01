using System.ComponentModel;

namespace LN7.WebUI.ViewModels
{
    public class PlayerStatVM
    {
        public int Id { get; set; }
        [DisplayName("User Name")]
        public string Username { get; set; }
        public Guid UserId { get; set; }
        [DisplayName("Date Played")]
        public DateTime PlayDate { get; set; }
        [DisplayName("Correct Guess")]
        public bool Result { get; set; }
    }
}
