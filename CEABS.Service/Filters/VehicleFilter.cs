namespace CEABS.Service.Filters
{
    public class VehicleFilter
    {
        public string? Plate { get; set; }
        public string? ModelName { get; set; }
        public string? ColorName { get; set; }
        public string? StartCreateDate { get; set; }
        public string? EndCreateDate { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
}
