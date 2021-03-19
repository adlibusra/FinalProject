using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)  // bu clası thisle sucses de çalışır // constructer baselerle çalışması
        {
            Message = message;
            
        }
        public Result(bool success)
        {
           
            Success = success;
        }

        public bool Success  { get; }

        public string Message { get; } 
    }
}
