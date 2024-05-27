using ApiPelisAWSAnita.Data;
using ApiPelisAWSAnita.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPelisAWSAnita.Repositories
{
    public class RepositoryPelis
    {
        private PelisContext context;
        public RepositoryPelis ( PelisContext context)
        {
            this.context = context;
        }

        public async Task<List<Peli>> GetPelisAsync()
        {
            return await this.context.Pelis.ToListAsync();
        }

        public async Task<List<Peli>> GetPelisActorAsync
            (string actor)
        {
            return await 
                this.context.Pelis
                .Where(x => x.Actores.Contains(actor))
                .ToListAsync();
        }

    }
}
