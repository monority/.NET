// See https://aka.ms/new-console-template for more information
using System;
using Demo01.Data;
using ExerciceHotel;
using ExerciceHotel.Repositories;
using ExerciceHotel.UI;


using var context = new ApplicationDbContext();
var ui = new MainUI(new ClientRepository(context), new RoomRepository(context), new ReservationRepository(context));
ui.Start();