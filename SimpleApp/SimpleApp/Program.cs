using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace SimpleApp
{

	public delegate string WriteLogDelegate(string logMessage);

	class Program
	{
		// ref marcheaza referinta, evident
		// out marcheaza necesitatea de asignare a variabilei prefixate de out
		//method return type doesn't count, overloading means different headers

		int count1 = 0;
		int count2 = 0;

		public void father()
		{
			Console.WriteLine("Father function!");
			
		}

		string anyName(string message)
        {
			count1 += 1;
			return message;
			
        }

		string someName(string message)
        {
			count2 += 1;
			return message + " some-some";
			
        }

		public void setUp(out int x)
        {
			int a = 10;
			x = a;
        }

		public void test(ref string x)
        {
			x = "new string";
        }

		static void Main(string[] args)
		{
			//var keyword or explicit types?
			//build right abstractions for better incapsulation
			//un camp static este apelat fara instantiere
			Program pr = new Program();
			WriteLogDelegate log2 = pr.anyName;
			log2 += pr.someName;
			var res = log2("Salut");
			Console.WriteLine(res);
			Console.WriteLine(pr.count1);
			Console.WriteLine(pr.count2);
			return;
			Book b = new Book("Carnetul lui Paul");
			b.AddGrade(13.5);
			b.AddGrade(9.3);
			b.AddGrade(11.22);
			Console.WriteLine(b.getAverage());
			Console.WriteLine(b.getLowerGrade());
			Console.WriteLine(b.getHighestGrade());
			Class1 c = new Class1();
			c.val1 += 4;
			c.val2 = 10;
			Console.WriteLine(c.val1);
			Console.WriteLine(c.val2);
			int y = 25;
			Program p = new Program();
			p.setUp(out y);
			Console.WriteLine(y);
			string z = "string";
			p.test(ref z);
			Console.WriteLine(z);

			WriteLogDelegate log;
			//delegate necesita potrivire de return-type si de antet
			log = p.anyName;
			var result = log("Hello!");
			Console.WriteLine(result);

            if (args.Length > 0)
			{
                Console.WriteLine("Hello " + args[0]);
            }
            else
            {
				Console.WriteLine("Hello General!");
				goto done;
            }
			Console.WriteLine("Here");
		done:
			Console.WriteLine("After goto");
		}
	}
}
