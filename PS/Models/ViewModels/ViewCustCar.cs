using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Models.ViewModels
{
    public class ViewCustCar
    {
        public Customer IEcust { get; set; }
        public IEnumerable<Car> IEcar { get; set; }
    }
}