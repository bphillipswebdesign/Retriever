using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN7.BL.Models
{
    public class PlayerStat
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PlayDate { get; set; }
        public bool Result { get; set; }
    }
}
