using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public enum ExamMode
{
    Starting,
    Queued,
    Finished
}

public class Subject : ICloneable, IComparable<Subject>
{
    public string SubjectName { get; set; }
    public string SubjectCode { get; set; }
    public int CreditHours { get; set; }

    public Subject() : this("no name", "000", 0)
    {
    }

    public Subject(string name) : this(name, "000", 0)
    {
    }

    public Subject(string name, string code) : this(name, code, 0)
    {
    }

    public Subject(string name, string code, int hours)
    {
        SubjectName = name;
        SubjectCode = code;
        CreditHours = hours;
    }

    public object Clone()
    {
        return new Subject(SubjectName, SubjectCode, CreditHours);
    }

    public int CompareTo(Subject other)
    {
        return string.Compare(SubjectName, other.SubjectName);
    }

    public override string ToString()
    {
        return SubjectName + " (" + SubjectCode + ")";
    }

    public override bool Equals(object obj)
    {
        Subject s = obj as Subject;
        if (s == null) return false;
        return SubjectCode == s.SubjectCode;
    }

    public override int GetHashCode()
    {
        return SubjectCode.GetHashCode();
    }
}

public class Answer : ICloneable, IComparable<Answer>
{
    public string AnswerText { get; set; }
    public bool IsCorrect { get; set; }

    public Answer() : this("", false)
    {
    }

    public Answer(string text) : this(text, false)
    {
    }

    public Answer(string text, bool correct)
    {
        AnswerText = text;
        IsCorrect = correct;
    }

    public object Clone()
    {
        return new Answer(AnswerText, IsCorrect);
    }

    public int CompareTo(Answer other)
    {
        return string.Compare(AnswerText, other.AnswerText);
    }

    public override string ToString()
    {
        if (IsCorrect)
            return AnswerText + " *correct*";
        else
            return AnswerText;
    }

    public override bool Equals(object obj)
    {
        Answer a = obj as Answer;
        if (a == null) return false;
        return AnswerText == a.AnswerText && IsCorrect == a.IsCorrect;
    }

    public override int GetHashCode()
    {
        return AnswerText.GetHashCode();
    }
}

public class AnswerList : List<Answer>, ICloneable
{
    public AnswerList()
    {
    }

    public AnswerList(IEnumerable<Answer> list) : base(list)
    {
    }

    public List<Answer> GetCorrectAnswers()
    {
        List<Answer> correctOnes = new List<Answer>();
        foreach (Answer a in this)
        {
            if (a.IsCorrect == true)
                correctOnes.Add(a);
        }
        return correctOnes;
    }

    public object Clone()
    {
        AnswerList newList = new AnswerList();
        foreach (Answer a in this)
        {
            newList.Add((Answer)a.Clone());
        }
        return newList;
    }

    public override string ToString()
    {
        string result = "";
        int i = 1;
        foreach (Answer a in this)
        {
            result += i + ". " + a.AnswerText + "\n";
            i++;
        }
        return result;
    }
}

public abstract class Question : ICloneable, IComparable<Question>
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Marks { get; set; }

    public AnswerList Answers { get; set; }

    protected Question() : this("", "", 1)
    {
    }

    protected Question(string body) : this("", body, 1)
    {
    }

    protected Question(string header, string body) : this(header, body, 1)
    {
    }

    protected Question(string header, string body, int marks)
    {
        Header = header;
        Body = body;
        Marks = marks;
        Answers = new AnswerList();
    }

    public abstract void Display(bool showAnswer);

    public abstract object Clone();

    public int CompareTo(Question other)
    {
        return Marks.CompareTo(other.Marks);
    }

    public override string ToString()
    {
        return Header + " - " + Body + " [" + Marks + " marks]";
    }

    public override bool Equals(object obj)
    {
        Question q = obj as Question;
        if (q == null) return false;
        return Body == q.Body && Header == q.Header;
    }

    public override int GetHashCode()
    {
        return (Header + Body).GetHashCode();
    }
}

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion() : base()
    {
    }

    public TrueFalseQuestion(string body) : base(body)
    {
    }

    public TrueFalseQuestion(string header, string body) : base(header, body)
    {
    }

    public TrueFalseQuestion(string header, string body, int marks) : base(header, body, marks)
    {
        Answers.Add(new Answer("True", false));
        Answers.Add(new Answer("False", false));
    }

    public override void Display(bool showAnswer)
    {
        Console.WriteLine("\n" + Header + ") " + Body + "  (" + Marks + " marks)");
        Console.WriteLine("   1- True");
        Console.WriteLine("   2- False");

        if (showAnswer)
        {
            List<Answer> correct = Answers.GetCorrectAnswers();
            if (correct.Count > 0)
                Console.WriteLine("   >> Answer: " + correct[0].AnswerText);
        }
    }

    public override object Clone()
    {
        TrueFalseQuestion copy = new TrueFalseQuestion(Header, Body, Marks);
        copy.Answers = (AnswerList)Answers.Clone();
        return copy;
    }
}

