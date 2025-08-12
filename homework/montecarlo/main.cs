using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		//integration of unitcircle  in cartesian coordinates \int_{-1}^{1}\int_{-1}^{1} x^2+y^2 dydx
		Func<vector, double> f= x=>{return Sqrt(1-x[1]*x[1]);};
		var outstrm = new System.IO.StreamWriter("unitcircle.txt");
		for(int N=10000; N<=1000000; N+=10000){
			vector a = new vector("1,1");
			vector b = new vector("-1,-1");
			(double val, double err) = monte.plainmc(f,a,b,N);
			outstrm.WriteLine($"{N},{err},{Abs(PI-val)},{1/Sqrt(N)}");
			}
		outstrm.Close();
		//calculating (1/pi)^3\int_{0}^{pi}\int_{0}^{pi}\int_{0}^{pi}[1-cos(x)cos(y)cos(z)]dxdydz
		Func<vector, double> g = x=>{return 1/PI*1/PI*1/PI/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));};
		vector a2 = new vector("0,0,0");
		vector b2 = new vector(3);
		for(int i=0; i<3; i++){b2[i]=PI;}
		int N2 = 100000;
		(double val2, double err2) = monte.plainmc(g,a2,b2,N2);
		WriteLine($"val = {val2} +/- {err2}");
		WriteLine($"1.3932039296856768591842462603255");
		}
}
