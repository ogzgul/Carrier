using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarrierConfigurationManager : ICarrierConfigurationService
    {
        ICarrierConfigurationDal _carrierConfigurationDal;

        public CarrierConfigurationManager(ICarrierConfigurationDal carrierConfigurationDal)
        {
            _carrierConfigurationDal = carrierConfigurationDal;
        }
        public IResult Add(CarrierConfiguration carrierConfiguration)
        {
            _carrierConfigurationDal.Add(carrierConfiguration);
            return new SuccessResult(Messages.CarrierConfigAdded);
        }

        public IResult Delete(int id)
        {
            var deletedDataCarrierConfig = _carrierConfigurationDal.Get(x => x.CarrierConfigurationId == id);
            _carrierConfigurationDal.Delete(deletedDataCarrierConfig);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.CarrierConfigDeleted}");
        }

        public IDataResult<List<CarrierConfiguration>> GetAll()
        {
            var listGetById = _carrierConfigurationDal.GetAll();
            return new SuccessDataResult<List<CarrierConfiguration>>(listGetById, Messages.CarrierConfigGetAll);
        }

        public IDataResult<CarrierConfiguration> GetById(int id)
        {
            var listGetByIdCarrierConfig = _carrierConfigurationDal.Get(x => x.CarrierConfigurationId == id);
            return new SuccessDataResult<CarrierConfiguration>(listGetByIdCarrierConfig, Messages.CarrierConfigGetById);
        }

        public IResult Update(CarrierConfiguration carrierConfiguration)
        {
            var updateCarrier = _carrierConfigurationDal.Get(x => x.CarrierConfigurationId == carrierConfiguration.CarrierConfigurationId);
            CarrierConfiguration updatedCarrierConfig = new CarrierConfiguration
            {
                CarrierConfigurationId= carrierConfiguration.CarrierConfigurationId,
                CarrierCost= carrierConfiguration.CarrierCost,
                CarrierId= carrierConfiguration.CarrierId,
                CarrierMaxDesi= carrierConfiguration.CarrierMaxDesi,
                CarrierMinDesi= carrierConfiguration.CarrierMinDesi,
            };
            _carrierConfigurationDal.Update(updatedCarrierConfig);
            return new SuccessResult(Messages.CarrierConfigUpdated);
        }

       
    }
}
