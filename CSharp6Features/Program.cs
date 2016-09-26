namespace CSharp6Features
{
    using System;
    using System.Collections.Generic;
    using static System.Console; // new static using initialisers.

    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();

            WriteLine(user.Id);

            // new dictionary initialiser features.
            Dictionary<string, User> userCollection = new Dictionary<string, User>()
            {
                ["admin"] = new User(),
                ["user2"] = new User()
            };

            // testing out conditional access.
            var newStudent = new Student();

            WriteLine(newStudent.GetExams(null));

            try
            {
                newStudent.HasExams(null);
            }
            catch (Exception ex) when (ex.InnerException == null)
            {
                WriteLine("An Exception occured and no inner exception was found.");
            }

            Read();
        }
    }

    public class User
    {
        // auto property initialisers.
        public Guid Id { get; } = Guid.NewGuid();
    }

    public class Student : User
    {
        public Student()
            : base()
        {

        }

        public string GetExams(ExamMarks exam)
        {
            // new conditional access features.
            //var examTopic = exam?.Topic;

            //return !string.IsNullOrWhiteSpace(examTopic) ? examTopic : "No Topic Found";

            return exam?.Topic ?? "No Topic Found"; // using coalescence
        }

        public bool HasExams(ExamMarks exam)
        {
            if (string.IsNullOrWhiteSpace(exam?.Topic))
            {
                throw new InvalidOperationException();
            }

            return true;
        }
    }

    public class ExamMarks
    {
        public string Topic { get; set; }
        public int Score { get; set; }
    }
}
