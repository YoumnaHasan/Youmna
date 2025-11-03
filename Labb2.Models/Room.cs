using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Models;

public class Room
{
    public string Number { get; set; } = string.Empty;
    public int Floor { get; set; }
    public double AreaM2 { get; set; }
    public RoomType Type { get; set; }
    public RoomStatus Status { get; set; } = RoomStatus.Available;

    public Building Building { get;}

    public Room(Building building, string number, RoomType type, int floor = 1, double areaM2 = 18)
    {
        Building = building;
        Number = number;
        Type = type;
        Floor = floor;
        AreaM2 = areaM2;
    }


    public override string ToString() => $"{Building.Name} {Number} ({Type}, {Status})";
}
