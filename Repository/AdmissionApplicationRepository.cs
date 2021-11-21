using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AdmissionApplicationRepository : IAdmissionApplicationRepository
    {
        private readonly RepositoryContext _context;

        public AdmissionApplicationRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task Create(AdmissionApplication model)
        {
            await _context.AdmissionApplications.AddAsync(model);
        }

        public void Delete(AdmissionApplication model)
        {
            _context.Remove(model);
        }

        public async Task<AdmissionApplication> Get(int id, bool trackChanges)
        {
            if(trackChanges)
                return await _context.AdmissionApplications.Include(x => x.House).SingleOrDefaultAsync(x => x.Id == id);

            return await _context.AdmissionApplications.Include(x => x.House).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        }

        public async Task<IEnumerable<AdmissionApplication>> GetAll(AdmissionApplicationParameters parameters, bool trackChanges)
        {
            if (trackChanges)
            {
                return await _context.AdmissionApplications
                                     .Include(x => x.House)
                                     .FilterByName(parameters.SearchName) 
                                     .FilterByLastName(parameters.SearchLastName)
                                     .FilterByIdentification(parameters.InitIdentification, parameters.EndIdentification)
                                     .FilterByAge(parameters.InitAge, parameters.EndAge)
                                     .FilterByIdHouse(parameters.IdHouse)
                                     .ToListAsync();
            }

            return await _context.AdmissionApplications
                                 .Include(x => x.House)
                                 .FilterByName(parameters.SearchName)
                                 .FilterByLastName(parameters.SearchLastName)
                                 .FilterByIdentification(parameters.InitIdentification, parameters.EndIdentification)
                                 .FilterByAge(parameters.InitAge, parameters.EndAge)
                                 .FilterByIdHouse(parameters.IdHouse)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
