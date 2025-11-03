
using Labb2.Models;

namespace Labb2.Services;

public class Db
{
    public List<User> Users { get; } = new();
    public List<Building> Buildings { get; } = new();
    public List<Lease> Leases { get; } = new();


    public List<Student> Students => Users.OfType<Student>().ToList();
    public List<Admin> Admins => Users.OfType<Admin>().ToList();
    public List<Room> Rooms => Buildings.SelectMany(b => b.Rooms).ToList();


    public User? GetUserByEmail(string? email) =>
    Users.FirstOrDefault(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));


    public void SeedDemoData()
    {
        if (Buildings.Count > 0) return; 


        var b1 = new Building { Name = "meow", Address = "skogsfrugatan 1" };
        var b2 = new Building { Name = "woof", Address = "sjöstensgatan 15" };


        b1.Rooms.Add(new Room(b1, "A101", RoomType.Single, floor: 1, areaM2: 18));
        b1.Rooms.Add(new Room(b1, "A102", RoomType.Double, floor: 1, areaM2: 22));
        b2.Rooms.Add(new Room(b2, "B201", RoomType.Single, floor: 2, areaM2: 17));
        b2.Rooms.Add(new Room(b2, "B202", RoomType.Double, floor: 2, areaM2: 24));


        Buildings.AddRange(new[] { b1, b2 });


        var admin = new Admin { FullName = "Admin One", Email = "admin@bobo.se", Password = Password.Store("admin123") };
        var student = new Student { FullName = "Student One", Email = "student@bobo.se", Password = Password.Store("student123") };


        Users.AddRange(new User[] { admin, student });
    }
}
