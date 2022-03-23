using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arbetsprov.Models;
using System.Net.Http;
using System.Text.Json;

namespace Arbetsprov.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public EmployeesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllEmployees()
        {

            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://dummy.restapiexample.com/api/v1/employees");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var empleyeesResponse = await JsonSerializer.DeserializeAsync<EmployeesResponse>(responseStream);
                if (empleyeesResponse != null && empleyeesResponse.data != null && empleyeesResponse.data.Length > 0)
                {
                    for (int i = 0; i < empleyeesResponse.data.Length - 1; i++)
                    {
                        employees.Add( new EmployeeViewModel() { Id = empleyeesResponse.data[i].id, Employee_name = empleyeesResponse.data[i].employee_name, Employee_salary = empleyeesResponse.data[i].employee_salary, Employee_age = empleyeesResponse.data[i].employee_age, Profile_image = empleyeesResponse.data[i].profile_image });
                    }
                }
            }
            //Add error handling
            else
            {
                //ToDo: Error handling. Deserialize error message.
            }
            return View(employees);
        }

        

        public async Task<IActionResult> SingleEmployee(int id)
        {
            //Should not be a list of one person!
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://dummy.restapiexample.com/api/v1/employee/{id}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var empleyeeResponse = await JsonSerializer.DeserializeAsync<EmployeeResponse>(responseStream);
                if (empleyeeResponse.data != null)
                {
                    employees.Add(new EmployeeViewModel() { Id = empleyeeResponse.data.id, Employee_name = empleyeeResponse.data.employee_name, Employee_salary = empleyeeResponse.data.employee_salary, Employee_age = empleyeeResponse.data.employee_age, Profile_image = empleyeeResponse.data.profile_image });
                }
            }
            //Add error handling
            else
            {
                //ToDo: Error handling. Deserialize error message.
            }
            return View(employees);
        }
    }
}
