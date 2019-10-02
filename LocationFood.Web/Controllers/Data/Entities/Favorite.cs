using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data.Entities
{
    public class Favorite
    {
        public int Id { get; set; }       
        public string Calification { get; set; }

        public Customer Customer { get; set; }

        public Restaurant Restaurant { get; set; }


    }
}
