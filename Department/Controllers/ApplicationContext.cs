
using Department.Entity;
using Microsoft.EntityFrameworkCore;
namespace Department.Controllers;


//Наследую производный класс DbContext, чтобы получить возможность переопределить метод
//OnConfiguring для соединения с БД, передавая ConnectionString(поле), где лежит путь
public class ApplicationContext : DbContext
{
    private string СonnectionString = "server = localhost; port = 3306; username = root; password = 19202122;database = муниципалитет";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(СonnectionString);

    }

    public DbSet<Employee>? Employee { get; set; }
    public DbSet<Meeting>? Meeting { get; set; }
    public DbSet<Commission>? Commission { get; set; }
    public DbSet<Membership>? Membership { get; set; }
    
    private static ApplicationContext instance;

    public ApplicationContext()
    {
        
    }

    public static ApplicationContext GetInstance()
    {
        if (instance == null)
        {
            instance = new ApplicationContext();
        }
        return instance;
    }
    
}
