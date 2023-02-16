using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeesLoaderAnotherExample.Plugin
{
    [Author(Name = "Andrew Petrov")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Loading employees");
            var employeesList = new List<EmployeesDTO>();
            try
            {
                var userList = GetEmplyeesFromDummyJson();
                employeesList = userList.Select(user => new EmployeesDTO
                {
                    Name = $"{user.FirstName} {user.LastName}",
                }).ToList();

                foreach (var user in userList)
                {
                    var employee = employeesList.First(e => e.Name == $"{user.FirstName} {user.LastName}");
                    employee.AddPhone(user.Phone);
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.Message);
                logger.Error(ex.StackTrace);
            }
            logger.Info($"Loaded {employeesList.Count()} employees");
            return employeesList.Cast<DataTransferObject>();

        }

        public List<UserData> GetEmplyeesFromDummyJson()
        {
            string url = "https://dummyjson.com/users";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            string json = reader.ReadToEnd();
            //deserialize json
            var employeeJson = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersJson>(json);
            return employeeJson.Users;

        }
    }
}
