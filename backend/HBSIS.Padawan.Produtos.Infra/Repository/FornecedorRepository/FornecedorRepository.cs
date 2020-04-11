using HBSIS.Padawan.Produtos.Domain.Entities;
using HBSIS.Padawan.Produtos.Domain.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSIS.Padawan.Produtos.Infra.Repository.FornecedorRepository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly MainContext _dbContext;
        protected readonly DbSet<FornecedorEntity> _dbSet;

        public FornecedorRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<FornecedorEntity>();
        }

        public async Task<FornecedorEntity> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(f => f.ID == id);
        }

        public async Task Create(FornecedorEntity fornecedor)
        {
            try
            {
                _dbSet.Add(fornecedor).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }

        public async Task Update(int id, FornecedorEntity fornecedor)
        {
            try
            {
                _dbSet.Update(fornecedor).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entityResult = await GetById(id);
                _dbContext.Remove(id).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados.");
            }
        }
        public IQueryable<FornecedorEntity> Query() => _dbSet.AsNoTracking().Where(f => !f.Deleted);
    }
}