public class ChooseOneQuestion : Question
{
    public ChooseOneQuestion() : base()
    {
    }

    public ChooseOneQuestion(string body) : base(body)
    {
    }

    public ChooseOneQuestion(string header, string body) : base(header, body)
    {
    }

    public ChooseOneQuestion(string header, string body, int marks) : base(header, body, marks)
    {
    }

    public override void Display(bool showAnswer)
    {
        Console.WriteLine("\n" + Header + ") " + Body + "  (" + Marks + " marks)");

        char letter = 'a';
        foreach (Answer a in Answers)
        {
            Console.WriteLine("   " + letter + "- " + a.AnswerText);
            letter++;
        }

        if (showAnswer)
        {
            List<Answer> correct = Answers.GetCorrectAnswers();
            if (correct.Count > 0)
                Console.WriteLine("   >> Answer: " + correct[0].AnswerText);
        }
    }

    public override object Clone()
    {
        ChooseOneQuestion copy = new ChooseOneQuestion(Header, Body, Marks);
        copy.Answers = (AnswerList)Answers.Clone();
        return copy;
    }
}

public class ChooseAllQuestion : Question
{
    public ChooseAllQuestion() : base()
    {
    }

    public ChooseAllQuestion(string body) : base(body)
    {
    }

    public ChooseAllQuestion(string header, string body) : base(header, body)
    {
    }

    public ChooseAllQuestion(string header, string body, int marks) : base(header, body, marks)
    {
    }

    public override void Display(bool showAnswer)
    {
        Console.WriteLine("\n" + Header + ") " + Body + "  (" + Marks + " marks)  [choose all correct answers]");

        char letter = 'a';
        foreach (Answer a in Answers)
        {
            Console.WriteLine("   " + letter + "- " + a.AnswerText);
            letter++;
        }

        if (showAnswer)
        {
            List<Answer> correct = Answers.GetCorrectAnswers();
            Console.Write("   >> Answers: ");
            foreach (Answer a in correct)
                Console.Write(a.AnswerText + "  ");
            Console.WriteLine();
        }
    }

    public override object Clone()
    {
        ChooseAllQuestion copy = new ChooseAllQuestion(Header, Body, Marks);
        copy.Answers = (AnswerList)Answers.Clone();
        return copy;
    }
}

public class QuestionList : List<Question>, ICloneable
{
    string logFile;

    public QuestionList() : this("log.txt")
    {
    }

    public QuestionList(string fileName)
    {
        logFile = fileName;
    }

    public new void Add(Question q)
    {
        base.Add(q);

        try
        {
            TextWriter writer = new StreamWriter(logFile, true); 
            writer.WriteLine("----------------------------");
            writer.WriteLine("Type: " + q.GetType().Name);
            writer.WriteLine("Header: " + q.Header);
            writer.WriteLine("Body: " + q.Body);
            writer.WriteLine("Marks: " + q.Marks);
            writer.WriteLine("Answers:");
            foreach (Answer a in q.Answers)
            {
                writer.WriteLine("  - " + a.AnswerText + " | correct: " + a.IsCorrect);
            }
            writer.WriteLine("Date: " + DateTime.Now);
            writer.Close(); 
        }
        catch (Exception e)
        {
            Console.WriteLine("could not write to file: " + e.Message);
        }
    }

    public string ReadLog()
    {
        try
        {
            TextReader reader = new StreamReader(logFile);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
        catch
        {
            return "file not found";
        }
    }

    public object Clone()
    {
        QuestionList newList = new QuestionList(logFile);
        foreach (Question q in this)
        {
            newList.Add((Question)q.Clone());
        }
        return newList;
    }

    public override string ToString()
    {
        return "QuestionList has " + Count + " questions";
    }
}

public abstract class Exam<TQuestion> : ICloneable, IComparable<Exam<TQuestion>> where TQuestion : Question
{
    public int Time { get; set; } 
    public ExamMode Mode { get; set; }
    public Subject ExamSubject { get; set; }
    public QuestionList Questions { get; set; }

    public Dictionary<TQuestion, Answer> QuestionAnswer { get; set; }

    public int NumberOfQuestions
    {
        get { return Questions.Count; }
    }

    protected Exam() : this(new Subject(), 60)
    {
    }

    protected Exam(Subject s) : this(s, 60)
    {
    }

    protected Exam(Subject s, int time)
    {
        ExamSubject = s;
        Time = time;
        Mode = ExamMode.Starting;
        Questions = new QuestionList("exam_" + s.SubjectCode + ".txt");
        QuestionAnswer = new Dictionary<TQuestion, Answer>();
    }

    public abstract void ShowExam();

    public object Clone()
    {
        Exam<TQuestion> copy = (Exam<TQuestion>)this.MemberwiseClone();
        copy.ExamSubject = (Subject)ExamSubject.Clone();
        copy.Questions = (QuestionList)Questions.Clone();
        copy.QuestionAnswer = new Dictionary<TQuestion, Answer>(QuestionAnswer);
        return copy;
    }

