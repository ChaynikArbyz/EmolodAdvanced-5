using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodDelivery.OrderItems
{
    internal abstract class OrderItem
    {
        protected string name;
        protected int price;
        public string GetName() => name;
        public int GetPrice() => price;

        public abstract void Prepare();
    }
}
