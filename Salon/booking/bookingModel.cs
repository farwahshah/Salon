using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salon.booking
    {
        internal class bookingModel
        {
            private string customerName;
            private string serviceName;
            private string Appointment;
            private int Bill;

            public bookingModel()
            {

            }
            public bookingModel(string customerName)
            {
                this.customerName = customerName;
            }

            public bookingModel(string customerName, string serviceName, string Appointment, int Bill)
            {
                this.customerName = customerName;
                this.serviceName = serviceName;
                this.Appointment = Appointment;
                this.Bill = Bill;
            }

            public void SetCustomerName(string customerName)
            {
                this.customerName = customerName;
            }
            public string GetCustomerName()
            {
                return customerName;
            }

            public void SetServiceName(string serviceName)
            {
                this.serviceName = serviceName;
            }
            public string GetServiceName()
            {
                return serviceName;
            }

            public void SetAppointment(string Appointment)
            {
                this.Appointment = Appointment;
            }
            public string GetAppointment()
            {
                return Appointment;
            }

            public void SetBill(int Bill)
            {
                this.Bill = Bill;
            }
            public int GetBill()
            {
                return Bill;
            }

            public override string ToString()
            {
                return $"{customerName},{serviceName},{Appointment},{Bill}";
            }
        }
    }


