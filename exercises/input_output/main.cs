using static System.Console;
using static System.Math;
using System;

public static class main{//Command line argument in the form -numbers:1,2,3,4,5
	public static void Main(string[] args){//args = ["-numbers:1,2,3,4,5"]
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
	char[] split_delimiters  = {' ','\t','\n'};
	var split_options = StringSplitOptions.RemoveEmptyEntries;
	for( string line = ReadLine(); line != null; line = ReadLine() ){
		var numbers = line.Split(split_delimiters,split_options);
		foreach(var number in numbers){
			double x = double.Parse(number);
			Error.WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
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
	var outstream = new System.IO.StreamWriter(outfile, append:false);
	for(string line = instream.ReadLine();line!=null;line=instream.ReadLine()){
		double x = double.Parse(line);
		outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
		}
	instream.Close();
	outstream.Close();
	return 0;
	}
	
}
