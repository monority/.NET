using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo01.Data;
using ExerciceHotel.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExerciceHotel.Repositories
{
	internal class ClientRepository : IRepository<Client, int>
	{
		private readonly ApplicationDbContext _db;

		public ClientRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public Client? Add(Client client)
		{
			EntityEntry<Client> roomEntity = _db.Add(client);
			_db.SaveChanges();
			return roomEntity.Entity;
		}
		public Client? GetById(int id)
		{
			return _db.Clients.FirstOrDefault(r => r.Id == id);
		}

		public Client? Update(int id, Client client)
		{
			var ClientFromDb = GetById(id);
			if (ClientFromDb == null)
				return null;

			if (ClientFromDb.FirstName != client.FirstName)
				ClientFromDb.FirstName = client.FirstName;
			if (ClientFromDb.LastName != client.LastName)
				ClientFromDb.LastName = client.LastName;
			if (ClientFromDb.PhoneNumber != client.PhoneNumber)
				ClientFromDb.PhoneNumber = client.PhoneNumber;
			_db.SaveChanges();
			return ClientFromDb;
		}

		public bool Delete(int id)
		{
			var room = GetById(id);
			if (room == null) return false;
			_db.Clients.Remove(room);
			return _db.SaveChanges() == 1;
		}
		public IEnumerable<Client> GetAll()
		{
			return _db.Clients;
		}
		public Client? Get(Func<Client, bool> predicate)
		{
			return _db.Clients.FirstOrDefault(predicate);
		}

		public IEnumerable<Client> GetAll(Func<Client, bool> predicate)
		{
			return _db.Clients.Where(predicate);
		}

	}
}
