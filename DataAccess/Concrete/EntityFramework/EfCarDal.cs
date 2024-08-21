using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;
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

        CarRentalContext _carContext;

        public EfCarDal(CarRentalContext carRentalContext, CarRentalContext carContext) : base(carRentalContext)
        {
            _carContext = carContext;
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
            var result = _carContext.Cars.Where(c => c.Name == name).FirstOrDefault();
            
            if (result != null)
            {
                return false;
            }
            return true;

        }

        public bool IsCarAvailable(int carId)
        {
            var car = _carContext.Cars.FirstOrDefault(c => c.Id == carId);
            return car != null && car.IsAvailable;
        }
        
    }
}
