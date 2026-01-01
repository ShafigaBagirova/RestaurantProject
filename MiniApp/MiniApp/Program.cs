// See https://aka.ms/new-console-template for more information
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MiniApp.Data.Contexts;
using MiniApp.Data.Entities;
using MiniApp.Dtos.RestaurantDTOs;
using System.ComponentModel;

Console.WriteLine("Hello, World!");

RestaurantDbContext _context = new ();

var createdcategoryrequest = new 
{
    Name="Fast Food",
    Description= "Fast food items"
};

Category category = new Category
{
    Name = createdcategoryrequest.Name,
    Description=createdcategoryrequest.Description

};

var createdcategoryrequest2 = new
{
    Name= "Soups",
    Description= "Various kinds of soups"
};

Category category2 = new Category
{
    Name = createdcategoryrequest2.Name,
    Description = createdcategoryrequest2.Description
};

var createdcategoryrequest3 = new
{
    Name = "Desserts",
    Description = "Sweet desserts"
};
Category category3 = new Category
{
    Name = createdcategoryrequest3.Name,
    Description = createdcategoryrequest3.Description
};

//_context.Category.AddRange(category2,category3);
//_context.SaveChanges();

var createtproductrequest = new
{
    Name = "Burger",
    Description = "Delicious beef burger",
    Price = 5.99m,
    CategoryId=3
};

Product product = new Product
{
    Name = createtproductrequest.Name,
    Description = createtproductrequest.Description,
    Price = createtproductrequest.Price,
    CategoryId= createtproductrequest.CategoryId
};

var createdproductrequest2= new
{
    Name = "Chicken Soup",
    Description = "Warm chicken soup",
    Price = 3.99m,
    CategoryId=4
};

Product product2 = new Product
{
    Name = createdproductrequest2.Name,
    Description = createdproductrequest2.Description,
    Price = createdproductrequest2.Price,
    CategoryId= createdproductrequest2.CategoryId
};

var createdproductrequest3 = new
{
    Name = "Ice Cream",
    Description = "Vanilla ice cream",
    Price = 2.99m,
    CategoryId=5
};

Product product3 = new Product
{
    Name = createdproductrequest3.Name,
    Description = createdproductrequest3.Description,
    Price = createdproductrequest3.Price,
    CategoryId= createdproductrequest3.CategoryId
};

//_context.Product.AddRange(product,product2,product3);
//_context.SaveChanges();

var c1=_context.Category.Find(3);
var c2=_context.Category.Find(4);
var c3=_context.Category.Find(5);
var p1=_context.Product.Find(3);
var p2=_context.Product.Find(4);
var p3=_context.Product.Find(5);

Menu menu = new Menu
{
    Categories =  new List<Category> { c1, c2, c3 },
    Products = new List<Product> { p1, p2, p3 }

};
//_context.Menu.Add(menu);
//_context.SaveChanges();
//var m1=_context.Menu.Find(1);
//Console.WriteLine("found");
var createdrestaurantrequest = new
{
    Name = "Food Haven",
    Address = "123 Main St",
    Phone = "555-1234",
    MenuId=1,
    City= "Metropolis",
    Cuisine= "International"
};

Restaurant restaurant = new Restaurant
{
    Name = createdrestaurantrequest.Name,
    Phone= createdrestaurantrequest.Phone,
    MenuId= createdrestaurantrequest.MenuId,    
    RestaurantDetail= new RestaurantDetail
    {
        City= createdrestaurantrequest.City,
         Cuisine= createdrestaurantrequest.Cuisine,
        Address = createdrestaurantrequest.Address,
    }
};
//_context.Restaurant.Add(restaurant);
//_context.SaveChanges();



//_context.Menu.Attach(existingMenu);
//var restaurant1 = new Restaurant
//{
//    Name = "Central Baku",
//    Phone = "555-1256",
//    Menu = existingMenu,
//    MenuId = existingMenu.Id,
//    RestaurantDetail = new RestaurantDetail
//    {
//        Address = "126 Main St",
//        City = "Baku",
//        Cuisine = "International"
//    }
//};

