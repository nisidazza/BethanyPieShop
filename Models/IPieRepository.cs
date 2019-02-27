using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies(); //this will return all pies 

        Pie GetPieById(int pieId);  //this retrieves pies per Id
    }
}
