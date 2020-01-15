using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsApi.Models;

namespace ItemsApi.Repository
{
    public class FakeRepository : IRepository
    {
        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(int id)
        {
            return items.Single(i => i.Id == id);
        }

        public Item CreateItem(Item item)
        {
            item.Id = items.OrderByDescending(i => i.Id).First().Id + 1;
            items.Add(item);
            return item;
        }

        public Item UpdateItem(Item item)
        {
            var toUpdate = items.First(i => i.Id == item.Id);
            toUpdate.Id = item.Id;
            toUpdate.Name = item.Name;
            toUpdate.Description = item.Description;
            return toUpdate;
        }

        public void DeleteItem(int id)
        {
            var toRemove = items.Find(i => i.Id == id);
            items.Remove(toRemove);
        }


        private static List<Item> items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Item1",
                Description = "Description1"
            },
            new Item
            {
                Id = 2,
                Name = "Item2",
                Description = "Description2"
            },
            new Item
            {
                Id = 3,
                Name = "Item3",
                Description = "Description3"
            }
        };

    }
}
