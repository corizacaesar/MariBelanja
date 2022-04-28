using TransaksiBelanja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransaksiBelanja.Data
{
    public interface IProduct:ICrud<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetByCategory(string name);
    }
}
