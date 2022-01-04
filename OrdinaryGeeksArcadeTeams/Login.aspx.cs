using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using OrdinaryGeeksArcadeTeams.Models;
using Newtonsoft.Json;

namespace OrdinaryGeeksArcadeTeams
{
    public partial class Login : System.Web.UI.Page
    {
    public    static HttpClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://www.ordinarygeeks.com/OrdinaryGeeksArcade/");

            // SqlConnection Conn = new SqlConnection("Data Source = tcp:s23.winhost.com; Initial Catalog = DB_140510_arcade; User ID = DB_140510_arcade_user; Password = ArcadeOG; Integrated Security = False;")

        }

        async Task<Employee> CheckPassword()
        {
            Employee employee = null;
           // client.GetStringAsync($"employeeapi/checkpassword/" + Username.Text + "/" + Password.Text).Result.

            var json = await client.GetAsync($"api/employeesapi/checkpassword/" + Username.Text + "/" + Password.Text);
            if (json.StatusCode == HttpStatusCode.OK)
            {
                var empJson = await client.GetStringAsync($"api/employeesapi/checkpassword/" + Username.Text + "/" + Password.Text);
                //var employeeJson = await client.GetStringAsync($"api/employeesapi/"+json.Respon)

                employee = JsonConvert.DeserializeObject<Employee>(empJson);
              //  employee = await Task.Run(() => JsonConvert.DeserializeObject<Employee>(json.Content.ToString()));

            }
            return employee;
        }
        public void Login_Click(object sender, EventArgs e)
        {


            //  Sqlcommand Username.Text


            var task = Task.Run(async () => await CheckPassword());

           
            Employee result = task.Result;



            //           Username.Text = result.FirstName;
            //          Password.Text = result.PassWord;

            if (result != null)
                Response.Redirect("GameSelection.aspx?id=" + result.ID);
            else
            {
                RequiredFieldValidator2.Text = "UserName Or Password Was Incorrect";
                RequiredFieldValidator2.Visible = true;
            }

        }
    }
}