// See https://aka.ms/new-console-template for more information
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Data.Entities;
using MiniApp.Dtos.RestaurantDTOs;
using MiniApp.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

Console.WriteLine("Hello, World!");
RestaurantDbContext _context = new ();
while (true)
{
    Console.Clear();
    Console.WriteLine("--- Main Menu ---");
    Console.WriteLine("1. Add Restaurant");
    Console.WriteLine("2. List Restaurants");
    Console.WriteLine("3. Delete Restaurant");
    Console.WriteLine("4. Add Dining Table");
    Console.WriteLine("5.List Dining Tables");
    Console.WriteLine("6.Delete Dining Table");
    Console.WriteLine("7.Add Reservation");
    Console.WriteLine("8.List Reservations");
    Console.WriteLine("9.Delete Reservation");
    Console.WriteLine("10.Update Reservation");
    Console.WriteLine("0. Exit"); 
    Console.Write("Choose an option: ");

    var input = Console.ReadLine();
    switch (input)
    {
        case "1": AddRestaurant(_context); 
            break;
        case "2": ListRestaurants(_context); 
            break;
        case "3": DeleteRestaurant(_context);
            break;
        case "4": AddDiningTable(_context);
            break;
        case "5": ListDiningTables(_context);
            break;
        case "6": DeleteDiningTable(_context);
            break;
        case "7": AddReservation(_context);
            break;
        case "8": ListReservations(_context);
            break;
        case "9": DeleteReservation(_context);
            break;
        case "10": UpdateReservation(_context);
            break;
        case "0": return;
        default: Console.WriteLine("Invalid option!"); break;
    }

    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}

void AddRestaurant(RestaurantDbContext _context)
{
    Console.Write("Name: "); var name = Console.ReadLine()!;
    Console.Write("Phone: "); var phone = Console.ReadLine()!;
    Console.Write("Address: "); var address = Console.ReadLine()!;
    Console.Write("City: "); var city = Console.ReadLine()!;
    Console.Write("Cuisine: "); var cuisine = Console.ReadLine()!;
    Console.Write("Menu Id: "); int.TryParse(Console.ReadLine(), out int menuId);

    var restaurant = new Restaurant
    {
        Name = name,
        Phone = phone,
        MenuId = menuId,
        RestaurantDetail = new RestaurantDetail
        {
            Address = address,
            City = city,
            Cuisine = cuisine
        }
    };

    _context.Restaurant.Add(restaurant);
    _context.SaveChanges();
    Console.WriteLine("Restaurant added successfully!");
}

void ListRestaurants(RestaurantDbContext _context)
{
    var restaurants = _context.Restaurant.Include(r => r.RestaurantDetail).ToList();
    if (!restaurants.Any()) 
    { 
        Console.WriteLine("No restaurants found.");
        return;
    }
    foreach (var r in restaurants)
        Console.WriteLine($"Id: {r.Id}, Name: {r.Name}, Phone: {r.Phone}, Address: {r.RestaurantDetail.Address}, City: {r.RestaurantDetail.City}, Cuisine: {r.RestaurantDetail.Cuisine}, MenuId: {r.MenuId}");
}

void DeleteRestaurant(RestaurantDbContext _context)
{
    Console.Write("Restaurant Id to delete: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var restaurant = _context.Restaurant.Include(r => r.RestaurantDetail).FirstOrDefault(r => r.Id == id);
        if (restaurant != null)
        {
            _context.RestaurantDetail.Remove(restaurant.RestaurantDetail);
            _context.Restaurant.Remove(restaurant);
            _context.SaveChanges();
            Console.WriteLine("Deleted!");
        }
        else Console.WriteLine("Not found.");
    }
}


void AddDiningTable(RestaurantDbContext _context)
{
    Console.Write("DiningTableNumber: "); int.TryParse(Console.ReadLine(), out int tableNumber);
    Console.Write("Capacity: "); int.TryParse(Console.ReadLine(), out int capacity);
    Console.Write("IsActive (true/false): "); bool.TryParse(Console.ReadLine(), out bool isActive);
    Console.Write("Restaurant Id: "); int.TryParse(Console.ReadLine(), out int restaurantId);
    var diningTable = new DiningTable
    {
       DiningTableNumber = tableNumber,
       Capacity = capacity,
       IsActive = isActive,
       RestaurantId = restaurantId
    };
    _context.DiningTable.Add(diningTable);
    _context.SaveChanges();
    Console.WriteLine("Dining Table added successfully!");
}

