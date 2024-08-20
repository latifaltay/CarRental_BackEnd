using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        CarRentalContext _carContext;
        
        public EfRentalDal(CarRentalContext carRentalContex, CarRentalContext carContex) : base(carRentalContex)
        {
            _carContext = carContex;
        }
    }
}
