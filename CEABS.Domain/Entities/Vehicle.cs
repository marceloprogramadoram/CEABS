using System.Globalization;

namespace CEABS.Domain.Entities
{
    public sealed class Vehicle
    {
        public int Id { get; private set; }
        public string? Plate { get; private set; }
        public string? Color { get; private set; }
        public int YearFabrication { get; private set; }
        public int ModelCarId { get; private set; }
        public ModelCar? ModelCar { get;  set; }
        public int ProducerId { get; private set; }
        public Producer? Producer { get; set; }
        public DateTime? CreateDate { get; private set; }

        public Vehicle(string? plate, string? color, int yearFabrication, int modelCarId, int producerId )
        {
            Plate = plate;
            Color = color;
            YearFabrication = yearFabrication;
            ModelCarId = modelCarId;
            ProducerId = producerId;
            CreateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
    }
}
