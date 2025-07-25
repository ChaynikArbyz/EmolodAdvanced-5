using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheaterSeats.Types;

namespace TheaterSeats
{
    internal class Seat
    {
        private int number;
        private static int usedSeats = 1;
        private bool isAvailable;
        public AbstractSeat type = new StandartSeat();

        public Seat()
        {
            this.number = usedSeats;
            usedSeats++;
        }

        public int getNumber() { return number; }
        public bool getIsAvailable() { return isAvailable; }
        public void setIsAvailable(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }




    }
}
