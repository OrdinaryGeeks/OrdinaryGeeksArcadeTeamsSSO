using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrdinaryGeeksArcadeTeams.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace OrdinaryGeeksArcadeTeams
{
    public partial class WebForm1 : System.Web.UI.Page  
    {
        public Employee employee;
        protected void Page_Load(object sender, EventArgs e)
        {
            employee = new Employee();

            
              var task = Task.Run(async () => await GetEmployee());
              employee  = task.Result;


            string id  = Request.QueryString["id"];

          //  RegisterAsyncTask(new PageAsyncTask(GetEmployee));

         //   if(result.Tokens)
            // client = new HttpClient();
            // client.BaseAddress = new Uri("https://www.ordinarygeeks.com/OrdinaryGeeksArcade/");

        }

        
        public async Task<Employee> GetEmployee()
        {
             employee = null;
            string id = null;

            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"];
            }

            if (id != null) {
                var json = await Login.client.GetStringAsync($"api/EmployeesApi/"+id);
    
                employee = JsonConvert.DeserializeObject<Employee>(json);

                WelcomeLabel.Text = "Welcome to the Ordinary Geeks Arcade " +employee.UserName;
            }
            return employee;
        }


        async Task<bool> PutToken(Token token, bool active)
        {
            /*  employee = null;
              string id = null;

              if (Request.QueryString["id"] != null)
              {
                  id = Request.QueryString["id"];
              }


              */
            if (token != null)
            {
                token.Active = active;
                var serializedItem = JsonConvert.SerializeObject(token);

                var response = await Login.client.PutAsync($"api/TokensApi/" + token.ID, new StringContent(serializedItem, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
                //  var json = await Login.client.PutAsync($"EmployeesApi/" + employee.ID);

                // employee = await Task.Run(() => JsonConvert.DeserializeObject<Employee>(json));

            }
            return false;
        }


        async Task<bool> PutEmployee()
        {
          /*  employee = null;
            string id = null;

            if (Request.QueryString["id"] != null)
            {
                id = Request.QueryString["id"];
            }


            */
            if (employee != null)
            {
                var serializedItem = JsonConvert.SerializeObject(employee);

                var response = await Login.client.PutAsync($"api/EmployeesApi" + employee.ID, new StringContent(serializedItem, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
              //  var json = await Login.client.PutAsync($"EmployeesApi/" + employee.ID);

               // employee = await Task.Run(() => JsonConvert.DeserializeObject<Employee>(json));

            }
            return false;
        }

        protected void Planetary_Click(object sender, EventArgs e)
        {
            if(employee.EmployeeTokens.FindAll(s=>s.Active).Count>0)
            {
                //employee.EmployeeTokens.RemoveAt(0);

                //employee.EmployeeTokens[employee.EmployeeTokens.FindIndex(s => s.Active)];

                bool tokenSuccess = false;
                var tokenTask = Task.Run(async () => await PutToken(employee.EmployeeTokens[employee.EmployeeTokens.FindIndex(s => s.Active)], false));
                tokenSuccess = tokenTask.Result;

               // bool success = false;
               // var task = Task.Run(async () => await PutEmployee());
               // success = task.Result;

                if (tokenSuccess)
                    Response.Redirect("PlanetaryOrganizationDefender.aspx");
                else
                    PlanetarySuccess.Text = "Something failed using a token to allow access to the game";
            }

            PlanetarySuccess.Text = "You do not have enough tokens to play Planetary Organization Defender";
            //  Response.Redirect("GameSelection.aspx");
        }
    }
}