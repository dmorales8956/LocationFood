using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [MaxLength(20)]
        public string FixedPhone { get; set; }
        [MaxLength(20)]
        public string  CellPhone { get; set; }

        [MaxLength(100)]
        public string  Address{ get; set; }

        public int  Chair { get; set; }


    }
}
