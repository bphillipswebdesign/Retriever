using LN7.BL.Models;
using LN7.BL;
using LN7.PL;

namespace LN7.WebUI.ViewModels
{
    public class DogVM
    {
        public Dog Dog { get; set; }
        public List <BodyType> BodyTypes { get; set; }
        public List <CoatColor> CoatColors { get; set; }
        public List <CoatLength> CoatLengths { get; set; }
        public List <CoatType> CoatTypes { get; set; }
        public List <Group> Groups { get; set; }
        public List <EarLength> EarLengths { get; set; }
        public List <EarType> EarTypes { get; set; }
        public List <LegLength> LegLengths { get; set; }    
        public List <MuzzleLength> MuzzleLengths { get; set; }
        public List <MuzzleType> MuzzleTypes { get; set; }
        public List <Origin> OriginTypes { get; set; }
        public List <TailLength> TailLengths { get; set; }  
        public List <TailType> TailTypes { get; set; }
        public List <WeightClass> WeightClasses { get; set; }



        public DogVM() 
        {
            BodyTypes = DogManager.LoadBody();
            CoatColors = DogManager.CoatColorLoad();
            CoatLengths = DogManager.CoatLengthLoad();
            CoatTypes = DogManager.CoatTypeLoad();
            Groups = DogManager.LoadGroup();
            EarLengths = DogManager.EarLengthLoad();
            EarTypes = DogManager.EarTypeLoad();
            LegLengths = DogManager.LegLengthLoad();
            MuzzleLengths = DogManager.MuzzleLengthLoad();
            MuzzleTypes = DogManager.MuzzleTypeLoad();
            OriginTypes = DogManager.OriginTypeLoad();
            TailLengths = DogManager.TailLengthLoad();
            TailTypes = DogManager.TailTypeLoad();
            WeightClasses = DogManager.WeightClassLoad();
        }
    }
}