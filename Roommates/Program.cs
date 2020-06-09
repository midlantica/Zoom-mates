using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);
            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();
            List<Room> allRooms = roomRepo.GetAll();
            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }
            
            // >> Roommates
            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();
            List<Roommate> allRoommates = roommateRepo.GetAll();
            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.FirstName} {roommate.LastName} {roommate.RentPortion}");
            }

            // Getting Room with Id 1
            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");
            Room singleRoom = roomRepo.GetById(1);
            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");


            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 1");
            Roommate singleRoommate = roommateRepo.GetById(1);
            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.FirstName} {singleRoommate.LastName} {singleRoommate.RentPortion}");


            // INSERT ROOM
            Room bathroom = new Room { Name = "Bathroom", MaxOccupancy = 1 };
            roomRepo.Insert(bathroom);
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            // INSERT ROOMATE
            Roommate jimmy = new Roommate
            {
                FirstName = "Jimmy",
                LastName = "Jackson",
                RentPortion = 100,
                MoveInDate = DateTime.Now
            };
            roommateRepo.Insert(jimmy);
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {jimmy.Id}");



            // UPDATE
            new Room
            {
                Name = "Bathroom2",
                MaxOccupancy = 2
            };
            roomRepo.Update(bathroom);
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id} 2");


            // DELETE
            roomRepo.Delete(10);
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Deleted Room with id {bathroom.Id} 3");

        }
    }
}