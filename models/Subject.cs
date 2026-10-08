using System.Collections.Generic;

namespace exam_system.models
{
    internal class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<Student> Students { get; set; }

        public Subject(int subjectId, string subjectName)
            : this(subjectId, subjectName, new List<Student>())
        {
        }

        public Subject(int subjectId, string subjectName, List<Student> students)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Students = students ?? new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public override string ToString()
        {
            return $"SubjectId: {SubjectId}, SubjectName: {SubjectName}, Students: {string.Join(", ", Students)}";
        }
    }
}
