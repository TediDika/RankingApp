using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RankingApp.Models;
using RankingApp.Repositories;

namespace RankingApp.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ItemContext _context;
        private ItemRepository _itemRepository;

        public UnitOfWork(ItemContext context)
        {
            _context = context;
        }

        public ItemRepository ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                {
                    this._itemRepository = new ItemRepository(_context);
                }
                return _itemRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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