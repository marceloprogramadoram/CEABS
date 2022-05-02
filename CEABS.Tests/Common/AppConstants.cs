using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEABS.Tests.Common
{
    public static class AppConstants
    {
        public const string AppBase = "/api/";
        public const string ModelCarPath = $"{AppBase}ModelCar";
        public const string ModelCarAddPath = $"{AppBase}ModelCar/Add";
        public const string ProducerPath = $"{AppBase}Producer";
        public const string ProducerAddPath = $"{AppBase}Producer/Add";
        public const string VehiclePath = $"{AppBase}Vehicle";
        public const string VehicleSummaryPath = $"{AppBase}Vehicle/summary";
        public const string VehicleFilterPath = $"{AppBase}Vehicle/all";
    }
}
