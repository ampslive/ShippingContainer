using System;
using System.Collections.Generic;
using Xunit;

namespace ShippingContainer.Tests
{
    public class ContainerTest
    {
        List<Room> rooms = new List<Room>();
        List<Crate> crates = new List<Crate>();
        public ContainerTest()
        {
            rooms.Add(new Room(10));
            rooms.Add(new Room(20));
        }

        [Fact]
        public void ContainerWithRooms()
        {
            var container1 = new Container(rooms.ToArray());

            Assert.Equal(container1.Rooms.Length, 2);
        }

        [Fact]
        public void ContainerWithRoomsAndCrates_CorrectCapacity()
        {
            crates.Add(new Crate(5));

            var container1 = new Container(rooms.ToArray());
            container1.LoadCrates(crates.ToArray());

            Assert.Equal(container1.Rooms[0].Crates.Length, 1);
            Assert.Equal(container1.Rooms[1].Crates.Length, 0);
        }

        [Fact]
        public void ContainerWithRoomsAndCrates_UnderSizedCrate()
        {
            crates.Add(new Crate(5));
            crates.Add(new Crate(10));

            var container1 = new Container(rooms.ToArray());
            container1.LoadCrates(crates.ToArray());

            Assert.Equal(container1.Rooms[0].Crates.Length, 1);
            Assert.Equal(container1.Rooms[1].Crates.Length, 1);
        }

        [Fact]
        public void ContainerWithRoomsAndCrates_OverSizedCrates()
        {
            crates.Add(new Crate(5));
            crates.Add(new Crate(10));
            crates.Add(new Crate(30));
            var container1 = new Container(rooms.ToArray());
            container1.LoadCrates(crates.ToArray());

            Assert.Equal(container1.Rooms[0].Crates.Length, 1);
            Assert.Equal(container1.Rooms[1].Crates.Length, 1);
        }
    }
}