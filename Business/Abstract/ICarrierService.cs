using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarrierService
    {
        IResult Add(Carrier carrier);
        IResult Update(Carrier carrier);
        IResult Delete(int id);
        IDataResult<Carrier> DeleteByName(string carrierName);
        IDataResult<List<Carrier>> GetAll();
        IDataResult<Carrier> GetById(int id);
        
        

        
    }
}
