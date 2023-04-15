namespace DeliveryEntityframeworkCrud
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public int DeliveryVehicleId { get; set; }

        public string DeliveryStatus { get; set; }

        public DateTime Date { get; set; }

    }
}
