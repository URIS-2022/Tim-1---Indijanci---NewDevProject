﻿using Licitacija.Services.AdresaAPI.DbContexts;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;

namespace Licitacija.Services.AdresaAPI.Repositories.ConcreteClasses
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IGenericRepository<Adresa> _adresa;
        private IGenericRepository<Drzava> _drzava;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IGenericRepository<Adresa> Adresa => _adresa ??= new GenericRepository<Adresa>(_context);

        public IGenericRepository<Drzava> Drzava => _drzava ??= new GenericRepository<Drzava>(_context);

        public void Dispose()
        {
            _context.Dispose();//oslobodjanje resursa
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
