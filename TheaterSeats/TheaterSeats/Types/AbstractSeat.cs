using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSeats.Types
{
    internal abstract class AbstractSeat
    {
        protected abstract int cost { get; set; }
        protected abstract string description { get; set; }
        public abstract int getCost();
        public abstract string getDescription();
    }
}
