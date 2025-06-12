using System;
using static System.Console;
using static System.Math; 
using System.IO;
static class main{
	static public void Main(){
		var outstrm1 = new StreamWriter("data.txt");
		var outstrm2 = new StreamWriter("spline.txt");
		var outstrm3 = new StreamWriter("qspline.txt");
		double[] xs = {0,1,2,3,4,5,6,7,8,9};
		double[] ys = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){
			ys[i]=Cos(xs[i]);
			outstrm1.WriteLine($"{xs[i]},{ys[i]}");
		}
		int n = 100;
		int l = xs.Length;
		double step = (double)l/(double)n;
		WriteLine($"step = {step}");
		Qspline q = new Qspline(xs,ys);
		for(double z=0; z<8; z+=step){
			double val = spline.linterp(xs,ys,z);
			double valInteg = spline.linterpInteg(xs,ys,z);
			outstrm2.WriteLine($"{z},{val},{valInteg}");
			double qval = q.evaluate(z);
			double qderiv = q.derivative(z);
			double qinteg = q.integral(z);
			outstrm3.WriteLine($"{z},{qval},{qderiv},{qinteg}");
			}
		outstrm1.Close();
		outstrm2.Close();
		outstrm3.Close();
		}
}
