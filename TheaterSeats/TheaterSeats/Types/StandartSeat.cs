using System;

namespace TheaterSeats.Types
{
    internal class StandartSeat : AbstractSeat
    {
        protected override int cost { get; set; } = 90;
        protected override string description { get; set; } = "звичайне місце";

        public override int getCost() { return cost; }
        public override string getDescription() { return description; }
    }
}
