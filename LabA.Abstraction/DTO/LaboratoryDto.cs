namespace LabA.Abstraction.DTO;

public class LaboratoryDto
{
    public int LaboratoryId { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public CityDto City { get; set; }

    public ICollection<EmployeeDto> Employees { get; set; }

    public ICollection<LaboratoryScheduleDto> LaboratorySchedule { get; set; }
}

/* {
  "laboratoryId": 1,
  "address": "вул. Пулюя 9",
  "phoneNumber": "0500333145",
  "city": {
    "cityId": 2,
    "cityName": "Львів"
  },
  "employees": [],
  "laboratorySchedule": [
    {
      "laboratoryScheduleId": 0,
      "schedule": {
        "scheduleId": 2,
        "startTime": "08:00:00",
        "endTime": "17:00:00",
        "collectionEndTime": "13:00:00",
        "day": {
          "dayId": 1,
          "dayName": "Понеділок"
        }
      }
    },
    {
      "laboratoryScheduleId": 0,
      "schedule": {
        "scheduleId": 5,
        "startTime": "08:00:00",
        "endTime": "12:00:00",
        "collectionEndTime": "16:00:00",
        "day": {
          "dayId": 2,
          "dayName": "Вівторок"
        }
      }
    },
    {
      "laboratoryScheduleId": 0,
      "schedule": {
        "scheduleId": 7,
        "startTime": "08:00:00",
        "endTime": "10:00:00",
        "collectionEndTime": "14:00:00",
        "day": {
          "dayId": 4,
          "dayName": "Четвер"
        }
      }
    },
    {
      "laboratoryScheduleId": 0,
      "schedule": {
        "scheduleId": 11,
        "startTime": "08:30:00",
        "endTime": "11:45:00",
        "collectionEndTime": "15:00:00",
        "day": {
          "dayId": 5,
          "dayName": "П'ятниця"
        }
      }
    },
    {
      "laboratoryScheduleId": 0,
      "schedule": {
        "scheduleId": 10,
        "startTime": "08:30:00",
        "endTime": "11:45:00",
        "collectionEndTime": "15:00:00",
        "day": {
          "dayId": 6,
          "dayName": "Субота"
        }
      }
    }
  ]
}
*/