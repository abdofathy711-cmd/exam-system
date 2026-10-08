using System.Collections.Generic;
using System.IO;

namespace exam_system.models
{
    internal class QuestionList : List<Question>
    {
        private string FileName { get; }

        public QuestionList(string fileName)
        {
            FileName = fileName;
            File.WriteAllText(FileName, string.Empty); // fresh log file for this list
        }

        // List<T>.Add is not virtual, so we hide it with "new" and keep the default behavior
        public new void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter writer = new StreamWriter(FileName, append: true))
            {
                writer.WriteLine(question.ToString());
            }
        }
    }
}
