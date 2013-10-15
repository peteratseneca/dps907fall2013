using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using AutoMapper;

namespace LinkRelationsIntro.ViewModels
{
    public class Repo_Album : RepositoryBase
    {
        // Get list

        // Get all
        public IEnumerable<AlbumFull> GetAll()
        {
            var all = ds.Albums.OrderBy(o => o.Name);
            return Mapper.Map<IEnumerable<AlbumFull>>(all);
        }

        // Get one by identifier
        public AlbumFull GetById(int id)
        {
            var one = ds.Albums.Find(id);

            return (one == null) ? null : Mapper.Map<AlbumFull>(one);
        }

    }
}
