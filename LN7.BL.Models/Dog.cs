using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN7.BL.Models
{
    public class Dog
    {
        public Guid dog_id { get; set; }
        public string breed { get; set; }
        public int weight { get; set; }
        public string Image { get; set; }
        public byte[] ImageFile { get; set; }
        public bool german_orgin { get; set; }
        public bool fluffy_fur { get; set; }
        public bool flat_face { get; set; }
        public bool pointy_ears { get; set; }
        public bool short_legs { get; set; }
        public bool one_color { get; set; }
        public bool two_color { get; set; }
        public bool black { get; set; }
        public bool white { get; set; }
        public bool golden { get; set; }
        public bool curly_fur { get; set; }
        public bool china_orgin { get; set; }
        public bool curly_tail { get; set; }
        public bool straight_tail { get; set; }
        public bool crossbread { get; set; }
    }
}