using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){	
		WriteLine("Rosenbrock's valley function");
		Func<vector, double> rv = x =>{return Pow(1-x[0],2)+100*Pow(x[1]-Pow(x[0],2),2);};
		vector x0_rv = new vector("100,100");
		(vector x_rv, int i) = mini.newton(rv,x0_rv);
		if(i<10001){
			WriteLine($"minimum found at rv({x_rv[0]},{x_rv[1]})={rv(x_rv)}");
			WriteLine($"with {i} iterations");
			}
		WriteLine("");
		WriteLine("Himmelblau's function");
		Func<vector,double> hb = x =>{return Pow(Pow(x[0],2)+x[1]-11,2)+Pow(x[0]+Pow(x[1],2)-7,2);};
		vector x0_hb = new vector("50,50");
		(vector x_hb, int j) = mini.newton(hb,x0_hb);
			if(i<10001){
				WriteLine($"minimum found at hb({x_hb[0]},{x_hb[1]})={hb(x_hb)}");
				WriteLine($"with {j} iterations");
				}
		}
}
