using static System.Console;
using System;
static class main{
	static int Main(string[] args){
		var list = new genlist<double[]>();
		char[] delimiters = {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for (string line = ReadLine(); line != null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0; i<n; i++){
				numbers[i] = double.Parse(words[i]);
				System.Console.Write($"{numbers[i]}\n");
			}
			list.add(numbers); 
		}
		for(int i=0; i < list.size; i++){
		var numbers = list[i];
		foreach(double number in numbers) Error.WriteLine($"{number: 0.00e+00;-00.0e+00}");
		WriteLine();
		}
		WriteLine($"List size before {list.size}");
		list.remove(0);
		WriteLine($"List size after {list.size}");
		return 0;
	}
}
