using Shipwharf.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Shipwharf.Infrastructure
{
    public interface IShipRepository
    {
        Task<Ship> CreateShipAsync(Ship ship);
    }
}