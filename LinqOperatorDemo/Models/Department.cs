namespace LinqOperatorDemo.Models
{
    public class Department
    {
        public string Name { get; set; }
        public string Manager { get; set; }

        public override string ToString()
        {
            return $"Department: {Name}, Manager: {Manager}";
        }
    }


}
