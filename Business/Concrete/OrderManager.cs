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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        ICarrierDal _carrierDal;
        ICarrierConfigurationDal _carrierConfigurationDal;

        public OrderManager(IOrderDal orderDal,ICarrierDal carrierDal, ICarrierConfigurationDal carrierConfigurationDal) : this(orderDal)
        {
            _orderDal = orderDal;
            _carrierDal = carrierDal;
            _carrierConfigurationDal = carrierConfigurationDal;
        }
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
           
            var carrierConOrder = _carrierConfigurationDal.GetAll().Where(x => x.CarrierMinDesi <= order.OrderDesi && x.CarrierMaxDesi >= order.OrderDesi).OrderByDescending(x=>x.CarrierMinDesi).FirstOrDefault();
            if(carrierConOrder != null) { 
            order.CarrierId = carrierConOrder.CarrierId;
            _orderDal.Add(order);
            }
            else
            {
                var orderCost = _carrierConfigurationDal.GetAll().OrderByDescending(x=>x.CarrierMaxDesi).ThenBy(x=>x.CarrierCost).First();
                var carrier = _carrierDal.Get(x=>x.CarrierId== orderCost.CarrierId);
                if(carrier != null)
                {
                    var calculateCarrierPlus = orderCost.CarrierCost + (carrier.CarrierPlusDesiCost * (order.OrderDesi - orderCost.CarrierMaxDesi));
                    order.OrderCarrierCost = calculateCarrierPlus;
                    order.CarrierId = carrier.CarrierId;
                    _orderDal.Add(order);
                }

            }
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(int id)
        {
            var deletedOrder = _orderDal.Get(x => x.OrderId == id);
            _orderDal.Delete(deletedOrder);
            return new SuccessResult($"Deleted Data : {id} number's {Messages.OrderDeleted}");
        }

        public IDataResult<List<Order>> GetAll()
        {
            var listedOrder = _orderDal.GetAll();
            return new SuccessDataResult<List<Order>>(listedOrder, Messages.OrderGetAll);
        }

        public IResult GetById(int id)
        {
            var listOrderGetById = _orderDal.Get(x => x.OrderId == id);
            return new SuccessDataResult<Order>(listOrderGetById, Messages.OrderGetById);
        }

        public IResult Update(Order order)
        {
            var updateOrder = _orderDal.Get(x => x.OrderId == order.OrderId);
            Order updatedOrder = new Order
            {
                OrderId = order.OrderId,
                OrderDate= order.OrderDate,
                OrderDesi=order.OrderDesi,
                OrderCarrierCost=order.OrderCarrierCost,
                
            };
            _orderDal.Update(updatedOrder);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
