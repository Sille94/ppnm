using static System.Console;
using static System.Math;
using System;

public static class main{//Command line argument in the form -numbers:1,2,3,4,5
	public static int Main(string[] args){//args = ["-numbers:1,2,3,4,5"]
		WriteLine("x |  sin(x) |  cos(x)");
		foreach(var arg in args){//arg = "-numbers:1,2,3,4,5"
			var words = arg.Split(':');//arg.split(':') => words=["-numbers","1,2,3,4,5"]
			if(words[0]=="-numbers"){//words[0] = "-numbers"
				var numbers=words[1].Split(',');//words[1]="1,2,3,4,5" and .split (',') => numbers = ["1","2","3","4","5"]
				foreach(var number in numbers){//iterate throug ["1","2","3","4","5"]
					double x = double.Parse(number);//converte string to double
					WriteLine($" {x} |  {Sin(x)} |  {Cos(x)}");
				}
			}
		}	
		return 0;
	}
}
