using PS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using PS.Models;
using System.Web;

namespace PS.Models.ViewModels
{
    public class AddServiceViewModel
    {
        public IEnumerable<ServiceTypes> ServiceTypes { get; set; }
        public Services Services { get; set; }
    }
}