using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IAdmissionApplicationRepository _admissionApplicationRepository;
        private IHouseRepository _houseRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IAdmissionApplicationRepository AdmissionApplicationRepository
        {
            get
            {
                if (_admissionApplicationRepository == null)
                    _admissionApplicationRepository = new AdmissionApplicationRepository(_repositoryContext);

                return _admissionApplicationRepository;
            }
        }

        public IHouseRepository HouseRepository
        {
            get
            {
                if (_houseRepository == null)
                    _houseRepository = new HouseRepository(_repositoryContext);

                return _houseRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
