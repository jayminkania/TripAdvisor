using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IPlaceRepository
    {
        List<t_place> GetAll();

        t_place GetOne(int id);

        bool Add(t_place place);

        bool Update(t_place place);

        bool Delete(int id);
    }
}