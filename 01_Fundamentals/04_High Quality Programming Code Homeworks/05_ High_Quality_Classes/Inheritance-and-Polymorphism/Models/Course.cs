namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private ICollection<string> students;

        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = new List<string>();
        }

        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.students = students;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IEnumerable<string> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(string student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null");
            }
            if (student == string.Empty)
            {
                throw new ArgumentNullException("Student cannot be empty");
            }
            this.students.Add(student);
        }

        private string GetStudentsAsString()
        {
            if (this.students.Count == 0)
            {
                return "{ }";
            }
            return "{ " + string.Join(", ", this.Students) + " }";
        }
        
        public override string ToString()
        {
            string result = $"Name = {this.Name}; Teacher = {this.TeacherName}; Students = {this.GetStudentsAsString()}";
            
            return result;
        }
    }
}