using LN7.BL.Models;
using LN7.PL;
using Microsoft.EntityFrameworkCore.Storage;

namespace LN7.BL
{

    public static class DogManager
    {

        private const string Message = "Row does not exist.";

        public static List<Dog> Load()
        {
            try
            {
                List<Dog> rows = new List<Dog>();

                using (LN7Entities dc = new LN7Entities())
                {
                    var dogs = (from d in dc.tblDogs
                                select new
                                {
                                    d.Id,
                                    d.Imagepath,
                                    d.BreedName,
                                    d.DogGroup,
                                    d.CoatColor,
                                    d.CoatType,
                                    d.CoatLength,
                                    d.EarType,
                                    d.EarLength,
                                    d.LegLength,
                                    d.BodyType,
                                    d.MuzzleType,
                                    d.MuzzleLength,
                                    d.Origin,
                                    d.TailType,
                                    d.TailLength,
                                    d.WeightClass

                                }).ToList();
                    dogs.ForEach(d => rows.Add(new Models.Dog
                    {
                        Id = d.Id,
                        Imagepath = d.Imagepath,
                        BodyType = d.BodyType,
                        BreedName = d.BreedName,
                        CoatColor = d.CoatColor,
                        CoatType = d.CoatType,
                        CoatLength = d.CoatLength,
                        EarType = d.EarType,
                        EarLength = d.EarLength,
                        LegLength = d.LegLength,
                        MuzzleType = d.MuzzleType,
                        MuzzleLength = d.MuzzleLength,
                        Origin = (int)d.Origin,
                        TailType = d.TailType,
                        TailLength = d.TailLength,
                        WeightClass = d.WeightClass,
                    }));
                }
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Dog LoadById(int id)
        {
            try
            {
                using (LN7Entities dc = new LN7Entities())
                {
                    tblDog dogs = dc.tblDogs.FirstOrDefault(s => s.Id == id);

                    if (dogs != null)
                    {
                        return new Dog
                        {
                            Id = dogs.Id,
                            Imagepath = dogs.Imagepath,
                            BodyType = dogs.BodyType,
                            BreedName = dogs.BreedName,
                            CoatColor = dogs.CoatColor,
                            CoatType = dogs.CoatType,
                            CoatLength = dogs.CoatLength,
                            EarType = dogs.EarType,
                            EarLength = dogs.EarLength,
                            LegLength = dogs.LegLength,
                            MuzzleType = dogs.MuzzleType,
                            MuzzleLength = dogs.MuzzleLength,
                            Origin = (int)dogs.Origin,
                            TailType = dogs.TailType,
                            TailLength = dogs.TailLength,
                            WeightClass = dogs.WeightClass,

                        };
                    }
                    else
                    {
                        throw new Exception(Message);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int Insert(Dog dog, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (LN7Entities dc = new LN7Entities())
                {

                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblDog row = new tblDog();

                    row.Id = dc.tblDogs.Any() ? dc.tblDogs.Max(s => s.Id) + 1 : 1;
                    row.Imagepath = dog.Imagepath;
                    row.BodyType = dog.BodyType;
                    row.BreedName = dog.BreedName;
                    row.CoatColor = dog.CoatColor;
                    row.CoatLength = dog.CoatLength;
                    row.CoatType = dog.CoatType;
                    row.CoatLength = dog.CoatLength;
                    row.CoatType = dog.CoatType;
                    row.DogGroup = dog.DogGroup;
                    row.EarLength = dog.EarLength;
                    row.EarType = dog.EarType;
                    row.Imagepath = dog.Imagepath;
                    row.LegLength = dog.LegLength;
                    row.MuzzleLength = dog.MuzzleLength;
                    row.MuzzleType = dog.MuzzleType;
                    row.Origin = dog.Origin;
                    row.TailLength = dog.TailLength;
                    row.TailType = dog.TailType;
                    row.WeightClass = dog.WeightClass;

                    dog.Id = row.Id;

                    dc.tblDogs.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();

                }

                return results;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (LN7Entities dc = new LN7Entities())
                {

                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblDog row = dc.tblDogs.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        dc.tblDogs.Remove(row);
                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                return results;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public static int Update(Dog dog, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (LN7Entities dc = new LN7Entities())
                {

                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblDog row = dc.tblDogs.Where(s => s.Id == dog.Id).FirstOrDefault();

                    if (row != null)
                    {
                        row.Id = dog.Id;
                        row.Imagepath = dog.Imagepath;
                        row.BodyType = dog.BodyType;
                        row.BreedName = dog.BreedName;
                        row.CoatColor = dog.CoatColor;
                        row.CoatLength = dog.CoatLength;
                        row.CoatType = dog.CoatType;
                        row.DogGroup = dog.DogGroup;
                        row.EarLength = dog.EarLength;
                        row.EarType = dog.EarType;
                        row.Imagepath = dog.Imagepath;
                        row.LegLength = dog.LegLength;
                        row.MuzzleLength = dog.MuzzleLength;
                        row.MuzzleType = dog.MuzzleType;
                        row.Origin = dog.Origin;
                        row.TailLength = dog.TailLength;
                        row.TailType = dog.TailType;
                        row.WeightClass = dog.WeightClass;
                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                return results;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        //ALL TABLES LOAD STATMENTS *IGNORE*
        public static List<BodyType> LoadBody()
        {
            try
            {
                List<BodyType> rows = new List<BodyType>();
                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblBodyTypes
                        .ToList()
                        .ForEach(s => rows.Add(new BodyType
                        {
                            Id = s.Id,
                            Description = s.Description,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<CoatColor> CoatColorLoad()
        {
            try
            {
                List<CoatColor> rows = new List<CoatColor>();
                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblCoatColors
                        .ToList()
                        .ForEach(s => rows.Add(new CoatColor
                        {
                            Id = s.Id,
                            Description = s.Description,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<CoatLength> CoatLengthLoad()
        {
            try
            {
                List<CoatLength> rows = new List<CoatLength>();
                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblCoatLengths
                        .ToList()
                        .ForEach(s => rows.Add(new CoatLength
                        {
                            Id = s.Id,
                            Description = s.Description,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<CoatType> CoatTypeLoad()
        {
            try
            {
                List<CoatType> rows = new List<CoatType>();
                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblCoatTypes
                        .ToList()
                        .ForEach(s => rows.Add(new CoatType
                        {
                            Id = s.Id,
                            Description = s.Description,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Group> LoadGroup()
        {
            try
            {
                List<Group> rows = new List<Group>();
                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblDogGroups
                        .ToList()
                        .ForEach(s => rows.Add(new Group
                        {
                            Id = s.Id,
                            Description = s.Description,

                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EarLength> EarLengthLoad()
        {
            try
            {
                List<EarLength> rows = new List<EarLength>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblEarLengths
                        .ToList()
                        .ForEach(s => rows.Add(new EarLength
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<EarType> EarTypeLoad()
        {
            try
            {
                List<EarType> rows = new List<EarType>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblEarTypes
                        .ToList()
                        .ForEach(s => rows.Add(new EarType
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<LegLength> LegLengthLoad()
        {
            try
            {
                List<LegLength> rows = new List<LegLength>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblLegLengths
                        .ToList()
                        .ForEach(s => rows.Add(new LegLength
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<MuzzleLength> MuzzleLengthLoad()
        {
            try
            {
                List<MuzzleLength> rows = new List<MuzzleLength>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblMuzzleLengths
                        .ToList()
                        .ForEach(s => rows.Add(new MuzzleLength
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<MuzzleType> MuzzleTypeLoad()
        {
            try
            {
                List<MuzzleType> rows = new List<MuzzleType>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblMuzzleTypes
                        .ToList()
                        .ForEach(s => rows.Add(new MuzzleType
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Origin> OriginTypeLoad()
        {
            try
            {
                List<Origin> rows = new List<Origin>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblOrigins
                        .ToList()
                        .ForEach(s => rows.Add(new Origin
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<TailLength> TailLengthLoad()
        {
            try
            {
                List<TailLength> rows = new List<TailLength>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblTailLengths
                        .ToList()
                        .ForEach(s => rows.Add(new TailLength
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<TailType> TailTypeLoad()
        {
            try
            {
                List<TailType> rows = new List<TailType>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblTailTypes
                        .ToList()
                        .ForEach(s => rows.Add(new TailType
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<WeightClass> WeightClassLoad()
        {
            try
            {
                List<WeightClass> rows = new List<WeightClass>();

                using (LN7Entities dc = new LN7Entities())
                {
                    dc.tblWeightClasses
                        .ToList()
                        .ForEach(s => rows.Add(new WeightClass
                        {
                            Id = s.Id,
                            Description = s.Description,
                        }));
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
