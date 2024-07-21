using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContex>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails() 
        {
            using (CarRentalContex contex = new CarRentalContex())
            {
                var result = from car in contex.Cars
                             join b in contex.Brands
                             on car.BrandId equals b.Id
                             join c in contex.Colors
                             on car.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Name,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
