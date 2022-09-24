using BuscaDicas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaDicasNegocio
{
    public interface Idicas
    {
        Task IncluirDicas(DicasModel dicasModel);
    }
}
