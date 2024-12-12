using LabA.Abstraction.DTO;
using LabA.Abstraction.IModel;
using LabA.DAL.Models;

namespace LabA.DAL.Mappers.Dto;

public static class AnalysisMapper
{
    public static AnalysisDto ToDto(this IAnalysis analysis)
    {
        return new AnalysisDto
        {
            AnalysisId = analysis.AnalysisId,
            Name = analysis.Name,
            Description = analysis.Description,
            Price = analysis.Price,
            Category = AnalysisCategoryMapper.ToDto(analysis.Category),
            AnalysisBiomaterial = analysis.AnalysisBiomaterials.Select(AnalysisBiomaterialMapper.ToDto).ToList()
        };
    }

    public static IAnalysis ToModel(this AnalysisDto dto)
    {
        return new Analysis
        {
            AnalysisId = dto.AnalysisId,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.Category.AnalysisCategoryId,
            Category = AnalysisCategoryMapper.ToModel(dto.Category) as AnalysisCategory,
            AnalysisBiomaterials = dto.AnalysisBiomaterial.Select(AnalysisBiomaterialMapper.ToModel).Select(ab => (AnalysisBiomaterial)ab).ToList()
        };
    }
}

public static class AnalysisBiomaterialMapper
{
    public static AnalysisBiomaterialDto ToDto(this IAnalysisBiomaterial analysisBiomaterial)
    {
        return new AnalysisBiomaterialDto
        {
            AnalysisBiomaterialId = analysisBiomaterial.AnalysisBiomaterialId,
            AnalysisId = analysisBiomaterial.AnalysisId,
            Biomaterial = BiomaterialMapper.ToDto(analysisBiomaterial.Biomaterial)
        };
    }

    public static IAnalysisBiomaterial ToModel(this AnalysisBiomaterialDto dto)
    {
        return new AnalysisBiomaterial
        {
            AnalysisBiomaterialId = dto.AnalysisBiomaterialId,
            AnalysisId = dto.AnalysisId,
            Biomaterial = (Biomaterial)BiomaterialMapper.ToModel(dto.Biomaterial)
        };
    }
}


public static class AnalysisCategoryMapper
{
    public static AnalysisCategoryDto ToDto(this IAnalysisCategory category)
    {
        return new AnalysisCategoryDto
        {
            AnalysisCategoryId = category.AnalysisCategoryId,
            CategoryName = category.CategoryName
        };
    }

    public static IAnalysisCategory ToModel(this AnalysisCategoryDto dto)
    {
        return new AnalysisCategory
        {
            AnalysisCategoryId = dto.AnalysisCategoryId,
            CategoryName = dto.CategoryName
        };
    }
}

public static class BiomaterialMapper
{
    public static BiomaterialDto ToDto(this IBiomaterial biomaterial)
    {
        return new BiomaterialDto
        {
            BiomaterialId = biomaterial.BiomaterialId,
            BiomaterialName = biomaterial.BiomaterialName
        };
    }

    public static IBiomaterial ToModel(this BiomaterialDto dto)
    {
        return new Biomaterial
        {
            BiomaterialId = dto.BiomaterialId,
            BiomaterialName = dto.BiomaterialName
        };
    }
}

public static class LaboratoryMapper
{
    public static LaboratoryDto ToDto(this ILaboratory laboratory)
    {
        return new LaboratoryDto
        {
            LaboratoryId = laboratory.LaboratoryId,
            Address = laboratory.Address,
            PhoneNumber = laboratory.PhoneNumber,
            City = (CityMapper.ToDto(laboratory.City))!,
            Employees = laboratory.Employees?.Select(EmployeeMapper.ToDto).ToList()!,
            LaboratorySchedule = laboratory.LaboratorySchedules.Select(LaboratoryScheduleMapper.ToDto).ToList()
        };
    }

