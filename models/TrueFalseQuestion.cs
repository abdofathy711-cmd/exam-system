namespace exam_system.models
{
    internal class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string header, string body, int marks, bool correctAnswer)
            : base(header, body, marks)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void DisplayQuestion()
        {
            PrintQuestion("True or False");
        }

        public override string GetCorrectAnswerText()
        {
            return CorrectAnswer ? "True" : "False";
        }
    }
}
