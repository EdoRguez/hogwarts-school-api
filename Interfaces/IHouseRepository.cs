using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IHouseRepository
    {
        Task<House> Get(int id, bool trackChanges);
    }
}
