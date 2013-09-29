using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using AutoMapper;

namespace sep24migrations.ViewModels
{
    // Notice the superclass
    public class Repo_Program : RepositoryBase
    {
        /// <summary>
        /// Get all, for a lookup list
        /// </summary>
        /// <returns>Collection, ProgramList, sorted by Code</returns>
        public IEnumerable<ProgramList> GetList()
        {
            var programs = ds.Programs.OrderBy(o => o.Code);

            // AutoMapper needs two things (minimum) to work:
            // 1) A map 'definition' statement, which defines the source-and-target class mapping
            // 2) A map 'execute' statement, which performs the mapping

            // In this example, the 'definition' statements are in Global.asax.cs 

            // Execute... 
            return Mapper.Map<IEnumerable<ViewModels.ProgramList>>(programs);
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>Collection, ProgramFull, sorted by Code</returns>
        public IEnumerable<ProgramFull> GetAll()
        {
            var programs = ds.Programs.OrderBy(o => o.Code);

            return Mapper.Map<IEnumerable<ViewModels.ProgramFull>>(programs);
        }

        /// <summary>
        /// Get all, with the associated Subject object collections
        /// </summary>
        /// <returns>Collections (nested), ProgramWithSubjects, sorted by code</returns>
        public IEnumerable<ProgramWithSubjects> GetAllWithSubjects()
        {
            // Note that we must .Include("Subjects") to fetch the associated objects
            var programs = ds.Programs.Include("Subjects").OrderBy(o => o.Code);

            return Mapper.Map<IEnumerable<ProgramWithSubjects>>(programs);
        }

        /// <summary>
        /// Get one by its Id
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>ProgramFull object, or null if not found</returns>
        public ProgramFull GetById(int id)
        {
            var program = ds.Programs.Find(id);

            return (program == null) ? null : Mapper.Map<ProgramFull>(program);
        }

        /// <summary>
        /// Add new
        /// </summary>
        /// <param name="newProgram">New ProgramPublic object</param>
        /// <returns>ProgramFull object</returns>
        public ProgramFull AddNew(ProgramPublic newProgram)
        {
            // Add the new Program object
            var p = ds.Programs.Add(Mapper.Map<Models.Program>(newProgram));
            ds.SaveChanges();

            return Mapper.Map<ViewModels.ProgramFull>(p);
        }

        /// <summary>
        /// Update existing
        /// </summary>
        /// <param name="updatedProgram">Replacement ProgramBase object</param>
        /// <returns>ProgramFull object</returns>
        public ProgramFull UpdateExisting(ProgramBase updatedProgram)
        {
            // Fetch the existing Program object
            var p = ds.Programs.Find(updatedProgram.Id);

            if (p == null)
            {
                return null;
            }
            else
            {
                // Fetch the object from the data store - ds.Entry(p)
                // Get its current values collection - .CurrentValues
                // Set those to the values provided - .SetValues(updatedProgram)
                ds.Entry(p).CurrentValues.SetValues(updatedProgram);
                // The SetValues method ignores missing properties, and navigation properties
                ds.SaveChanges();
                return Mapper.Map<ViewModels.ProgramFull>(p);
            }
        }

        /// <summary>
        /// Delete existing
        /// </summary>
        /// <param name="id">Identifier</param>
        public void DeleteExisting(int id)
        {
            // Fetch the existing Program object
            var p = ds.Programs.Find(id);

            if (p == null)
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
                    ds.Programs.Remove(p);
                    ds.SaveChanges();
                }
                catch (Exception) { }
            }
        }


    }

}
