namespace MyCSharpProject
{
    public class Student : Person, KPI
    {
        public string Major { get; set; }

        public void kpi()
        {
            Console.WriteLine($"{Name} with major {Major} is meeting the KPI.");
        }
    }
}