using Angular2.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Angular2.Controllers
{
    public class AccountController : Controller
    {
        public LoginResponse Login(String username, String password) {
            var response = new LoginResponse("The response for a login.");

            response.Token = "";
            

            return response;
        }

        public Object Register() {
            return "";
        }
    }

    public class LoginResponse : RootResponse {
        
        public String Token { get; set; }

        public Employee User { get; set; } = new Employee();
            
        public LoginResponse() : base() {
            
        }

        public LoginResponse(String des) : base(des)
        {

        }
    }



    public class RootResponse {

        private Stopwatch timer = new Stopwatch();

        public RootResponse() {
            timer.Stop();
        }

        public RootResponse(String des) {
            timer.Start();
            Description = des;
        }

        private TimeSpan CalculateExecutionTimer() {
            timer.Stop();
            return timer.Elapsed;
        }

        public List<Error> Errors { get; set; } = new List<Error>();
        public TimeSpan ExecutionTime { get {
                return CalculateExecutionTimer();
            } set {
                this.ExecutionTime = value;
            } }
        public String Description { get; set; } = "Root response object";

        public DateTime TimeRequested { get; set; } = DateTime.UtcNow;

        public void AddError(String m, int level = 1) {
            Errors.Add(new Error()
            {
                Message = m,
                ErrorLevel = level
            });
        }
        
    }
    public class Error {
        public String Message { get; set; } = "No message available";
        [Range(1, 10)]
        public int ErrorLevel { get; set; } = 1;
    }
}
