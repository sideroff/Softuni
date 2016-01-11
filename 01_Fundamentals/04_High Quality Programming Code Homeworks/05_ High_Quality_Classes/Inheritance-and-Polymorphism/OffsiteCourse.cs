namespace InheritanceAndPolymorphism
{
    using InheritanceAndPolymorphism.Models;
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name)
            :base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            :base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            :base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            string result = $"{this.GetType().Name} {{ {base.ToString()} Town = {this.Town} }}";

            return result;
        }
    }
}
