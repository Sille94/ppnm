using static System.Console;
using static System.Math;
using System;

public static class main{
	public static int Main(string[] args){
		string infile = null, outfile = null;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-input")infile=words[1];
			if(words[0]=="-output")outfile=words[1];
			}
		if(infile==null || outfile==null){
			Error.WriteLine("wrong filename argument");
			return 1;
			}
		var instream = new System.IO.StreamReader(infile);
		var outstream = new System.IO.StreamWriter(outfile, append:true);
		outstream.WriteLine($"x|sin(x)|cos(x)");
		for(string line = instream.ReadLine();line!=null;line=instream.ReadLine()){
			var numbers = line.Split(' ');
			foreach(var number in numbers){	
				double x = double.Parse(number);
				outstream.WriteLine($"{x} | {Sin(x)} | {Cos(x)}");
				}
		}
		instream.Close();
		outstream.Close();
		return 0;
	}
	
}
