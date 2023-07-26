using System;
using System.Collections.Generic;
using System.Linq;
using Department.Controllers;
using Department.Entity;

namespace Department.Services;

public static class CommissionServices
{
    //Создание новой комиссии
    public static void CreateCommission(string name, DateTime dateOfFoundation, int headId)
    {
        
            string result = "Такая комиссия уже существует";
            bool isExist = ApplicationContext.GetInstance().Commission.Any(x =>
                x.Name == name );
            if (!isExist)
            {
                Commission commission = new Commission
                {
                    Name = name,
                    DateOfFoundation = dateOfFoundation,
                    HeadId = headId
                };
                result = "Комиссия " + commission.Name + " добавлена";
            }

            Console.WriteLine(result);
        
    }
    //Изменение Комиссии по фильтрам(Name,DateOfFoundation,HeadId)
    public static void EditCommission(int id, string propertyName, object value)
    {
        var commission = ApplicationContext.GetInstance().Commission.FirstOrDefault(x => x.CommissionId == id);
        try
        {
            if (commission == null)
            {
                Console.WriteLine("Комиссия не найден");
            }

            switch (propertyName.ToLower())
            {
                
                case "name":
                    commission.Name = value.ToString();
                    break;
                case "dateoffoundation":
                    commission.DateOfFoundation = Convert.ToDateTime(value);
                    break;
                case "id":
                    commission.HeadId = Convert.ToInt32(value.ToString());
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
    //Удаление комиссии
    public static void RemoveCommission(int id)
    {
        
        {
            string result = "Комиссии не существует";
            bool isExist = ApplicationContext.GetInstance().Commission.Any(x => x.CommissionId == id);
            if (isExist)
            {
                Commission commission = ApplicationContext.GetInstance().Commission.FirstOrDefault(x => x.CommissionId == id);
                ApplicationContext.GetInstance().Commission.Remove(commission);
                result = "Комиссия" + commission.Name + " удалена";
            }

            Console.WriteLine(result);
        }
    }
    //Получить все комиссии
    public static void GetALlCommissions()
    {
        
        {
            List<Commission> commissions = ApplicationContext.GetInstance().Commission.ToList();
            foreach (Commission commission in commissions)
            {
                Console.WriteLine($"{commission.CommissionId} {commission.Name} {commission.DateOfFoundation} {commission.HeadId} ");
            }
        }
    }
    //Удалить все комиссии
    public static void RemoveAllCommissions()
    {
        
        {
            ApplicationContext.GetInstance().Commission.RemoveRange(ApplicationContext.GetInstance().Commission);
            Console.WriteLine("Все комиссии удалены");
        }
    }
}