using System;
using System.Collections.Generic;
using System.Linq;
using Department.Controllers;
using Department.Entity;

namespace Department.Services;

public static class MemberServices
{
    //Создание нового члена
    public static void CreateMembership(string newPosition, DateTime newStartOfWork, DateTime newEndOfWork,
        int newCommissionId, int newEmployeeId)
    {
        
        {
            string result = "Такой член уже существует";
            bool isExist = ApplicationContext.GetInstance().Membership.Any(m => m.Position == newPosition && m.StartOfWork == newStartOfWork && m.EndOfWork == newEndOfWork && m.CommissionId == newCommissionId && m.EmployeeId == newEmployeeId);
            if (!isExist)
            {
                Membership member = new Membership()
                {
                    Position = newPosition,
                    StartOfWork = newStartOfWork,
                    EndOfWork = newEndOfWork,
                    CommissionId = newCommissionId,
                    EmployeeId = newEmployeeId
                };
                ApplicationContext.GetInstance().SaveChanges();
                result = "Членство " + member.MemberId + " записано";
            }

            Console.WriteLine(result);
        }
    }
    //Изменение Члена по фильтрам(MemberId,Position,StartOfWork,EndOfWork,CommissionId,EmployeeId)
    public static void EditMembership(int id, string propertyName, object value)
    {
        var membership = ApplicationContext.GetInstance().Membership.FirstOrDefault(x => x.MemberId == id);
        try
        {
            if (membership == null)
            {
                Console.WriteLine("Членство не найдено");
            }

            switch (propertyName.ToLower())
            {
                case "position":
                    membership.Position = value.ToString();
                    break;
                case "startofwork":
                    membership.StartOfWork = Convert.ToDateTime(value.ToString());
                    break;
                case "endofwork":
                    membership.StartOfWork = Convert.ToDateTime(value.ToString());
                    break;
                case "commissionid":
                    membership.CommissionId = Convert.ToInt32(value);
                    break;
                case "employeeid":
                    membership.EmployeeId = Convert.ToInt32(value);
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
    //Удаление члена
    public static void RemoveMember(int memberId)
    {
        
        {
            string result = "Члена с таким id не существует";
            bool isExist = ApplicationContext.GetInstance().Membership.Any(x => x.MemberId == memberId);
            if (isExist)
            {
                Membership membership = ApplicationContext.GetInstance().Membership.FirstOrDefault(x => x.MemberId == memberId);
                ApplicationContext.GetInstance().Remove(membership);
                ApplicationContext.GetInstance().SaveChanges();
                result = "Член "+membership.MemberId+" успешно удалён";
            }

            Console.WriteLine(result);
            
        }
    }
    //Получить всех членов
    public static void GetAllMembers()
    {
        
        {
            List<Membership> memberships = ApplicationContext.GetInstance().Membership.ToList();
            foreach (Membership membership in memberships)
            {
                Console.WriteLine($"{membership.MemberId} {membership.Position} {membership.StartOfWork} {membership.EndOfWork} {membership.CommissionId} {membership.EmployeeId}");
            }
        }
    }
    //Удалить всех членов
    public static void RemoveAllMembers()
    {
        
        {
            List<Membership> allMembers = ApplicationContext.GetInstance().Membership.ToList();
            ApplicationContext.GetInstance().RemoveRange(allMembers);
            ApplicationContext.GetInstance().SaveChanges();
            Console.WriteLine("Все сотрудники удалены");
        }
    }
}
