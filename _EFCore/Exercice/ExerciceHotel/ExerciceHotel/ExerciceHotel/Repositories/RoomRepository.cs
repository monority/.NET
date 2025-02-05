using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExerciceHotel.Repositories
{
	internal class RoomRepository : IRepository<Room, int>
	{
		private readonly ApplicationDbContext _db;

		public RoomRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public Room? Add(Room room)
		{
			EntityEntry<Room> roomEntity = _db.Add(room);
			_db.SaveChanges();
			return roomEntity.Entity;
		}
		public Room? GetById(int id)
		{
			return _db.Rooms.FirstOrDefault(r => r.RoomNumber == id);
		}
		public Room? GetStatus(int id)
		{
			return _db.Rooms.FirstOrDefault(r => (int)r.Status == id);
		}
		public Room? Update(int id, Room room)
		{
			var RoomFromDb = GetById(id);
			if (RoomFromDb == null)
				return null;
			if (RoomFromDb.Status != room.Status)
				RoomFromDb.Status = room.Status;
			if (RoomFromDb.BedNumber != room.BedNumber)
				RoomFromDb.BedNumber = room.BedNumber;
			if (RoomFromDb.Price != room.Price)
				RoomFromDb.Price = room.Price;
			_db.SaveChanges();
			return RoomFromDb;
		}

		public bool Delete(int id)
		{
			var room = GetById(id);
			if (room == null) return false;
			_db.Rooms.Remove(room);
			return _db.SaveChanges() == 1;
		}
		public IEnumerable<Room> GetAll() {
			return _db.Rooms;
		}
		public IEnumerable<Room> GetAll(Func<Room, bool> predicate)
		{
			return _db.Rooms.Where(predicate);
		}
		public Room? Get(Func<Room, bool> predicate)
		{
			return _db.Rooms
			.FirstOrDefault(predicate);
		}
		public void DeleteAllEntries()
		{
			_db.Rooms.RemoveRange(_db.Rooms);
			_db.SaveChanges();
		}


	}
}
