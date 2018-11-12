using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BirdSightings.Models;
using Dapper;

namespace BirdSightings.Repositories
{
    public class SpeciesRepository
    {
        private DbConnection conn { get; set; }

        public SpeciesRepository(DbConnection conn) {
            this.conn = conn;
        }

        public async Task<int> AddAsync(String item) {
            var rslt = await conn.ExecuteAsync("INSERT INTO species " +
                            "(name) VALUES (@name)",
                            new { name = item });
            return rslt;

        }

        public async Task<IEnumerable<Species>> GetAllAsync() {
            return await conn.QueryAsync<Species>("SELECT * FROM species");
        }
    }
}
