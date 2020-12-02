using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
