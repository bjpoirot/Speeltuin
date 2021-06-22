using ShipwharfMVCSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ShipwharfMVCSolution.Data;

namespace ShipwharfMVCSolution.Repositories
{
    public class ADOShipsRepository : IShipsRepository
    {

        private readonly IConfiguration _configuration;
        public ADOShipsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ShipDetailsViewModel> GetShipDetails(Guid id)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var sql = $"SELECT TOP 1 s.Id, s.Hold, s.Name, t.Title " + 
                "FROM [dbo].[Ships] s " +
                "INNER JOIN [dbo].[ShipTypes] t ON t.Id = s.ShipTypeId " +
                $"WHERE s.Id = '{id}'";
            var command = new SqlCommand(sql, connection);
            await connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync(System.Data.CommandBehavior.SequentialAccess);
            await reader.ReadAsync();

            //var Name = reader.GetString(2);
            //var Name = reader.GetString(2);

            var ship = new ShipDetailsViewModel()
            {
                Id = reader.GetGuid(0),
                Hold = reader.GetString(1),
                Name = reader.GetString(2),
                Type = reader.GetString(3)
            };

            return ship;
        }

        Task<int> IShipsRepository.GetNumberOfShips()
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyCollection<ShipPageListItemViewModel>> IShipsRepository.GetShips(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
