using ProjektiCursit_Naser_.Classes;
using System.Reflection.Metadata.Ecma335;

namespace ProjektiCursitNaser;

public class Program
{
	public static int IdOfStudents = 1;
	public static string projectTitle = "\t\t\t\t\t|====|Student Managemant System|====|\n\t\t\t\t\t|___________________________________|\n\n";
	public static string goBackPrompt = "\nPress anything to go back to the main menu";

	public static void printText(string text, bool goBack = false, bool writeLine = true)
	{
		if(goBack)
		{
			text += goBackPrompt;
		}

		if (writeLine)
		{
			Console.WriteLine(text);
			return;
		}

		Console.Write(text);
		
	}

	public static void printTitle(string titleText)
	{
		Console.WriteLine("\t\t-====|" + titleText + "|====-\n");
	}

	public static bool CheckStudentId(List<StudentClass> students, int id)
	{
		if (students.FirstOrDefault(s => s.Id == id) != null) return true;
		
		printText("Student not found." + goBackPrompt);
		Console.ReadKey();
		return false;
	}

	
	public static void StudentMenu()
	{
		printText(projectTitle);
		printText("Options:\n");
		printText("1. Add Student");
		printText("2. List of students");
		printText("3. Assign Grade to Student");
		printText("4. Student Grades");
		printText("5. Student GPA");
		printText("6. Remove Student");
		printText("7. Exit\n");
	}

	public static void RegisterStudent(List<StudentClass> students)
	{
		printTitle("Add  Student");
		printText("Enter Student Details: Name, Surname, Age");

		int Id = IdOfStudents++;

		printText("Name: ", false,  false);
		string? Name = Console.ReadLine();

		if (Name.Length == 0 || Name == null)
		{
			printText("Invalid Name");
			printText(goBackPrompt);
			Console.ReadKey();
			return;
		}


		printText("Surname: ", false, false);
		string? Surname = Console.ReadLine();

		if (Surname.Length == 0 || Surname == null ) {
			printText("Invalid Surname");
			printText(goBackPrompt);
			Console.ReadKey();
			return;
		}


		printText("Age: ", false, false);
		int Age;
		try
		{
			Age = Convert.ToInt32(Console.ReadLine());
		}
		catch (FormatException)
		{
			printText("Age must be a number!", true);
			
			Console.ReadKey();
			return;
		}



		students.Add(new StudentClass { Id = Id, Name = Name, Surname = Surname, Age = Age, });
		printText("Student Registerd Successfully " + goBackPrompt);
		Console.ReadKey(); 
	}

    public static void ListStudents(List<StudentClass> students)
	{
		printTitle("List of Students");
		if (students.Count != 0)
		{
			foreach (var student in students)
			{
				printText($"{student.Id}. Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}");
			}
			printText("",true);
		}
		else
		{
			printText("No Students Registered");
			printText(goBackPrompt);
		};

	 Console.ReadKey();
	}

	public static void AddGradeToStudent(List<StudentClass> students)
	{
		printTitle("Add Grade to Student");
		printText("Please enter the student's ID, then Subject and Grade.");

		Console.Write("ID: ");
		int id;
		try { 
		      id = Convert.ToInt32(Console.ReadLine());
            }
		catch (FormatException)
		{
			printText("ID must be a number!", true);
			
			Console.ReadKey();
			return;
		}
		if (!CheckStudentId(students, id)) return;

		Console.Write("Subject: ");
		string? subject = Console.ReadLine();
		 
		if (subject.Trim() == "") {
			printText("Invalid Subject", false);
			printText(goBackPrompt);
			Console.ReadKey();
			return;
		}
		

		Console.Write("Grade: ");

		int grade;
		try
		{
		   grade = Convert.ToInt32(Console.ReadLine());
		}
		catch (FormatException)
		{
			printText("Grade must be a number!", true);
			
			Console.ReadKey();
			return;
		}

		if (grade < 1 || grade > 5)
		{
			printText("Invalid Grade. Please enter a grade between 1 and 5.");
			Console.ReadKey();
			return;
		}

		var student = students.Find(s => s.Id == id);

		student.Grades.Add(new Grades { Subject = subject, Grade = grade });

		printText("Student Graded Successfully " + goBackPrompt);
		Console.ReadKey();
	}

	public static void ShowGradeOfStudent(List<StudentClass> students)
	{
		printTitle("Student Grandes");
		Console.Write("Please enter the students Id:");
		int id;
		try
		{
			 id = Convert.ToInt32(Console.ReadLine());
		}
		catch (FormatException)
		{
			printText("ID must be a number!", true);
			Console.ReadKey();
			return;
		}
		if (!CheckStudentId(students, id)) return;
		foreach (var student in students)
		{
			
			if (student.Id != id) continue;


			if (student.Grades == null || student.Grades.Count == 0)
			{
				printText("This student has no grades.");
				printText(goBackPrompt);
				Console.ReadKey();
				return;
			}

			
			else
			{

				printText(student.Name + "s Grades");

				foreach (var gr in student.Grades)
				{
					printText($"Subject: {gr.Subject}, Grade: {gr.Grade}");
				}
				
			}

			printText(goBackPrompt);
			Console.ReadKey();
		}
	}

	public static void GpaOfStudent(List<StudentClass> students)
	{
		printTitle("Student GPA");
		Console.Write("Please enter the student's ID: ");
		int id;
		try
		{
		 id = Convert.ToInt32(Console.ReadLine());
		}
		catch (FormatException)
		{
			printText("Age must be a number!", true);
			Console.ReadKey();
			return;
		}

		if (CheckStudentId(students, id))
		{
			var student = students.Find(s => s.Id == id);
			
			if (student.Grades.Count == 0)
			{
				printText("This student has no grades." + goBackPrompt);
				printText(goBackPrompt);
				Console.ReadKey();
				return;
			}

			float sum = 0.0f; 
			foreach (var grade in student.Grades)
			{

				sum += grade.Grade;

			}
			printText($"{student.Name}'s GPA Is: {sum / student.Grades.Count}");
			printText(goBackPrompt);
			Console.ReadKey();
		}

	}


	public static void UnRegisterStudent(List<StudentClass> students)
	{
		printTitle("Remove Student");

		printText("Enter Student ID to Unregister:",false,false);
		int id;
		try
		{
			id = Convert.ToInt32(Console.ReadLine());
		}
		catch (FormatException)
		{
			printText("Id must be a number!", true);
			Console.ReadKey();
			return;
		}

		var student = students.Find(s => s.Id == id);

		
		if (student == null)
		{
			printText("\nStudent not found.");
			printText(goBackPrompt);
			Console.ReadKey();
			return;
		}

		students.Remove(student);

		printText($"Removed {student.Name} {student.Surname} sucessfully.", true);
		
		Console.ReadKey();
	}

	public static void Main()
	{
		var Students = new List<StudentClass>();

		var Choice = "";

		while (Choice != "7")
		{
			Console.Clear();
			StudentMenu();
			Choice = Console.ReadLine();
			switch (Choice)
			{
				case "1":
					RegisterStudent(Students);
					break;
                case "2":
					ListStudents(Students);
					break;

				case "3":
					AddGradeToStudent(Students);
					break;

                case "4":
					ShowGradeOfStudent(Students);
					break;

                case "5":
					GpaOfStudent(Students);
					break;

				case "6":
					UnRegisterStudent(Students);	
					break;

				case "7":
					printText("Exiting the program. Goodbye!");
					break;

				default:
					printText("Invalid Option pleas pick one of the options above" +  goBackPrompt);
					Console.ReadKey();
					break;
			}
		}
	}
}