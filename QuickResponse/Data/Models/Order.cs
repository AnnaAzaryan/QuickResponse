using QuickResponse.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public int PostTo { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public OrderStatus Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
