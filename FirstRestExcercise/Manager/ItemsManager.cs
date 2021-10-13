using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRestExcercise.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstRestExcercise.Manager
{
    public class ItemsManager
    {
        private static int _nextId = 1;
        private static readonly List<Item> Data = new List<Item>
        {
            new Item {Id = _nextId++, Name = "A Cool Item", Quantity = 3, ItemQuality = 8},
            new Item {Id= _nextId++, Name = "A Nice Item", Quantity = 22, ItemQuality = 5}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<Item> GetAll(string substring)
        {
            if (substring != null)
            {
                return Data.FindAll(item => item.Name.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }
            
            return new List<Item>(Data);
            
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public List<Item> GetAllQuality(int quality)
        {
            if (quality != 0)
            {
                return Data.FindAll(item => item.ItemQuality.Equals(quality));
            }

            return new List<Item>(Data);
        }

        public List<Item> GetAllQuantity(int quantity)
        {
            if (quantity != 0)
            {
                return Data.FindAll(item => item.ItemQuality.Equals(quantity));
            }

            return new List<Item>(Data);
        }


        public Item GetById(int id)
        {
            return Data.Find(item => item.Id == id);
        }

        public Item Add(Item newItem)
        {
            newItem.Id = _nextId++;
            Data.Add(newItem);
            return newItem;
        }

        public Item Delete(int id)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            Data.Remove(item);
            return item;
        }

        public Item Update(int id, Item updates)
        {
            Item item = Data.Find(item1 => item1.Id == id);
            if (item == null) return null;
            item.Name = updates.Name;
            item.Quantity = updates.Quantity;
            item.ItemQuality = updates.ItemQuality;
            return item;
        }

    }
}
