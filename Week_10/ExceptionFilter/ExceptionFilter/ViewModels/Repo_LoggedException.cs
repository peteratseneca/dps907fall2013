using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using AutoMapper;

namespace ExceptionFilter.ViewModels
{
    public class Repo_LoggedException : RepositoryBase
    {
        // Get list

        // Get all
        public IEnumerable<LoggedExceptionFull> GetAll()
        {
            var items = ds.LoggedExceptions.OrderByDescending(o => o.DateAndTime);
            return Mapper.Map<IEnumerable<LoggedExceptionFull>>(items);
        }

        // Get one by identifier
        public LoggedExceptionFull GetById(int id)
        {
            var item = ds.LoggedExceptions.Find(id);
            return (item == null) ? null : Mapper.Map<LoggedExceptionFull>(item);
        }

        // Add new
        public LoggedExceptionFull AddNew(LoggedExceptionAdd newItem)
        {
            var item = ds.LoggedExceptions.Add(Mapper.Map<Models.LoggedException>(newItem));
            ds.SaveChanges();

            return Mapper.Map<LoggedExceptionFull>(item);
        }

    }

}
