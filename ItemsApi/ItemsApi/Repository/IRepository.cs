using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemsApi.Models;

namespace ItemsApi.Repository
{
    public interface IRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        Item CreateItem(Item item);
        Item UpdateItem(Item item);
        void DeleteItem(int id);
    }
}
