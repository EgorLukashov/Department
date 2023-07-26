using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Windows.Documents;
using Department.Controllers;
using Department.Entity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Department.Services;

public static class EmployeeServices
{
    //Создание нового сотрудника
    public static void CreateEmployee(string newSurname, string newName, string newMiddleName,string newAddress,string newPhone,string newStatus )
    {
        
        {
            string result = "Сотрудник уже существует";
            bool isExists = ApplicationContext.GetInstance().Employee.Any(x => x.Surname == newSurname && x.Name == newName && x.MiddleName == newMiddleName);
            if (!isExists)
            {
                Employee newEmployee = new Employee()
                {
                    Surname = newSurname,
                    Name = newName,
                    MiddleName = newMiddleName,
                    Address = newAddress,
                    Phone = newPhone,
                    Status = newStatus
                };
                ApplicationContext.GetInstance().SaveChanges();
                result = "Сотрудник: " + newName + " записан!";
            }

            Console.WriteLine(result);
        }
    }
    // Изменение данных сотрудника
    public static void EditEmployee(int id, string propertyName, object value)
    {
        var employee = ApplicationContext.GetInstance().Employee.FirstOrDefault(x => x.EmployeeId == id);
        try
        {
              if (employee == null)
              {
                Console.WriteLine("Сотрудник не найден");
              }

              switch (propertyName.ToLower())
              {
                  case "surname":
                    employee.Surname = value.ToString();
                    break;
                  case "name":
                    employee.Name = value.ToString();
                    break;
                  case "middlename":
                    employee.MiddleName = value.ToString();
                    break;
                  case "address":
                    employee.Address = value.ToString();
                    break;
                  case "phone":
                    employee.Phone = value.ToString();
                    break;
                  case "status":
                    employee.Status = value.ToString();
                    break;
                  default:
                      Console.WriteLine("Неправильное название колонки");
                      break;
             }

            ApplicationContext.GetInstance().SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    //Удаление сотрудника
    public static void RemoveEmployee(int id)
    {
        
        {
            string result = "Сотрудника с таким id не существует";
            bool isExist = ApplicationContext.GetInstance().Employee.Any(x => x.EmployeeId == id);
            if (isExist)
            {
                Employee employee   = ApplicationContext.GetInstance().Employee.FirstOrDefault(x => x.EmployeeId == id);
                ApplicationContext.GetInstance().Remove(employee);
                ApplicationContext.GetInstance().SaveChanges();
                result = "Сотрудник "+employee.Name+" успешно удалён";
            }

            Console.WriteLine(result);
        }
    }
    //Получить всех сотрудников
    public static void GetAllEmployees()
    {
        {
            List<Employee> employees = ApplicationContext.GetInstance().Employee.ToList();
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.EmployeeId} {employee.Surname} {employee.Name} {employee.MiddleName} {employee.Address} {employee.Phone} {employee.Status} ");
            }
        }
    }
    //Удалить всех сотрудников
    public static void RemoveAllEmployees()
    {
        
        {
            ApplicationContext.GetInstance().RemoveRange(ApplicationContext.GetInstance().Employee);
            ApplicationContext.GetInstance().SaveChanges();
            Console.WriteLine("Все сотрудники удалены");
            
        }
    }




}