    public int CompareTo(Exam<TQuestion> other)
    {
        return Time.CompareTo(other.Time);
    }

    public override string ToString()
    {
        return GetType().Name + " | " + ExamSubject + " | time: " + Time + " min | mode: " + Mode + " | questions: " + NumberOfQuestions;
    }

    public override bool Equals(object obj)
    {
        Exam<TQuestion> e = obj as Exam<TQuestion>;
        if (e == null) return false;
        return ExamSubject.Equals(e.ExamSubject) && GetType() == e.GetType();
    }

    public override int GetHashCode()
    {
        return (GetType().Name + ExamSubject.SubjectCode).GetHashCode();
    }
}

public class PracticeExam : Exam<Question>
{
    public PracticeExam() : base()
    {
    }

    public PracticeExam(Subject s) : base(s)
    {
    }

    public PracticeExam(Subject s, int time) : base(s, time)
    {
    }

    public override void ShowExam()
    {
        Mode = ExamMode.Starting;
        Console.WriteLine("\n============================");
        Console.WriteLine("Practice Exam");
        Console.WriteLine("Subject: " + ExamSubject);
        Console.WriteLine("Time: " + Time + " minutes");
        Console.WriteLine("============================");

        Mode = ExamMode.Queued;

        int num = 1;
        foreach (Question q in Questions)
        {
            Console.Write("Question " + num + ": ");
            num++;
            q.Display(false); 

            Console.Write("\nYour answer: ");
            string ans = Console.ReadLine(); 

            q.Display(true);
            Console.WriteLine();
        }

        Mode = ExamMode.Finished;
        Console.WriteLine("============================");
        Console.WriteLine("Practice Exam Done!");
        Console.WriteLine("============================");
    }

    public override string ToString()
    {
        return "Practice - " + base.ToString();
    }
}

public class FinalExam : Exam<Question>
{
    public FinalExam() : base()
    {
    }

    public FinalExam(Subject s) : base(s)
    {
    }

    public FinalExam(Subject s, int time) : base(s, time)
    {
    }

    public override void ShowExam()
    {
        Mode = ExamMode.Starting;
        Console.WriteLine("\n============================");
        Console.WriteLine("Final Exam");
        Console.WriteLine("Subject: " + ExamSubject);
        Console.WriteLine("Time: " + Time + " minutes");
        Console.WriteLine("Good Luck!!");
        Console.WriteLine("============================");

        Mode = ExamMode.Queued;

        int num = 1;
        foreach (Question q in Questions)
        {
            Console.Write("Question " + num + ": ");
            num++;
            q.Display(false); 

            Console.Write("\nYour answer: ");
            Console.ReadLine();
        }

        Mode = ExamMode.Finished;
        Console.WriteLine("============================");
        Console.WriteLine("Exam Finished.");
        Console.WriteLine("============================");
    }

    public override string ToString()
    {
        return "Final - " + base.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Subject sub = new Subject("Object Oriented Programming", "CS301", 3);

        PracticeExam pExam = new PracticeExam(sub, 30);

        TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# supports multiple inheritance", 2);
        q1.Answers[0].IsCorrect = false;
        q1.Answers[1].IsCorrect = true; 

        ChooseOneQuestion q2 = new ChooseOneQuestion("Q2", "What is used to inherit in C#?", 3);
        q2.Answers.Add(new Answer("extends", false));
        q2.Answers.Add(new Answer(":", true));
        q2.Answers.Add(new Answer("inherits", false));
        q2.Answers.Add(new Answer("implements", false));

        pExam.Questions.Add(q1);
        pExam.Questions.Add(q2);

        FinalExam fExam = new FinalExam(sub, 60);

        ChooseAllQuestion q3 = new ChooseAllQuestion("Q1", "Which are pillars of OOP?", 4);
        q3.Answers.Add(new Answer("Encapsulation", true));
        q3.Answers.Add(new Answer("Compilation", false));
        q3.Answers.Add(new Answer("Inheritance", true));
        q3.Answers.Add(new Answer("Polymorphism", true));
        q3.Answers.Add(new Answer("Abstraction", true));

        TrueFalseQuestion q4 = new TrueFalseQuestion("Q2", "Java and C# are the same language", 2);
        q4.Answers[0].IsCorrect = false;
        q4.Answers[1].IsCorrect = true; 

        fExam.Questions.Add(q3);
        fExam.Questions.Add(q4);

        Console.WriteLine("Select Exam Type:");
        Console.WriteLine("1- Practice Exam");
        Console.WriteLine("2- Final Exam");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            pExam.ShowExam();
        }
        else if (choice == "2")
        {
            fExam.ShowExam();
        }
        else
        {
            Console.WriteLine("wrong input");
        }

        PracticeExam copy = (PracticeExam)pExam.Clone();
        Console.WriteLine("\ncloned exam: " + copy);

        int result = pExam.CompareTo(fExam);
        if (result < 0)
            Console.WriteLine("practice exam is shorter");
        else if (result > 0)
            Console.WriteLine("practice exam is longer");
        else
            Console.WriteLine("same duration");

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}