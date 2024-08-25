using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IValidator<Car> _carValidator;
        public CarManager(ICarDal carDal, IValidator<Car> carValidator)
        {
            _carDal = carDal;
            _carValidator = carValidator;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            // AOP kurulduğu için bunu kullanmıyoruz
            //ValidationTool.Validate(_carValidator, car);
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            var selectedCar = _carDal.Get(c => c.Id == car.Id);
            if (selectedCar != null)
            {
                _carDal.Delete(selectedCar);
                return new Result(true, Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNotFound);
        }

        public IResult Update(Car car)
        {
            if (car.Name.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }

            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            var IsThereCar = _carDal.Get(c => c.Id == id);
            if (IsThereCar == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarNotFound);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));
        }

    }
}
