using System;
using System.Collections.Generic;

namespace Labb2.Models;

public abstract class User
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public abstract string Role { get; }
}
public class Student : User
{
    public override string Role => "Student";
    public List<Lease> Leases { get; } = new();
}


public class Admin : User
{
    public override string Role => "Admin";
}