using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		//integration of unitcircle  in cartesian coordinates \int_{-1}^{1}\int_{-1}^{1} x^2+y^2 dydx
		Func<vector, double> f= x=>{return Sqrt(1-x[1]*x[1]);};
		for(int N=10000; N<=1000000; N+=10000){
			vector a = new vector("1,1");
			vector b = new vector("-1,-1");
			(double val, double err) = monte.plainmc(f,a,b,N);
			WriteLine($"{N},{err},{Abs(PI-val)},{1/Sqrt(N)}");
			}
		}
}
