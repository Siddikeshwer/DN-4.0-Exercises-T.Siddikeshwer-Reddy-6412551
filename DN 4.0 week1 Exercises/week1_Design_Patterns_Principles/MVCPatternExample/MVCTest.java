using System;

// Student.cs
public class Student
{
    private string _name;
    private string _id;
    private string _grade;

    public Student(string name, string id, string grade)
    {
        _name = name;
        _id = id;
        _grade = grade;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Id
    {
        get => _id;
        set => _id = value;
    }

    public string Grade
    {
        get => _grade;
        set => _grade = value;
    }
}

// StudentView.cs
public class StudentView
{
    public void DisplayStudentDetails(string studentName, string studentId, string studentGrade)
    {
        Console.WriteLine("Student: ");
        Console.WriteLine($"Name: {studentName}");
        Console.WriteLine($"ID: {studentId}");
        Console.WriteLine($"Grade: {studentGrade}");
    }
}

// StudentController.cs
public class StudentController
{
    private readonly Student _model;
    private readonly StudentView _view;

    public StudentController(Student model, StudentView view)
    {
        _model = model ?? throw new ArgumentNullException(nameof(model));
        _view = view ?? throw new ArgumentNullException(nameof(view));
    }

    public void SetStudentName(string name)
    {
        _model.Name = name;
    }

    public string GetStudentName()
    {
        return _model.Name;
    }

    public void SetStudentId(string id)
    {
        _model.Id = id;
    }

    public string GetStudentId()
    {
        return _model.Id;
    }

    public void SetStudentGrade(string grade)
    {
        _model.Grade = grade;
    }

    public string GetStudentGrade()
    {
        return _model.Grade;
    }

    public void UpdateView()
    {
        _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        Student model = new Student("John Doe", "12345", "A");
        StudentView view = new StudentView();
        StudentController controller = new StudentController(model, view);

        controller.UpdateView();

        controller.SetStudentName("Jane Smith");
        controller.SetStudentGrade("A+");
        controller.UpdateView();
    }
}
