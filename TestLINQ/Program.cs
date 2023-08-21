// See https://aka.ms/new-console-template for more information

using System.Collections;

namespace TestLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            
            SeedData(students, teachers);
            

            IEnumerable<Student> notLessThan90 =
                from student in students
                where (student.scroes[0] >= 90)
                select student;

            
            Console.WriteLine("첫번째 시험에서 90점 이상 맞은 학생들");
            foreach (Student student in notLessThan90)
            {
                Console.WriteLine("{0}, {1}", student.Name, student.scroes[0]);
            }


            IEnumerable<Student> descendingByID = 
                from student in students
                where (student.Name[0].ToString() == "이")
                orderby student.ID descending
                select student;

            Console.WriteLine("학생들중 이씨인 사람들 뽑아 ID를 내림차순으로 정렬");
            foreach (Student student in descendingByID)
            {
                Console.WriteLine("{0}, {1}", student.Name, student.ID);
            }
            
            Console.WriteLine("학생들의 성으로 그룹화");

            IEnumerable<IGrouping<string, Student>> groupByFirstName=
                from student in students
                group student by student.Name[0].ToString();

            foreach (IGrouping<string, Student> group in groupByFirstName)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0}, {1}", student.Name, student.ID);
                }
            }
            
            Console.WriteLine("학생들의 성으로 내림차순으로 정렬 및 그룹화");

            IEnumerable<IGrouping<string, Student>> groupByFirstNameDescending=
                from student in students 
                orderby student.Name[0].ToString() descending
                group student by student.Name[0].ToString();

            foreach (IGrouping<string, Student> group in groupByFirstNameDescending)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0}, {1}", student.Name, student.ID);
                }
            }
            
            
            var groupByFirstNameDescending2=
                from student in students 
                orderby student.Name[0].ToString() descending
                group student by student.Name[0].ToString();

            foreach (var group in groupByFirstNameDescending2)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0}, {1}", student.Name, student.ID);
                }
            }
            
            
            
            // 메서드 구문 이용
            
            Console.WriteLine("메서드 구문 이용해서");
            IEnumerable<Student> notLessThan90Method = students.Where(student => student.scroes[0] >= 90);
            
            Console.WriteLine("첫번째 시험에서 90점 이상 맞은 학생들");
            foreach (Student student in notLessThan90Method)
            {
                Console.WriteLine("{0}, {1}", student.Name, student.scroes[0]);
            }


            IEnumerable<Student> descendingByIDMethod =

                students.Where(student => student.Name[0].ToString() == "이").OrderByDescending(student => student.ID);
                
                // from student in students
                // where (student.Name[0].ToString() == "이")
                // orderby student.ID descending
                // select student;
            
            Console.WriteLine("학생들중 이씨인 사람들 뽑아 ID를 내림차순으로 정렬");
            foreach (Student student in descendingByIDMethod)
            {
                Console.WriteLine("{0}, {1}", student.Name, student.ID);
            }
            
            
            
            Console.WriteLine("학생들의 성으로 그룹화");

            IEnumerable<IGrouping<string, Student>> groupByFirstNameMethod =
                students.GroupBy(student => student.Name[0].ToString());
            
            
            foreach (IGrouping<string, Student> group in groupByFirstNameMethod)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0}, {1}", student.Name, student.ID);
                }
            }
            
            Console.WriteLine("학생들의 성으로 내림차순으로 정렬 및 그룹화");

            IEnumerable<IGrouping<string, Student>> groupByFirstNameDescendingMethod =

                students.OrderByDescending(student => student.Name[0].ToString())
                    .GroupBy(student => student.Name[0].ToString());

            foreach (IGrouping<string, Student> group in groupByFirstNameDescendingMethod)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0}, {1}", student.Name, student.ID);
                }
            }

            Console.WriteLine("학생 리스트와 선생님 리스트를 합쳐서 홀수인 ID");

            var oddIDInTeacherAndStudent = students.Where(student => student.ID % 2 == 0).Select(x => x.ID)
                .Concat(teachers.Where(teacher => teacher.ID % 2 == 0).Select(x => x.ID));

            foreach (var id in oddIDInTeacherAndStudent)
            {
                Console.WriteLine(id);
            }
            
            var oddIDCount = students.Where(student => student.ID % 2 == 0).Select(x => x.ID)
                .Concat(teachers.Where(teacher => teacher.ID % 2 == 0).Select(x => x.ID)).Count();
            
            Console.WriteLine(oddIDCount);

            var oddIDList = students.Where(student => student.ID % 2 == 0).Select(x => x.ID)
                .Concat(teachers.Where(teacher => teacher.ID % 2 == 0).Select(x => x.ID)).ToList();
            
            Console.WriteLine(String.Join(" ", oddIDList));


        }

        public static void SeedData(List<Student> students, List<Teacher> teachers)
        {
            List<Student> _students = new List<Student>()
            {
                new Student("김수로", 0, new() { 90, 95,70,50, 87}),
                new Student("박혁거세", 1, new() { 80, 45,95,80, 75}),
                new Student("이은혜", 2, new() { 83, 63,89,93, 63}),
                new Student("이근왕", 3, new() { 55, 77,77,31, 90}),
                new Student("선우현", 4, new() { 100, 15,25,36, 57}),
            };

            foreach (var s in _students)
            {
                students.Add(s);
            }
            
            List<Teacher> _teachers = new List<Teacher>()
            {
                new Teacher("김철수", 5, 10000),
                new Teacher("이진혜", 6, 20000),
                new Teacher("김왕심", 7, 30000),
                new Teacher("박수빈", 8, 40000),
                new Teacher("손을왕", 9, 50000),
            };
            
            foreach (var t in _teachers)
            {
                teachers.Add(t);
            }
        }
    }
}