void ListDiningTables(RestaurantDbContext _context)
{
    var diningTables = _context.DiningTable.ToList();
    if (!diningTables.Any())
    {
        Console.WriteLine("No dining tables found.");
        return;
    }
    foreach (var dt in diningTables)
    {

        Console.WriteLine($"Id: {dt.Id}, DiningTableNumber: {dt.DiningTableNumber}, Capacity: {dt.Capacity}, IsActive: {dt.IsActive}, RestaurantId: {dt.RestaurantId}");
    }
}
void DeleteDiningTable(RestaurantDbContext _context)
{
    Console.Write("Dining Table Id to delete: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var diningTable = _context.DiningTable.FirstOrDefault(dt => dt.Id == id);
        if (diningTable != null)
        {
            _context.DiningTable.Remove(diningTable);
            _context.SaveChanges();
            Console.WriteLine("Deleted!");
        }
        else Console.WriteLine("Not found.");
    }
}

void AddReservation (RestaurantDbContext context) 
{
    Console.Write("Customer Name: ");
    var customerName = Console.ReadLine()!;
    Console.Write("CustomerPhone: ");
    var customerPhone=Console.ReadLine();
    Console.Write("GuestCount: ");
    int.TryParse(Console.ReadLine(), out int guestCount);
    Console.Write("Reservation Date (yyyy-MM-dd HH:mm): ");
    string inputDate = Console.ReadLine()!;
    if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime reservationDateLocal))
    {
        Console.WriteLine("Invalid date format. Use yyyy-MM-dd HH:mm");
        return;
    }
    DateTime reservationDateUtc = DateTime.SpecifyKind(reservationDateLocal, DateTimeKind.Utc);
    Console.Write("Dining Table Id: ");
    int.TryParse(Console.ReadLine(), out int diningTableId);
    Console.WriteLine("CreatedAt:");
    DateTime createdAt = DateTime.UtcNow;

    var reservation = new Reservation
    {
        CustomerName = customerName,
        CustomerPhone = customerPhone,
        GuestCount = guestCount,
        ReservationDate = reservationDateUtc,
        CreatedAt = createdAt,
        DiningTableId = diningTableId
    };
    context.Reservation.Add(reservation);
    context.SaveChanges();
    Console.WriteLine("Reservation added successfully!");
};

void ListReservations(RestaurantDbContext context)
{
    var reservations = context.Reservation.ToList();
    if (!reservations.Any())
    {
        Console.WriteLine("No reservations found.");
        return;
    }
    foreach (var r in reservations)
    {
        Console.WriteLine($"Id: {r.Id}, CustomerName: {r.CustomerName}, CustomerPhone: {r.CustomerPhone}, GuestCount: {r.GuestCount}, ReservationDate: {r.ReservationDate}, CreatedAt: {r.CreatedAt}, DiningTableId: {r.DiningTableId}");
    }
}

void DeleteReservation(RestaurantDbContext context)
{
    Console.Write("Reservation Id to delete: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var reservation = context.Reservation.FirstOrDefault(r => r.Id == id);
        if (reservation != null)
        {
            context.Reservation.Remove(reservation);
            context.SaveChanges();
            Console.WriteLine("Deleted!");
        }
        else Console.WriteLine("Not found.");
    }
}

void UpdateReservation(RestaurantDbContext context)
{
    Console.Write("Reservation Id to update: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var reservation = context.Reservation.FirstOrDefault(r => r.Id == id);
        if (reservation != null)
        {
            Console.Write("Customer Name: ");
            reservation.CustomerName = Console.ReadLine()!;
            Console.Write("Customer Phone: ");
            reservation.CustomerPhone = Console.ReadLine()!;
            Console.Write("Guest Count: ");
            int.TryParse(Console.ReadLine(), out int guestCount);
            reservation.GuestCount = guestCount;
            Console.Write("Reservation Date (yyyy-MM-dd HH:mm): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime reservationDate);
            reservation.ReservationDate = reservationDate;
            Console.Write("Dining Table Id: ");
            int.TryParse(Console.ReadLine(), out int diningTableId);
            reservation.DiningTableId = diningTableId;
            context.SaveChanges();
            Console.WriteLine("Updated!");
        }
        else Console.WriteLine("Not found.");
    }
}