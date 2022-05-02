using CEABS.Domain.Entities;
using CEABS.Infrastructure.Contexts;
using CEABS.Service.DTO;
using System.Collections.Generic;

namespace CEABS.Tests.Config
{
    public static class Utilities
    {
        public static void InitializeDbForTest(CeabsContext db)
        {
            db.ModelCars.AddRange(GetSeedingModelCars());
            db.Producers.AddRange(GetSeedingProducer());
            db.Vehicles.AddRange(GetSeedingVehicle());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTest(CeabsContext db)
        {
            db.ModelCars.RemoveRange(db.ModelCars);
            db.Producers.RemoveRange(db.Producers); 
            db.Vehicles.RemoveRange(db.Vehicles);
            InitializeDbForTest(db);
        }


        public static List<ModelCar> GetSeedingModelCars()
        {
            return new List<ModelCar>()
            {
                new ModelCar(1, "GOL"),
                new ModelCar(2,"Mobi"),
                new ModelCar(3,"Saveiro"),
                new ModelCar(4,"Strada")
            };
        }


        public static List<Producer> GetSeedingProducer()
        {
            return new List<Producer>()
            {
                new Producer(1,"VW"),
                new Producer(2,"Fiat"),
                new Producer(3,"VW"),
                new Producer(4,"Fiat")
            };
        }


        public static List<Vehicle> GetSeedingVehicle()
        {
            return new List<Vehicle>()
            {
                new Vehicle("JHT-9088","Cinza",2015, 1, 2),
                new Vehicle("JHY-9048","Azul",2015, 2, 2),
                new Vehicle("JRT-9388","Vermelho",2015, 3, 5),
                new Vehicle("FGR-9258","Preto",2015, 2, 4)
            };
        }

    }
}
