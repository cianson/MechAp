using SQLite;

namespace MechAp
{
    

    public class User
    {
        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        [PrimaryKey, MaxLength(15), NotNull]
        public string Username { get; set; }

        [MaxLength(14), NotNull]
        public string Password { get; set; }

        [MaxLength(50), NotNull]
        public string Email { get; set; }

    }


    public class Garage
    {
        public string Username { get; set ; }

        [PrimaryKey, NotNull]
        public string CarName { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Style { get; set; }

        public string Milage { get; set; }

        public int Year { get; set; }

        public int YearGroup { get; set; }
    }
    public class Tracker
    {
        [PrimaryKey, AutoIncrement]
        public int record_id { get; set; }
     
        public string Username { get; set; }
        
        public string CarName { get; set; }
       
        public string DateCompleted { get; set; }
      
        public string MaintenanceTitle { get; set; }

        public string AtMilage { get; set; }

        public string DateOfNextSErvice { get; set; }
        public string MilageOfNextService { get; set; }
     
        public bool ReminderSet { get; set; }
    }
}
