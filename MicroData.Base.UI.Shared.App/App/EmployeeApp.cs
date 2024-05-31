using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class EmployeeApp : BaseBaseApp<EmployeeViewModel,EmployeeModel> , IEmployeeApi
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeApp(IEmployeeService employeeService, IMapper mapper) : base(employeeService, mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }


    }
}
