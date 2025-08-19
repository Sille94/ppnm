using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		WriteLine("Part A");	
		WriteLine("Rosenbrock's valley function");
		Func<vector, double> rv = x =>{return Pow(1-x[0],2)+100*Pow(x[1]-Pow(x[0],2),2);};
		vector x0_rv = new vector("100,100");
		(vector x_rv, int i) = mini.newton(rv,x0_rv);
		if(i<10001){
			WriteLine($"minimum found at rv({x_rv[0]},{x_rv[1]}), expected at (1,1)");
			WriteLine($"with {i} iterations");
			}
		WriteLine("");
		WriteLine("Himmelblau's function");
		Func<vector,double> hb = x =>{return Pow(Pow(x[0],2)+x[1]-11,2)+Pow(x[0]+Pow(x[1],2)-7,2);};
		vector x0_hb = new vector("50,50");
		(vector x_hb, int j) = mini.newton(hb,x0_hb);
			if(i<10001){
				WriteLine($"minimum found at hb({x_hb[0]},{x_hb[1]}), expectet at (3,2), (-2.8,3.13), (-3.78,-3.28) or (3.58,-1.85)");
				WriteLine($"with {j} iterations");
				}
		WriteLine("Part B");
		var energy = new genlist<double>();
		var signal = new genlist<double>();
		var error = new genlist<double>();
		var separators = new char[] {' ','\t',','};
		var options = StringSplitOptions.RemoveEmptyEntries;
		do{
			string line=Console.In.ReadLine();
			if(line==null)break;
			string[] words = line.Split(seperators,options);
			energy.add(double.Parse(Words[0]));
			signal.add(double.Parse(Words[1]));
			error.add(double.Parse(Words[2]));
			}while(true);
		}
}
