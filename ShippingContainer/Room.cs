using System;
using System.Collections.Generic;
using System.Linq;

namespace ShippingContainer
{
    public class Room
    {
        public int Size { get; set; }
        public Crate[] Crates { get; set; }

        public Room(int size)
        {
            Size = size;
            Crates = new Crate[0];
        }

        public void AddCrates(Crate[] crates)
        {
            foreach (var crate in crates)
            {
                if (Room.GetAvailableSpace(this) - crate.Volume >= 0)
                {
                    AddCrate(this, crate);
                }
            }
        }

        public static int GetAvailableSpace(Room room)
        {
            int totalCrateVolume = 0;
            foreach (var crate in room.Crates)
            {
                totalCrateVolume += crate.Volume;
            }
            return room.Size - totalCrateVolume;
        }

        public static void AddCrate(Room room, Crate newCrate)
        {
            List<Crate> cratesLst = new List<Crate>();
            foreach (var c in room.Crates)
            {
                cratesLst.Add(c);
            }

            cratesLst.Add(newCrate);

            room.Crates = cratesLst.ToArray();
        }
    }
}