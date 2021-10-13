using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRestExcercise.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemQuality { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Item Name: {Name}, Item ID: {Id}, Item Quality: {ItemQuality}, Quantity: {Quantity}";
        }
    }
}
