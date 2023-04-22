using DeliveryEntityframeworkCrud.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliveryEntityframeworkCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Delivery2Controller : ControllerBase
    {
        private readonly DataContext _context;

        public Delivery2Controller(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Delivery2>>> Get()
        {
            return Ok(await _context.deliveries.ToListAsync());


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery2>> Get(int id)
        {
            var delivery = await _context.deliveries.FindAsync(id);
            if (delivery == null)
            {

                return BadRequest("Delivery not found");
            }
            return Ok(delivery);
        }


        [HttpPost]

        public async Task<ActionResult<List<Delivery2>>> AddDelivery(Delivery2 delivery)
        {

            _context.deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return Ok(await _context.deliveries.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Delivery2>>> UpdateDelivery(Delivery2 request){

            var dbDelivery = await _context.deliveries.FindAsync(request.DeliveryId);
            if (dbDelivery == null)
            {
                return BadRequest("Delivery not found");
            }

            dbDelivery.CustomerName = request.CustomerName;
            dbDelivery.CustomerAddress = request.CustomerAddress;
            dbDelivery.DeliveryStatus = request.DeliveryStatus;
            dbDelivery.DeliveryVehicleId = request.DeliveryVehicleId;
            dbDelivery.Date = request.Date;

            await _context.SaveChangesAsync();
            return Ok(await _context.deliveries.ToListAsync());

        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Delivery2>>> Delete(int id)
        {
            var delivery = await _context.deliveries.FindAsync(id);
            if (delivery == null)
                return BadRequest("Delivery not found");
            _context.deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return Ok(await _context.deliveries.ToListAsync());


        }
    }
}