using System;
using System.Collections.Generic;

namespace ShippingContainer
{
    public class Container
    {
        public Room[] Rooms { get; set; }

        public Container(Room[] rooms)
        {
            Rooms = rooms;
        }

        public void LoadCrates(Crate[] crates)
        {
            foreach (var crate in crates)
            {
                AddToRoom(crate);
            }
        }

        private void AddToRoom(Crate crate)
        {
            bool isCrateLoaded = false;
            int roomNo = 0;
            while (Rooms.Length - 1 >= roomNo && !isCrateLoaded)
            {
                if (Room.GetAvailableSpace(Rooms[roomNo]) - crate.Volume >= 0)
                {
                    Room.AddCrate(Rooms[roomNo], crate);
                    isCrateLoaded = true;
                }
                else
                {
                    roomNo++;
                }
            }
        }

    }
}