    public static ILaboratory ToModel(this LaboratoryDto dto)
    {
        return new Laboratory
        {
            LaboratoryId = dto.LaboratoryId,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            City = (City)CityMapper.ToModel(dto.City),
            CityId = dto.City.CityId,
            Employees = dto.Employees?.Select(EmployeeMapper.ToModel).ToList() as ICollection<Employee>,
            LaboratorySchedules = dto.LaboratorySchedule.Select(ls => ls.ToModel() as LaboratorySchedule).ToList()
        };
    }
}

public static class LaboratoryScheduleMapper
{
    public static LaboratoryScheduleDto ToDto(this ILaboratorySchedule laboratorySchedule)
    {
        return new LaboratoryScheduleDto
        {
            LaboratoryScheduleId = laboratorySchedule.LaboratoryScheduleId,
            Schedule = ScheduleMapper.ToDto(laboratorySchedule.Schedule)
        };
    }

    public static ILaboratorySchedule ToModel(this LaboratoryScheduleDto dto)
    {
        return new LaboratorySchedule
        {
            LaboratoryScheduleId = dto.LaboratoryScheduleId,
            Schedule = (Schedule)ScheduleMapper.ToModel(dto.Schedule)
        };
    }
}

public static class EmployeeMapper
{
    public static EmployeeDto ToDto(this IEmployee employee)
    {
        return new EmployeeDto
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            Email = employee.Email,
            Position = PositionMapper.ToDto(employee.Position),
            LaboratoryId = employee.LaboratoryId
        };
    }

    public static IEmployee ToModel(this EmployeeDto dto)
    {
        return new Employee
        {
            EmployeeId = dto.EmployeeId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Position = PositionMapper.ToModel(dto.Position) as Position,
            LaboratoryId = dto.LaboratoryId
        };
    }
}

public static class PositionMapper
{
    public static PositionDto ToDto(this IPosition position)
    {
        return new PositionDto
        {
            PositionId = position.PositionId,
            PositionName = position.PositionName
        };
    }

    public static IPosition ToModel(this PositionDto dto)
    {
        return new Position
        {
            PositionId = dto.PositionId,
            PositionName = dto.PositionName
        };
    }
}

public static class ScheduleMapper
{
    public static ScheduleDto ToDto(this ISchedule schedule)
    {
        return new ScheduleDto
        {
            ScheduleId = schedule.ScheduleId,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            CollectionEndTime = schedule.CollectionEndTime,
            Day = DayMapper.ToDto(schedule.Day)
        };
    }

    public static ISchedule ToModel(this ScheduleDto dto)
    {
        return new Schedule
        {
            ScheduleId = dto.ScheduleId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            CollectionEndTime = dto.CollectionEndTime,
            Day = DayMapper.ToModel(dto.Day) as Day,
            DayId = dto.Day.DayId
        };
    }
}

public static class DayMapper
{
    public static DayDto ToDto(this IDay day)
    {
        return new DayDto
        {
            DayId = day.DayId,
            DayName = day.DayName
        };
    }

    public static IDay ToModel(this DayDto dto)
    {
        return new Day
        {
            DayId = dto.DayId,
            DayName = dto.DayName
        };
    }
}

public static class OrderMapper
{
    public static OrderDto ToDto(this IOrder order)
    {
        return new OrderDto
        {
            OrderId = order.OrderId,
            Number = order.Number,
            Status = StatusMapper.ToDto(order.Status),
            Employee = EmployeeMapper.ToDto(order.Employee),
            Client = ClientMapper.ToDto(order.Client),
            BiomaterialCollectionDate = order.BiomaterialCollectionDate,
            Fullprice = order.Fullprice,
            OrderAnalyses = order.OrderAnalyses.Select(OrderAnalysisMapper.ToDto).ToList()
        };
    }

