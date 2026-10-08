using exam_system.models;
using System;
using System.Collections.Generic;

namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Subject + Students
            Subject subject = new Subject(1, "C# OOP");
            Student s1 = new Student(1, "Ahmed");
            Student s2 = new Student(2, "Sara");
            subject.AddStudent(s1);
            subject.AddStudent(s2);

            // 2. Questions (each QuestionList logs to its own file)
            QuestionList practiceQuestions = new QuestionList("practice_questions.txt");
            QuestionList finalQuestions = new QuestionList("final_questions.txt");

            TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# supports multiple class inheritance.", 5, false);
            q1.Answers.Add(new Answer(1, "True"));
            q1.Answers.Add(new Answer(2, "False"));

            ChooseOneQuestion q2 = new ChooseOneQuestion("Q2", "Which keyword prevents inheritance?", 10, 3);
            q2.Answers.Add(new Answer(1, "abstract"));
            q2.Answers.Add(new Answer(2, "virtual"));
            q2.Answers.Add(new Answer(3, "sealed"));

            ChooseAllQuestion q3 = new ChooseAllQuestion("Q3", "Which are OOP pillars?", 10, new List<int> { 1, 2, 4 });
            q3.Answers.Add(new Answer(1, "Inheritance"));
            q3.Answers.Add(new Answer(2, "Polymorphism"));
            q3.Answers.Add(new Answer(3, "Compilation"));
            q3.Answers.Add(new Answer(4, "Encapsulation"));

            practiceQuestions.Add(q1);
            practiceQuestions.Add(q2);
            practiceQuestions.Add(q3);

            finalQuestions.Add(q1);
            finalQuestions.Add(q2);
            finalQuestions.Add(q3);

            // 3. Two exam objects: one Practice, one Final
            PracticeExam practiceExam = new PracticeExam(30, subject, practiceQuestions);
            FinalExam finalExam = new FinalExam(60, subject, finalQuestions);

            // 4. Subscribe every student of the subject to both exams' event
            foreach (Student st in subject.Students)
            {
                practiceExam.ExamStarted += st.OnExamStarted;
                finalExam.ExamStarted += st.OnExamStarted;
            }

            // 5. User selects the exam type
            Exam selectedExam = null;
            while (selectedExam == null)
            {
                Console.WriteLine("=== Examination System ===");
                Console.WriteLine("1) Practice Exam");
                Console.WriteLine("2) Final Exam");
                Console.Write("Choose exam type: ");
                string choice = Console.ReadLine();

                if (choice == "1") selectedExam = practiceExam;
                else if (choice == "2") selectedExam = finalExam;
                else Console.WriteLine("Invalid choice, try again.\n");
            }

            // 6. Start the exam (setting Mode = Starting notifies all students)
            Console.WriteLine();
            selectedExam.Mode = ExamMode.Starting;

            // 7. Show the exam (polymorphic call)
            Console.WriteLine();
            selectedExam.ShowExam();

            // 8. Finish
            selectedExam.Mode = ExamMode.Finished;
            Console.WriteLine("\nExam finished.");
        }
    }
}
