using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext; // access to my AddDbContext via a constructor injection

        public PieRepository(AppDbContext appDbContext) //here I pass in an appDbContext and I'll make the local instance equal to the passed-in instance
        {
            _appDbContext = appDbContext;
        }
        //implementation of the interface
        public IEnumerable<Pie> GetAllPies()
        {
           return _appDbContext.Pies; //I use my DbContext to return all the pies from the context; 
            //this will check if the pies collection on the context has already been populated; if not, it will load in the data from the underlying database;
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.Id == pieId);
            //we use the context and its pies collection to retrieve the pie that matches the requested pieId 
        }
    }
}
