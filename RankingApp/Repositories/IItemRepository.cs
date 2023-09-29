using System;
using System.Collections.Generic;
using RankingApp.Models;

namespace RankingApp.Repositories
{
    public interface IItemRepository : IDisposable
    {

        IEnumerable<ItemModel> GetItems();
        ItemModel GetItemByID(int itemId);
        void InsertItem(ItemModel item);
        void DeleteItem(int itemID);
        void UpdateItem(ItemModel item);
        void Save();
    }
}
