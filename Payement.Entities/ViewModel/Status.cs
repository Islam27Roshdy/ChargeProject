using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payement.Entities.Entities;

namespace Payement.Entities.ViewModel
{
    public class Status
    {
        public double Points { get; set; }
        public StatusResponse StatusResponseObject { get; set; }
        public string StatusDescription { get; set; }
    }
}
