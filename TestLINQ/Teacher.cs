namespace TestLINQ;

public class Teacher
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }

    public Teacher(string name, int id, decimal salary)
    {
        Name = name;
        ID = id;
        Salary = salary;
    }
}