﻿using Gighub.Models;
using Gighub.Repositories;

namespace Gighub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public GigRepository Gigs { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}