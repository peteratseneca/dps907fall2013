using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using AutoMapper;

namespace sep17v1.ViewModels
{
    // Notice the superclass
    public class Repo_Subject : RepositoryBase
    {
        /// <summary>
        /// Get all, for a lookup list
        /// </summary>
        /// <returns>Collection, SubjectList, sorted by Code</returns>
        public IEnumerable<SubjectList> GetList()
        {
            var subjects = ds.Subjects.OrderBy(o => o.Code);
            // There's probably a better way to sort these
            // Maybe by semester (the first digit, or digits), then alpha code

            return Mapper.Map<IEnumerable<SubjectList>>(subjects);
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>Collection, SubjectFull, sorted by code</returns>
        public IEnumerable<SubjectFull> GetAll()
        {
            var subjects = ds.Subjects.OrderBy(o => o.Code);
            // There's probably a better way to sort these
            // Maybe by semester (the first digit, or digits), then alpha code

            return Mapper.Map<IEnumerable<SubjectFull>>(subjects);
        }

        /// <summary>
        /// Get one by its Id
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>SubjectFull object, or null if not found</returns>
        public SubjectFull GetById(int id)
        {
            var subject = ds.Subjects.Find(id);

            return (subject == null) ? null : Mapper.Map<SubjectFull>(subject);
        }

        /// <summary>
        /// Add new
        /// </summary>
        /// <param name="newSubject">New SubjectPublic object</param>
        /// <returns>SubjectFull object</returns>
        public SubjectFull AddNew(SubjectPublic newSubject)
        {
            // Add the Subject object
            var s = ds.Subjects.Add(Mapper.Map<Models.Subject>(newSubject));
            ds.SaveChanges();

            return Mapper.Map<SubjectFull>(s);
        }

        /// <summary>
        /// Update existing
        /// </summary>
        /// <param name="updatedSubject">Replacement SubjectFull object</param>
        /// <returns>SubjectFull object</returns>
        public SubjectFull UpdateExisting(SubjectFull updatedSubject)
        {
            // Fetch the existing Subject object
            var s = ds.Subjects.Find(updatedSubject.Id);

            if (s==null)
            {
                return null;
            }
            else
            {
                // Fetch the object from the data store - ds.Entry(s)
                // Get its current values collection - .CurrentValues
                // Set those to the values provided - .SetValues(updatedSubject)
                ds.Entry(s).CurrentValues.SetValues(updatedSubject);
                // The SetValues method ignores missing properties, and navigation properties
                ds.SaveChanges();
                return Mapper.Map<ViewModels.SubjectFull>(s);
            }
        }

        /// <summary>
        /// Delete existing
        /// </summary>
        /// <param name="id">Identifier</param>
        public void DeleteExisting(int id)
        {
            // Fetch the existing Program object
            var s = ds.Subjects.Find(id);

            if (s == null)
            {
                // Throw an exception, in 'version 2' of error and exception handling
            }
            else
            {
                try
                {
                    // If this fails, throw an exception, in 'version 2'...
                    // It may fail because of the presence of associated objects
                    // This implementation prevents the exception from bubbling up
                    ds.Subjects.Remove(s);
                    ds.SaveChanges();
                }
                catch (Exception) { }
            }
        }

    }

}