    public static IOrder ToModel(this OrderDto dto)
    {
        return new Order
        {
            OrderId = dto.OrderId,
            Number = dto.Number,
            Status = StatusMapper.ToModel(dto.Status) as Status,
            Employee = EmployeeMapper.ToModel(dto.Employee) as Employee,
            Client = ClientMapper.ToModel(dto.Client) as Client,
            BiomaterialCollectionDate = dto.BiomaterialCollectionDate,
            Fullprice = dto.Fullprice,
            OrderAnalyses = dto.OrderAnalyses.Select(OrderAnalysisMapper.ToModel) as ICollection<OrderAnalysis>
        };
    }


}

public static class StatusMapper
{
    public static StatusDto ToDto(this IStatus status)
    {
        return new StatusDto
        {
            StatusId = status.StatusId,
            StatusName = status.StatusName
        };
    }

    public static IStatus ToModel(this StatusDto dto)
    {
        return new Status
        {
            StatusId = dto.StatusId,
            StatusName = dto.StatusName
        };
    }
}

public static class ClientMapper
{
    public static ClientDto ToDto(this IClient client)
    {
        return new ClientDto
        {
            ClientId = client.ClientId,
            FirstName = client.FirstName,
            LastName = client.LastName,
            PhoneNumber = client.PhoneNumber,
            Email = client.Email,
            Birthdate = client.Birthdate,
            Sex = SexMapper.ToDto(client.Sex)
        };
    }

    public static IClient ToModel(this ClientDto dto)
    {
        return new Client
        {
            ClientId = dto.ClientId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Birthdate = dto.Birthdate,
            Sex = SexMapper.ToModel(dto.Sex) as Sex
        };
    }
}

public static class SexMapper
{
    public static SexDto ToDto(this ISex sex)
    {
        return new SexDto
        {
            SexId = sex.SexId,
            SexName = sex.SexName
        };
    }

    public static ISex ToModel(SexDto dto)
    {
        return new Sex
        {
            SexId = dto.SexId,
            SexName = dto.SexName
        };
    }
}

public static class OrderAnalysisMapper
{
    public static OrderAnalysisDto ToDto(this IOrderAnalysis orderAnalysis)
    {
        return new OrderAnalysisDto
        {
            OrderAnalysisId = orderAnalysis.OrderAnalysisId,
            OrderId = orderAnalysis.OrderId,
            Analysis = AnalysisMapper.ToDto(orderAnalysis.Analysis)
        };
    }

    public static IOrderAnalysis ToModel(this OrderAnalysisDto dto)
    {
        return new OrderAnalysis
        {
            OrderAnalysisId = dto.OrderAnalysisId,
            OrderId = dto.OrderId,
            Analysis = AnalysisMapper.ToModel(dto.Analysis) as Analysis
        };
    }
}

public static class AnalysisResultMapper
{
    public static AnalysisResultDto ToDto(this IAnalysisResult analysisResult)
    {
        return new AnalysisResultDto
        {
            AnalysisResultId = analysisResult.AnalysisResultId,
            OrderAnalysis = analysisResult.OrderAnalysis != null ? OrderAnalysisMapper.ToDto(analysisResult.OrderAnalysis) : null,
            Indicator = analysisResult.Indicator,
            ExecutionDate = analysisResult.ExecutionDate,
            Description = analysisResult.Description
        };
    }

    public static IAnalysisResult ToModel(this AnalysisResultDto dto)
    {
        return new AnalysisResult
        {
            AnalysisResultId = dto.AnalysisResultId,
            OrderAnalysis = OrderAnalysisMapper.ToModel(dto.OrderAnalysis) as OrderAnalysis,
            Indicator = dto.Indicator,
            ExecutionDate = dto.ExecutionDate,
            Description = dto.Description
        };
    }
}

public static class CityMapper
{
    public static CityDto ToDto(this ICity city)
    {
        return new CityDto
        {
            CityId = city.CityId,
            CityName = city.CityName
        };
    }

    public static ICity ToModel(this CityDto dto)
    {
        return new City
        {
            CityId = dto.CityId,
            CityName = dto.CityName
        };
    }
}

