namespace Overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    // Method overload. Need identifiable separation of either type or number of args
    public class MedicalAppointment
    {
        private string _patientName;
        private DateTime _date;

        public MedicalAppointment(string patientName) :
            this(patientName, 7)
        {
        }
        public MedicalAppointment(string patientName, int daysFromNow)
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
        }

        public void Reschedule(int month, int day)
        {
            _date = new DateTime(_date.Year, month, day);
        }
    }
}
