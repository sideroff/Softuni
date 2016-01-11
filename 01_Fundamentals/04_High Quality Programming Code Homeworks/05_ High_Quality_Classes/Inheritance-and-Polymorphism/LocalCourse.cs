namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using InheritanceAndPolymorphism.Models;

    public class LocalCourse : Course
    {
        public LocalCourse(string name)
            :base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            :base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public string Lab { get; set; }
        
        public override string ToString()
        {
            string result = $"{this.GetType().Name} {{ {base.ToString()} Lab = {this.Lab} }}";

            return result;
        }


    }
}
