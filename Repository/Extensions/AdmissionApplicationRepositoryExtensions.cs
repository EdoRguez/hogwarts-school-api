using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Extensions
{
    public static class AdmissionApplicationRepositoryExtensions
    {
        public static IQueryable<AdmissionApplication> FilterByName(this IQueryable<AdmissionApplication> admissions, string name)
        {
            if (String.IsNullOrEmpty(name))
                return admissions;

            string formattedName = name.ToLower().Trim();

            return admissions.Where(x => x.Name.ToLower().Contains(formattedName));
        }

        public static IQueryable<AdmissionApplication> FilterByLastName(this IQueryable<AdmissionApplication> admissions, string lastName)
        {
            if (String.IsNullOrEmpty(lastName))
                return admissions;

            string formattedLastName = lastName.ToLower().Trim();

            return admissions.Where(x => x.LastName.ToLower().Contains(formattedLastName));
        }

        public static IQueryable<AdmissionApplication> FilterByIdentification(this IQueryable<AdmissionApplication> admissions, long? initIdentification, long? endIdentification)
        {
            if (initIdentification == null && endIdentification == null)
            {
                return admissions;
            }
            else if (initIdentification != null && endIdentification == null)
            {
                return admissions.Where(x => x.Identification >= initIdentification);
            }
            else if (initIdentification == null && endIdentification != null)
            {
                return admissions.Where(x => x.Identification <= endIdentification);
            }
            else
            {
                return admissions.Where(x => x.Identification >= initIdentification && x.Identification <= endIdentification);
            }
        }

        public static IQueryable<AdmissionApplication> FilterByAge(this IQueryable<AdmissionApplication> admissions, short? initAge, short? endAge)
        {
            if (initAge == null && endAge == null)
            {
                return admissions;
            }
            else if (initAge != null && endAge == null)
            {
                return admissions.Where(x => x.Age >= initAge);
            }
            else if (initAge == null && endAge != null)
            {
                return admissions.Where(x => x.Age <= endAge);
            }
            else
            {
                return admissions.Where(x => x.Age >= initAge && x.Age <= endAge);
            }
        }

        public static IQueryable<AdmissionApplication> FilterByIdHouse(this IQueryable<AdmissionApplication> admissions, int? idHouse)
        {
            if (idHouse == null)
                return admissions;

            return admissions.Where(x => x.Id_House == idHouse);
        }
    }
}
