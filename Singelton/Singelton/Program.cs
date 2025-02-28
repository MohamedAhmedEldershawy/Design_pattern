 using System;

public class DatabaseConnectionManager
{
    
    private static DatabaseConnectionManager _instance;

    
    private static readonly object _lock = new object();

    
    private DatabaseConnectionManager()
    {
        Console.WriteLine("Database Connection Established.");
    }

    
    public static DatabaseConnectionManager Instance
    {
        get
        {
            lock (_lock) 
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnectionManager();
                }
                return _instance;
            }
        }
    }

    public void ExecuteQuery(string query)
    {
        Console.WriteLine($"Executing Query: {query}");
    }
}

class Program
{
    static void Main(string[] args)
    {
     
        var db1 = DatabaseConnectionManager.Instance;
        db1.ExecuteQuery("SELECT * FROM Users");

       
        var db2 = DatabaseConnectionManager.Instance;
        db2.ExecuteQuery("INSERT INTO Users (Name) VALUES ('John')");

        
        Console.WriteLine(ReferenceEquals(db1, db2)); 
    }
}
