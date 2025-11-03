using Labb2.Models;

namespace Labb2.Services;

public class HousingService
{
    private readonly Db _db;
    public HousingService(Db db) => _db = db;


    public IEnumerable<Room> GetAvailableRooms() => _db.Rooms.Where(r => r.Status == RoomStatus.Available);


    public Room AddRoom(Building building, string number, RoomType type, int floor = 1, double areaM2 = 18)
    {
        var room = new Room(building, number, type, floor, areaM2);
        building.Rooms.Add(room);
        return room;
    }


    public Lease ApplyForRoom(Student student, Room room)
    {
        var lease = new Lease { Tenant = student, Room = room, StartDate = DateTime.Now };
        _db.Leases.Add(lease);
        student.Leases.Add(lease);
        room.Status = RoomStatus.Occupied;
        return lease;
    }
}
