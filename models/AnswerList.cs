using System.Collections.Generic;

namespace exam_system.models
{
    internal class AnswerList : List<Answer>
    {
        public override string ToString()
        {
            return "[" + string.Join(" | ", this) + "]";
        }
    }
}
