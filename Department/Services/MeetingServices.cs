using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Windows.Documents;
using Department.Controllers;
using Department.Entity;

namespace Department.Services;

public static class MeetingServices
{
    //Создание нового собрания
    public static void CreateMeeting(int newCommissionId, DateTime newDateOfMeeting, string newPlaceOfMeeting, int newHeadId )
    {
        
        {
            string result = "Такое собрание уже существует";
            bool isExist = ApplicationContext.GetInstance().Meeting.Any(x => x.CommissionId == newCommissionId);
            if (!isExist)
            {
                Meeting meeting = new Meeting()
                {
                    CommissionId = newCommissionId,
                    DateOfMeeting = newDateOfMeeting,
                    PlaceOfMeeting = newPlaceOfMeeting,
                    HeadId = newHeadId
                };
                ApplicationContext.GetInstance().SaveChanges();
                result = "Собрание " + meeting.CommissionId + " зарегистрировано";
            }

            Console.WriteLine(result);
        }
    }
    //Изменение Собрания по фильтрам(CommissionId,DateOfMeeting,PlaceOfMeeting, HeadId)
    public static void EditMeeting(int id, string propertyName, object value)
    {
        var meeting = ApplicationContext.GetInstance().Meeting.FirstOrDefault(x => x.MeetingId == id);
        try
        {
            if (meeting == null)
            {
                Console.WriteLine("Собрание не найден");
            }

            switch (propertyName.ToLower())
            {
                case "commissionid":
                    meeting.CommissionId = Convert.ToInt32(value);
                    break;
                case "dateofmeeting":
                    meeting.DateOfMeeting = Convert.ToDateTime(value.ToString());
                    break;
                case "placeofmeeting":
                    meeting.PlaceOfMeeting = value.ToString();
                    break;
                case "headid":
                    meeting.HeadId = Convert.ToInt32(value);
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
    //Удаление Собрания
    public static void RemoveMeeting(int meetingId)
    {
        
        {
            Meeting meeting = ApplicationContext.GetInstance().Meeting.FirstOrDefault((x => x.MeetingId == meetingId));
            ApplicationContext.GetInstance().Remove(meeting);
            ApplicationContext.GetInstance().SaveChanges();
            Console.WriteLine("Удаление " + meeting.CommissionId + " зарегистрировано"); 
        }
    }
    //Получить все Собрания
    public static void GetAllMeetings()
    {
        
        {
            List<Meeting> meetings = ApplicationContext.GetInstance().Meeting.ToList();
            foreach (Meeting meeting in meetings)
            {
                Console.WriteLine($"{meeting.MeetingId} {meeting.CommissionId} {meeting.DateOfMeeting} {meeting.PlaceOfMeeting} {meeting.HeadId} ");
            }
        }
    }
    //Удалить все Собрания
    public static void RemoveMeetings()
    {
        
        {
            ApplicationContext.GetInstance().RemoveRange(ApplicationContext.GetInstance().Meeting);
            ApplicationContext.GetInstance().SaveChanges();
            Console.WriteLine("Все собрания удалены"); 
        }
    }
}