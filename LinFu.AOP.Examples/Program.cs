using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinFu.AOP.Interfaces;
using SampleLibrary;

namespace LinFu.AOP.Examples
{
    public class SampleExceptionHandler : IExceptionHandler
    {
        public bool CanCatch(IExceptionHandlerInfo exceptionHandlerInfo)
        {
            return true;
        }

        public void Catch(IExceptionHandlerInfo exceptionHandlerInfo)
        {
            var exception = exceptionHandlerInfo.Exception;
            Console.WriteLine("Exception caught: {0}", exception);
            
            // This line tells LinFu.AOP to swallow the thrown exception;
            // By default, LinFu will just rethrow the exception
            exceptionHandlerInfo.ShouldSkipRethrow = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Hook the sample exception handler into the application
            ExceptionHandlerRegistry.SetHandler(new SampleExceptionHandler());

            var account = new BankAccount(100);

            // Without LinFu's dynamic exception handling, the 
            // next line of code will cause the app to crash:
            account.Deposit(100);

            return;
        }
    }
}
