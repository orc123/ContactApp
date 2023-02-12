using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp;

public class CreateOrUpdatePerson
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Job { get; set; }
    public bool BestFriend { get; set; }
    public DateTime? BirthDate { get; set; }
}
