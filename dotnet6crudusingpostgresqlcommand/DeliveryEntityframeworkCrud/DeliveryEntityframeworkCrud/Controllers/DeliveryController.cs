using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryEntityframeworkCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {


        private static List<Delivery> deliveries = new List<Delivery>
            {
                new Delivery { DeliveryId = 1, CustomerName = "Test Data", CustomerAddress = "Test Location", DeliveryVehicleId = 54, DeliveryStatus = "Delivered", Date = new DateTime(2023, 4, 16) },
                new Delivery { DeliveryId = 5, CustomerName = "Test", CustomerAddress = "Location", DeliveryVehicleId = 58, DeliveryStatus = "Delivered", Date = new DateTime(2023, 6, 16) }
            };


        [HttpGet]
        public async Task<ActionResult<List<Delivery>>> Get()
        {

            return Ok(deliveries);
        }

        [HttpGet("{DeliveryId}")]
        public async Task<ActionResult<List<Delivery>>> Get(int DeliveryId)
        {
            var delivery = deliveries.Find(h => h.DeliveryId == DeliveryId);
            if (delivery == null)
            {
                return BadRequest("Delivery not found");

            }
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<ActionResult<List<Delivery>>> AddDelivery(Delivery delivery)
        {

            deliveries.Add(delivery);
            return Ok(deliveries);
        }
        [HttpPut]
        public async Task<ActionResult<List<Delivery>>> UpdateDelivery(Delivery delivery)
        {
            var deliveryupdate = deliveries.Find(h => h.DeliveryId == delivery.DeliveryId);
            if (deliveryupdate == null)
            {
                return BadRequest("Delivery not found");

            }
            else
            {
                deliveryupdate.CustomerName = delivery.CustomerName;
                deliveryupdate.CustomerAddress = delivery.CustomerAddress;
                deliveryupdate.DeliveryVehicleId = delivery.DeliveryVehicleId;
                deliveryupdate.DeliveryStatus = delivery.DeliveryStatus;
                deliveryupdate.Date = delivery.Date;
                return Ok(deliveryupdate);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Delivery>>> DeleteDelivery(Delivery delivery)
        {
            var deliverydelete = deliveries.Find(h => h.DeliveryId == delivery.DeliveryId);
            if (deliverydelete == null)
            {
                return BadRequest("Delivery not found");

            }
            else
            {
                deliveries.Remove(deliverydelete);
                return Ok(deliverydelete);
            }
        }
    }
}
