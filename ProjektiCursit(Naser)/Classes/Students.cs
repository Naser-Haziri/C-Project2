using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektiCursit_Naser_.Classes
{
	public class Grades
	{
		public string? Subject { get; set; }
		public int Grade { get; set; }

	}
	public class StudentClass
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public int Age { get; set; }
		public int Year { get; set; }

		public List<Grades> Grades { get; set; } = [];
	}
}
