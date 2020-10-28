using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PS.Models
{
    public class Services
    {
        [Key]
        public int Id { get; set; }
        public float? Miles { get; set; }
        public float? TotPrice { get; set; }
        public string Details { get; set; }
        public DateTime DateAdded { get; set; }
        public int? CarsId { get; set; }
        public ServiceTypes ServiceTypes{ get; set; }

        public int ServiceTypeId { get; set; }
    }
}