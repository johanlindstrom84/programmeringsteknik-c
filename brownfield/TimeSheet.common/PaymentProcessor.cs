using System;
using TimeSheet.common.Models;

namespace TimeSheet.common
{
    public class PaymentProcessor
    {
        public static decimal CalculatePayment(PaymentModel model, int hours)
        {
            if (hours < model.HourLimit)
                throw new ArgumentException($"Hours are '{hours}' less than model.HourLimit");

            return hours * model.HourlyRate;
        }
    }
}
