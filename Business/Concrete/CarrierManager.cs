using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarrierManager : ICarrierService
    {
        ICarrierDal _carrierDal;
        ICarrierConfigurationDal _carrierConfigurationDal;

        public CarrierManager(ICarrierDal carrierDal, ICarrierConfigurationDal carrierConfigurationDal) : this(carrierDal)
        {
            _carrierConfigurationDal = carrierConfigurationDal;
        }

        public CarrierManager(ICarrierDal carrierDal)
        {
            _carrierDal = carrierDal;
        }

        public IResult Add(Carrier carrier)
        {
            _carrierDal.Add(carrier);
            return new SuccessResult(Messages.CarrierAdded);
        }

        public IDataResult<List<Carrier>> GetAll()
        {
            var listedCarrier = _carrierDal.GetAll();
            return new SuccessDataResult<List<Carrier>>(listedCarrier,Messages.GetAll);

        }

        public IDataResult<Carrier> GetById(int id)
        {
            var listGetById = _carrierDal.Get(x => x.CarrierId == id);
            return new SuccessDataResult<Carrier>(listGetById,Messages.GetById);
        }

        public IResult Update(Carrier carrier)
        {
            var updateCarrier = _carrierDal.Get(x => x.CarrierId == carrier.CarrierId);
            Carrier updatedCarrier = new Carrier{
                CarrierId=carrier.CarrierId,
                CarrierName = carrier.CarrierName,
                CarrierConfigurationId = carrier.CarrierConfigurationId,
                CarrierIsActive = carrier.CarrierIsActive,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost
            };
            _carrierDal.Update(updatedCarrier);
            return new SuccessResult(Messages.CarrierUpdated);
        }

        public IResult Delete(int id)
        {
            var deletedData = _carrierDal.Get(x => x.CarrierId == id);
            _carrierDal.Delete(deletedData);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.CarrierDeleted}");
        }

        public IDataResult<Carrier> DeleteByName(string carrierName)
        {
            var deleteByName=_carrierDal.Get(x=>x.CarrierName == carrierName);
            _carrierDal.Delete(deleteByName);
            return new SuccessDataResult<Carrier>(deleteByName,$"{carrierName} {Messages.CarrierDeleted}");
        }
    }
}
