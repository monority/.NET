using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceHotel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
namespace ExerciceHotel.Repositories
{
	internal class ReservationRepository : IRepository<Reservation, int>
	{
		private readonly ApplicationDbContext _db;

		public ReservationRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public Reservation? Add(Reservation reservation)
		{
			EntityEntry<Reservation> reservationRoom = _db.Add(reservation);
			_db.SaveChanges();
			return reservationRoom.Entity;
		}
		public Reservation? GetById(int id)
		{
			return _db.Reservations.FirstOrDefault(r => r.Id == id);
		}
		public Reservation? GetStatus(int id)
		{
			return _db.Reservations.FirstOrDefault(r => (int)r.Status == id);
		}
		public Reservation? Update(int id, Reservation reservation)
		{
			var ReservationDb = GetById(id);
			if (ReservationDb == null)
				return null;

			if (ReservationDb.Room != reservation.Room)
				ReservationDb.Room = reservation.Room;
			if (ReservationDb.Client != reservation.Client)
				ReservationDb.Client = reservation.Client;
			if (ReservationDb.Status != reservation.Status)
				ReservationDb.Status = reservation.Status;
			_db.SaveChanges();
			return ReservationDb;
		}

		public bool Delete(int id)
		{
			var reservation = GetById(id);
			if (reservation == null) return false;
			_db.Reservations.Remove(reservation);
			return _db.SaveChanges() == 1;
		}
		public IEnumerable<Reservation> GetAll()
		{
			return _db.Reservations;
		}
		public IEnumerable<Reservation> GetAll(Func<Reservation, bool> predicate)
		{
			return _db.Reservations.Where(predicate);
		}

		public Reservation? Get(Func<Reservation, bool> predicate)
		{
			return _db.Reservations
				   .Include(r => r.Client)
				   .Include(r => r.Room)
				   .FirstOrDefault(predicate);
		}
		public void DeleteAllEntries()
		{
			_db.Reservations.RemoveRange(_db.Reservations);
			_db.SaveChanges();
		}
	}
}
