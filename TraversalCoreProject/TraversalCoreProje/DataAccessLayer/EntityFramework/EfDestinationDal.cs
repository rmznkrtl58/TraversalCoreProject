﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var ent=new Context())
            {
                return ent.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLast4DestinationList()
        {
            using (var ent = new Context())
            {
                return ent.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
            }
        }
    }
}
