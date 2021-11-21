using System;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryManager
    {
        IAdmissionApplicationRepository AdmissionApplicationRepository { get; }
        IHouseRepository HouseRepository { get; }
        Task SaveAsync();
    }
}
