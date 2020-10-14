using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.common;
using TimeSheet.common.Models;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDone;
            int hoursDone; 
            int timeTotal= 0;

            List<TimeSheetEntryModel> timeSheetEntries = new List<TimeSheetEntryModel>();
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel {Name = "Acme", HourlyRate = 150 },
                new CustomerModel {Name = "ABC", HourlyRate = 125}
            };
            List<PaymentModel> payments = new List<PaymentModel>
            {
                new PaymentModel {Label = "Overtime", HourLimit = 40, HourlyRate = 75 },
                new PaymentModel {Label = "time", HourLimit = 0, HourlyRate = 50}
            };


            foreach (var customer in customers)
            {
                timeTotal = TimesheetProcessor1.CalculateTimeFourCustomer(timeSheetEntries, "Acme");
                SimulateSendingMail(customer, timeTotal);
            }

            timeTotal = TimesheetProcessor1.CalculateTimeWorked(timeSheetEntries);

            foreach (var paymentModel in payments)
            {
                if (timeTotal > paymentModel.HourLimit)
                {
                    SimulatePayment(paymentModel, timeTotal);
                    break;
                }
            }
            
            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        static List<TimeSheetEntryModel> GetTimeSheetEntries()
        {
            List<TimeSheetEntryModel> timeSheetEntries = new List<TimeSheetEntryModel>();
            
            bool continueEntering;
            
            do
            {
                Console.Write("Enter what you did: ");
                string workDone = Console.ReadLine();

                Console.Write("How long did you do it for in hours: ");
                int hoursDone = int.Parse(Console.ReadLine());

                TimeSheetEntryModel entry = new TimeSheetEntryModel
                {
                    HoursWorked = hoursDone,
                    WorkDone = workDone
                };
                timeSheetEntries.Add(entry);

                Console.Write("Do you want to enter more time (yes/no):");
                continueEntering = Console.ReadLine().ToLower() == "yes";
            }
            while (continueEntering == true);

            return timeSheetEntries;
        }

        static void SimulatePayment(PaymentModel paymentModel, int hours)
        {
            decimal amountToPay = PaymentProcessor.CalculatePayment(paymentModel, hours);

            Console.WriteLine($"You will get paid $ {amountToPay} for your {paymentModel.Label}."); 
        }

        static void SimulateSendingMail(CustomerModel customerModel, int hours)
        {
            
            decimal amountToBill = hours * customerModel.HourlyRate;
            
            Console.WriteLine($"Simulating Sending email to {customerModel.Name}");
            Console.WriteLine($"Your bill is {amountToBill} for the hours worked.");
        }
    }
}
