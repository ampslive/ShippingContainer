using System;
using System.Collections.Generic;
using Xunit;

namespace ShippingContainer.Tests
{
    public class RoomsTest
    {
        Room room;
        List<Crate> crates;

        public RoomsTest()
        {
            room = new Room(10);
            crates = new List<Crate>();
        }
        [Fact]
        public void CreateRoomWithNoCrates()
        {
            Assert.Equal(room.Size,10);
        }

        [Fact]
        public void CreateRoomWithACrate()
        {
            crates.Add(new Crate(2));
            
            room.AddCrates(crates.ToArray());

            Assert.NotEmpty(room.Crates);
        }

        [Fact]
        public void DontAddCrateThatIsBiggerThanRoom_SingeCrate()
        {
            crates.Add(new Crate(11));

            room.AddCrates(crates.ToArray());

            Assert.Equal(room.Crates.Length,0);
        }

        [Fact]
        public void DontAddCrateThatIsBiggerThanRoom_MultipleCrates()
        {
            crates.Add(new Crate(5));
            crates.Add(new Crate(6));

            room.AddCrates(crates.ToArray());

            Assert.Equal(room.Crates.Length,1);
        }
    }
}
