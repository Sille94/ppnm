using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		WriteLine("Part A+B");
		WriteLine("Error as function of sampling points can be viewed in plainError.svg");
		//integration of unitcircle  in cartesian coordinates \int_{-1}^{1}\int_{-1}^{1} x^2+y^2 dydx
		Func<vector, double> f= x=>{return Sqrt(1-x[1]*x[1]);};
		var outstrm1 = new System.IO.StreamWriter("unitcircle_error.txt");
		var outstrm2 = new System.IO.StreamWriter("unitcircle_quasi.txt");
		vector a = new vector("1,1");
		vector b = new vector("-1,-1");
		for(int N=10000; N<=1000000; N+=10000){
			(double val, double err) = monte.plainmc(f,a,b,N);
			(double val_q, double err_q) = monte.multiDmc(f,a,b,N);
			outstrm1.WriteLine($"{N},{err},{Abs(PI-val)},{err_q},{Abs(PI-val_q)},{1/Sqrt(N)}");
			outstrm2.WriteLine($"{N},{val},{val_q}");
			}
		outstrm1.Close();
		outstrm2.Close();
		int N2 = 100000;
		(double plain_circ, double plainerr) = monte.plainmc(f,a,b,N2);
		(double quasi_circ, double quasierr) = monte.multiDmc(f,a,b,N2);
		WriteLine($"Area of unitcircle with plainmc yielded: {plain_circ} +/- {plainerr}");
		WriteLine($"Area of unitcircle with quasimc yielded: {quasi_circ} +/- {quasierr}");
		WriteLine($"Expected: PI={PI}");
		WriteLine($"Area of unitcircle calculated with plain-and quasi mc can be viewed in quasi.svg");
		WriteLine($"");
		WriteLine("solving the Interal from course page");
		//calculating (1/pi)^3\int_{0}^{pi}\int_{0}^{pi}\int_{0}^{pi}[1-cos(x)cos(y)cos(z)]dxdydz
		Func<vector, double> g = x=>{return 1/PI*1/PI*1/PI/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));};
		vector a2 = new vector("0,0,0");
		vector b2 = new vector(3);
		for(int i=0; i<3; i++){b2[i]=PI;}
		(double val2, double err2) = monte.plainmc(g,a2,b2,N2);
		WriteLine($"Integration with plainmc yielded: {val2} +/- {err2}");
		WriteLine($"expected val: 1.3932039296856768591842462603255");
		}
}
