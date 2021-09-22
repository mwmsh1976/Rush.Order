using System;

namespace Rush.Order.Tests.Classes
{
    public class DummyData
    {
        private static readonly Lazy<DummyData> _instance =
            new(() => new DummyData());

        public static DummyData Instance
        {
            get { return _instance.Value; }
        }

        private DummyData() { }

        public Int64 OrderId { get => 12345; }
        public Int64 CustomerId { get => 54321; }
        public string OrderNumber { get => "0000000000012345"; }
        public decimal OrderTotal { get => 123.45M; }
        public string OrderStatus { get => "Billed"; }
        public DateTimeOffset CreateDate { get => DateTime.Now.ToUniversalTime(); }

        public Models.Order OrderModel
        {
            get => new Models.Order
            {
                Id = this.OrderId,
                CreateDate = this.CreateDate,
                CustomerId = this.CustomerId,
                OrderNumber = this.OrderNumber,
                Total = this.OrderTotal,
                Status = this.OrderStatus
            };
        }

        public Models.Order OrderNullModel
        {
            get => null;
        }

        public Domain.Order DomainOrder
        {
            get => new Domain.Order
            {
                Id = this.OrderId,
                CreateDate = this.CreateDate,
                CustomerId = this.CustomerId,
                OrderNumber = this.OrderNumber,
                Total = this.OrderTotal,
                Status = this.OrderStatus
            };
        }

        public Models.OrderByNumberRequest ModelOrderByNumberRequest
        {
            get => new Models.OrderByNumberRequest
            {
                OrderNumber = this.OrderNumber
            };
        }
    }
}