namespace TestLINQ;


public class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public List<int> scroes { get; set; }

    public Student(string name, int id, List<int> scroes)
    {
        Name = name;
        ID = id;
        this.scroes = scroes;
    }
}