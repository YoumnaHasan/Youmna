using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.Models;

public class Building
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public List<Room> Rooms { get; } = new();
}