//_context.Restaurant.Add(restaurant1);
//_context.SaveChanges();
//var r1=_context.Restaurant.Find(8);
//var createdstaffrequest = new
//{
//    FullName = "John Doe",
//    Position = "Chef",
//    Email="jd@gmail.com",
//    Age=26,
//    Phone="555-6789",
//    Restaurant =new List<Restaurant> { r1 }
//};

//Staff staff = new Staff
//{
//    FullName = createdstaffrequest.FullName,
//    Position = createdstaffrequest.Position,
//    Restaurants = createdstaffrequest.Restaurant,
//    Email= createdstaffrequest.Email,
//    Age= createdstaffrequest.Age,
//    Phone= createdstaffrequest.Phone
//};
//_context.Staffs.Add(staff);
//_context.SaveChanges();
var r1=_context.Restaurant.Find(8);
var createddiningtablerequest = new
{
    TableNumber = 10,
    Capacity = 4,
    IsAvailable = true,
    RestaurantId=r1.Id
};

DiningTable diningTable = new DiningTable
{
    DiningTableNumber = createddiningtablerequest.TableNumber,
    Capacity = createddiningtablerequest.Capacity,
    IsActive = createddiningtablerequest.IsAvailable,
    RestaurantId= createddiningtablerequest.RestaurantId
};
//_context.DiningTable.Add(diningTable);
//_context.SaveChanges();
var dt1=_context.DiningTable.Find(1);
var createdreservationrequest = new
{
    CustomerName = "Alice Smith",
    ReservationTime = DateTime.UtcNow.AddHours(2),
    NumberOfGuests = 4,
    DiningTableId=dt1.Id,
    CreatedAt=DateTime.UtcNow,
    CustomerPhone= "555-9876"
};
Reservation reservation = new Reservation
{
    CustomerName = createdreservationrequest.CustomerName,
    ReservationDate = createdreservationrequest.ReservationTime,
    GuestCount = createdreservationrequest.NumberOfGuests,
    DiningTableId= createdreservationrequest.DiningTableId,
    CreatedAt= createdreservationrequest.CreatedAt,
    CustomerPhone= createdreservationrequest.CustomerPhone
};

//_context.Reservation.Add(reservation);
//_context.SaveChanges();

//var result=_context.Reservation
//    .Include(r=>r.DiningTable)
//    .ThenInclude(dt=>dt.Restaurant)
//    .ToList();
//foreach (var res in result)
//{
//    Console.WriteLine($"Reservation for {res.CustomerName} at {res.ReservationDate}, Table Number: {res.DiningTable.DiningTableNumber}, Restaurant: {res.DiningTable.Restaurant.Name}");
//}

//var result = _context.Restaurant
//    .Include(r => r.Menu)
//    .ThenInclude(m => m.Categories)
//    .ThenInclude(c => c.Products)
//    .ToList();

//foreach (var res in result)
//{
//    Console.WriteLine($"Restaurant: {res.Name}");
//    foreach (var categories in res.Menu.Categories)
//    {
//        Console.WriteLine($"Category: {categories.Name}");
//        foreach (var products in categories.Products)
//        {
//            Console.WriteLine($"Product: {products.Name} - ${products.Price}");
//        }
//    }
//}

//var result = _context.Staffs
//    .Include(s => s.Restaurants)
//    .ToList();
//foreach (var staff in result)
//{
//    Console.WriteLine($"Staff: {staff.FullName}, Position: {staff.Position}");
//    foreach (var res in staff.Restaurants)
//    {
//        Console.WriteLine($"Works at Restaurant: {res.Name}");
//    }
//}
//var existingMenu = _context.Menu.FirstOrDefault(m => m.Id == 1);

//if (existingMenu == null)
//{
//    throw new Exception("Menu with Id=1 does not exist!");
//}
//var updaterestaurantrequest = new
//{
//  MenuId=existingMenu.Id
//};
//var restaurantToUpdate = _context.Restaurant.FirstOrDefault(r => r.Id == 8);
//if (restaurantToUpdate != null)
//{
//    restaurantToUpdate.MenuId = updaterestaurantrequest.MenuId;
//    _context.SaveChanges();
//}