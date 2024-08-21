using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        private readonly IRentalDal _rentalDal;
        private readonly ICarDal _carDal;
        private readonly IValidator<Rental> _rentalValidator;

        public RentalManager(IRentalDal rentalDal, IValidator<Rental> rentalValidator, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _rentalValidator = rentalValidator;
            _carDal = carDal;
        }


        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(_rentalValidator, rental);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            //ValidationTool.Validate(new RentalValidator(), Rental);

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}