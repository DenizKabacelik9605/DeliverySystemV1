using DeliverySystemCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace DeliverySystemCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DeliveryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // PostgreSQL veritabanına bağlanmak için gerekli kodları yazın
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                // Veriyi çekmek için SQL sorgusunu oluşturun
                var sql = "SELECT * FROM Delivery";
                Console.WriteLine("sql",sql);
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("reader", reader);
                        // Veriyi okuyarak Product nesnelerine dönüştürün
                        var deliveries = new List<Delivery>();
                        while (reader.Read())
                        {
                            var delivery = new Delivery();

                            delivery.DeliveryId = reader.GetInt32(0);
                            delivery.CustomerName = reader.GetString(1);
                            delivery.CustomerAddress = reader.GetString(2);
                            delivery.DeliveryVehicleId = reader.GetInt32(3);
                            delivery.DeliveryStatus = reader.GetString(4);
                            delivery.Date = reader.GetDateTime(5);
                           


                           deliveries.Add(delivery);
                        }

                        return Ok(deliveries);
                    }
                }
            }
        }

    }
}
