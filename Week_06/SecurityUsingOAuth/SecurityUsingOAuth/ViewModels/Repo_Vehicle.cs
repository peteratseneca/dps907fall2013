using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using AutoMapper;

namespace SecurityUsingOAuth.ViewModels
{
    public class Repo_Vehicle : RepositoryBase
    {
        // Get list
        // Provide your own implementation

        // Get all
        public IEnumerable<VehicleBase> GetAll()
        {
            var all = ds.Vehicles.OrderBy(o => o.MSRP);
            return Mapper.Map<IEnumerable<VehicleBase>>(all);
        }

        // Get one
        public VehicleFull GetById(int id)
        {
            var one = ds.Vehicles.Find(id);

            return (one == null) ? null : Mapper.Map<VehicleFull>(one);
        }

        // Add new
        public VehicleFull AddNew(VehiclePublic vehicle)
        {
            var v = ds.Vehicles.Add(Mapper.Map<Models.Vehicle>(vehicle));
            ds.SaveChanges();

            return Mapper.Map<ViewModels.VehicleFull>(v);
        }

        // Update existing
        // Provide your own implementation

        // Update existing, photo only
        public VehicleFull UpdateExistingPhoto(int id, string contentType, byte[] photo)
        {
            var v = ds.Vehicles.Find(id);

            if (v == null)
            {
                return null;
            }
            else
            {
                v.Photo = photo;
                v.ContentType = contentType;
                ds.SaveChanges();
                return Mapper.Map<VehicleFull>(v);
            }
        }

        // Delete existing
        // Provide your own implementation

    }

}
