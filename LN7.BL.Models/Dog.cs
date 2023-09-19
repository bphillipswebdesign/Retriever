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
        public string breedname { get; set; }
        public string Image { get; set; }
        public byte[] ImageFile { get; set; }
        public int group { get; set; }
        public int coatcolor { get; set; }
        public int coattype { get; set; }
        public int coatlength { get; set; }
        public int eartype { get; set; }
        public int earlength { get; set; }
        public int leglength { get; set; }
        public int bodytype { get; set; }
        public int muzzletype { get; set; }
        public int muzzlelength { get; set; }
        public int origin { get; set; }
        public int tailtype { get; set; }
        public int taillength { get; set; }
        public int weightclass { get; set; }
    }
}