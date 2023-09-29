using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore; // Add this line
using RankingApp.Models;
using RankingApp;
using RankingApp.Repositories;

namespace RankingApp.ItemRepository
{
    public class ItemRepository : IItemRepository, IDisposable
    {
        private ItemContext context;

        public ItemRepository(ItemContext context)
        {
            this.context = context;
        }

        public IEnumerable<ItemModel> GetItems()
        {
            return context.Items.ToList();
        }

        public ItemModel GetItemByID(int id)
        {
            return context.Items.Find(id);
        }

        public void InsertItem(ItemModel student)
        {
            context.Items.Add(student);
        }

        public void DeleteItem(int itemId)
        {
            ItemModel item = context.Items.Find(itemId);
            context.Items.Remove(item);
        }

        public void UpdateItem(ItemModel item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}