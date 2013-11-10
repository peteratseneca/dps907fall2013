using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionFilter.ViewModels
{
    public class LoggedExceptionAdd
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }
        public string StackTrace { get; set; }
    }

    public class LoggedExceptionFull : LoggedExceptionAdd
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
    }

}
