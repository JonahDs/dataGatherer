using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataGatherer.Models
{
    public class Model
    {
        public int ID { get; set; }
        public double ServerCalledAt { get; set; }
        public double RequestDuration { get; set; }
        public double RequestFinishedAt { get; set; }
        public double GridRendered { get; set; }
        public double LoadTime { get; set; }
        public int AmountOfRecordsLoaded { get; set; }
        public string DataSourceUrl { get; set; }
    }
}
