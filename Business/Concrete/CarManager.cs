using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }

            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(int id)
        {
            var selectedCar = _carDal.Get(car => car.Id == id);
            if (selectedCar != null)
            {
                _carDal.Delete(selectedCar);
                return new Result(true, Messages.CarNotDelete);
            }
            return new ErrorResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(car => car.Id == id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

    }
}
