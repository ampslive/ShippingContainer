# ShippingContainer

A Dotnet console application to manage a Shipping Container.

- Every Shipping Container has Rooms/Slots
- Every Room/Slot has a capacity
- Each crate can contain goods that will be added to the rooms
- While adding a crate to a room, the logic checks if there is available capacity in that room and then loads the crate
- If there is no available space, the crate will be taken to the next room to see if it can be added and so on...