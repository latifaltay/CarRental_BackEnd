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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {

        CarRentalContext _carContex;

        public EfCarDal(CarRentalContext carRentalContex, CarRentalContext carContex) : base(carRentalContex)
        {
            _carContex = carContex;
        }


        public List<CarDetailDto> GetCarDetails() 
        {

            using (CarRentalContext contex = new CarRentalContext())
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

        public bool IsContain(string name) 
        {
            var result = _carContex.Cars.Where(c => c.Name == name).FirstOrDefault();
            
            if (result != null)
            {
                return false;
            }
            return true;

        }

        // düzeltilecek

        public bool IsAvailable() 
        {
            var result = _carContex.Cars.Any(c => c.IsAvailable == false);
            return result;
        }

    }
}
