using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// repositories need a reference to the app domain model classes
//using sep13v1.Models;
using AutoMapper;

namespace sep13v1.ViewModels
{
    // Notice the superclass
    public class Repo_Program : RepositoryBase
    {
        public IEnumerable<ProgramList> GetList()
        {
            var programs = ds.Programs;

            // Without AutoMapper...
            var newprograms = new List<ProgramList>();
            foreach (var program in programs)
            {
                newprograms.Add(new ProgramList() { Id = program.Id, Code = program.Code, Name = program.Name });
            }
            return newprograms;

            // Alternative, with AutoMapper...
            // (comment out the six lines of code above)

            // AutoMapper needs two things (minimum) to work:
            // 1) A map 'definition' statement, which defines the source-and-target class mapping
            // 2) A map 'execute' statement, which performs the mapping

            // In this example, we will write the 'definition' statement
            // However, in all of your work (and in future examples from me),
            // the 'definition' statements will go in Global.asax.cs 

            // Definition...
            Mapper.CreateMap<Models.Program, ViewModels.ProgramList>();

            // Execute...
            return Mapper.Map<IEnumerable<ViewModels.ProgramList>>(programs);
        }

        public IEnumerable<ProgramFull> GetAll()
        {
            var programs = ds.Programs;

            // Map 'definition'...
            Mapper.CreateMap<Models.Program, ViewModels.ProgramFull>();

            // Map 'execute'...
            return Mapper.Map<IEnumerable<ViewModels.ProgramFull>>(programs);
        }

        public ProgramFull GetById(int id)
        {
            var program = ds.Programs.Find(id);

            // See why we want to move the 'definition' statements to Global.asax.cs?
            Mapper.CreateMap<Models.Program, ViewModels.ProgramFull>();

            return (program == null) ? null : Mapper.Map<ProgramFull>(program);
        }

    }

}
