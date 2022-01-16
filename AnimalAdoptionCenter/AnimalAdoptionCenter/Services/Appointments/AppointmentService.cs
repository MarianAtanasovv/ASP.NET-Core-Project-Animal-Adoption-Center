using System;
using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.WebPages;
using AnimalAdoptionCenter.Services.Event;

namespace AnimalAdoptionCenter.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext data;
       
        public AppointmentService(ApplicationDbContext data)
        {
            this.data = data;
            
        }
        public bool CheckHour(string hour, string date)
        {
            var checkForDate = this.data.Appointments.Any(x => x.StartHour == hour && x.Date == date);
            FreeHours(date);

            if (checkForDate)
            {
                return false;
            }
            return true;
        }

        public StringBuilder FreeHours(string date)
        {
            var takenHours = this.data.Appointments.Where(x => x.Date == date).Select(x => x.StartHour).ToList();
            var workingHours = new List<string>()
            {
               "10", "11","12", "13","14", "15","16", "17",
            };

            var freeHours = workingHours.Except(takenHours);

            var sb = new StringBuilder();
            sb.AppendLine("This hour is reserved!");
            sb.AppendLine("Free hours:");
            foreach (var item in freeHours)
            {
                sb.AppendLine(item + ":00" + ", ");
            }
            return sb;
        }

        public int Delete(int id)
        {
            var appointmentToDelete = this.data.Appointments.Single(x => x.Id == id);
            this.data.Remove(appointmentToDelete);
            this.data.SaveChanges();

            return appointmentToDelete.Id;
        }

        public int Add(AddEventFormModel model)
        {
            
            var eventData = new Data.Models.Appointment
            {
                FullName = model.FullName,
                Phone = model.PhoneNumber,
                Description = model.Description,
                Date = model.Date,
                StartHour = model.StartHour,

            };

            this.data.Appointments.Add(eventData);
            this.data.SaveChanges();

            return eventData.Id;

        }

        public IEnumerable<AllAppointmentsViewModel> All()
        {
            var appointments = this.data.Appointments.Select(x => new AllAppointmentsViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                FullName = x.FullName,
                Phone = x.Phone,
                StartHour = x.StartHour.Substring(0, 10)
            }).ToList();

            return appointments;
        }

        public void DeleteAfterDate()
        {
            var appointments = this.data.Appointments.ToList();
            foreach (var appointment in appointments)
            {
                if (appointment.Date.AsDateTime() < DateTime.Now)
                {
                    this.data.Appointments.Remove(appointment);
                    this.data.SaveChanges();
                }
            }
        }
    }
}
