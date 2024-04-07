namespace Overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var medicalAppointment = new MedicalAppointment("Nathan Peek");
            var dateOfAppointment = medicalAppointment.GetDate();
            Console.WriteLine(dateOfAppointment);
            medicalAppointment.Reschedule(dateOfAppointment.AddDays(7));

            Console.ReadLine();
        }
    }

    class MedicalAppointmentPrinter
    {
        public void Print(MedicalAppointment medicalAppointment)
        {
            Console.WriteLine("Appointment will take place on " + medicalAppointment.GetDate());
        }
    }

    // Method overload. Need identifiable separation of either type or number of args
    public class MedicalAppointment
    {
        private string _patientName;
        private DateTime _date;

        public MedicalAppointment(string patientName, int daysFromNow = 7)
        {
            _patientName = patientName;
            _date = DateTime.Now.AddDays(daysFromNow);
        }
        public MedicalAppointment(string patientName, DateTime date)
        {
            _patientName = patientName;
            _date = date;
        }
        public void Reschedule(DateTime date)
        {
            _date = date;
            var printer = new MedicalAppointmentPrinter();
            printer.Print(this);
        }

        public void Reschedule(int month, int day)
        {
            _date = new DateTime(_date.Year, month, day);
        }

        public DateTime GetDate() => _date;
    }
}
