using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAdmissionApplicationRepository
    {
        Task<IEnumerable<AdmissionApplication>> GetAll (AdmissionApplicationParameters parameters, bool trackChanges);
        Task<AdmissionApplication> Get(int id, bool trackChanges);
        Task Create(AdmissionApplication model);
        void Delete(AdmissionApplication model);
    }
}
