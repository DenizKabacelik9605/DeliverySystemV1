using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryEntityframeworkCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {


        private static List<Delivery2> deliveries = new List<Delivery2>
            {
                new Delivery2 { DeliveryId = 1, CustomerName = "Test Data", CustomerAddress = "Test Location", DeliveryVehicleId = 54, DeliveryStatus = "Delivered", Date = new DateTime(2023, 4, 16) },
                new Delivery2 { DeliveryId = 5, CustomerName = "Test", CustomerAddress = "Location", DeliveryVehicleId = 58, DeliveryStatus = "Delivered", Date = new DateTime(2023, 6, 16) }
            };


        [HttpGet]
        public async Task<ActionResult<List<Delivery2>>> Get()
        {

            return Ok(deliveries);
        }

        [HttpGet("{DeliveryId}")]
        public async Task<ActionResult<List<Delivery2>>> Get(int DeliveryId)
        {
            var delivery = deliveries.Find(h => h.DeliveryId == DeliveryId);
            if (delivery == null)
            {
                return BadRequest("Delivery not found");

            }
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<ActionResult<List<Delivery2>>> AddDelivery(Delivery2 delivery)
        {

            deliveries.Add(delivery);
            return Ok(deliveries);
        }
        [HttpPut]
        public async Task<ActionResult<List<Delivery2>>> UpdateDelivery(Delivery2 delivery)
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
        [HttpDelete()]
        public async Task<ActionResult<List<Delivery2>>> DeleteDelivery(Delivery2 delivery)
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
