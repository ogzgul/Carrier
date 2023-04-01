using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarrierConfigurationService
    {
        IResult Add(CarrierConfiguration carrierConfiguration);
        IResult Update(CarrierConfiguration carrierConfiguration);
        IResult Delete(int id);
        IDataResult<List<CarrierConfiguration>> GetAll();
        IDataResult<CarrierConfiguration> GetById(int id);
    }
}
