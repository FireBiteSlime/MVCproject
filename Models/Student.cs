using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
        public override string ToString() => $"Студент: {Name} {LastName}, Группа: {Group }";
        
        public Student(string Name, string LastName, int Group)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Group = Group;
        }
}}