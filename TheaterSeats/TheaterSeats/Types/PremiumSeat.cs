using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterSeats.Types
{
    internal class PremiumSeat : AbstractSeat
    {
        protected override int cost { get; set; } = 150;
        protected override string description { get; set; } = "можливість викликати офіціанта + можливість замовлення їжі + регулювання крісла";
        public override int getCost() { return cost; }
        public override string getDescription() { return description; }
        public void CallWaiter()
        {
            //в завданні не було вказано, що методи типів мають мати функціонал
        }
        public void OrderFood()
        {

        }
        public void AdjustSeat()
        {

        }
    }
}
