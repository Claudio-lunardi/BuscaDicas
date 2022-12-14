using BuscaDicas.Infra.Entity;
using BuscaDicas.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaDicasNegocio
{
    public class Dicas : Idicas
    {
        private readonly EntityContext _entityContext;

        public Dicas(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<List<DicasModel>> BuscarDicas()
        {
            return await _entityContext.Dicas.ToListAsync();
        }

        public async Task IncluirDicas(DicasModel dicasModel)
        {
            await _entityContext.Dicas.AddAsync(dicasModel);
            await _entityContext.SaveChangesAsync();
        }
    }
}
