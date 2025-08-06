using static System.Console;
using static System.Math;
using System;

static class main{
	static public void Main(){
		double acc = 0.001;
		double eps = 0.001;
		Func<double,double>f1 = x =>{double y=Sqrt(x);return y;};
		double val1 = integ.integrate(f1,0,1,acc,eps);
		WriteLine($"val1={Round(val1,3)}");		
		WriteLine($"2/3={Round((double)2/(double)3,3)}");
		Func<double,double>f2 = x =>{double y=1/Sqrt(x);return y;};
		double val2 = integ.integrate(f2,0,1,acc,eps);
		WriteLine($"val2={Round(val2,3)}");
		WriteLine($"{Round((double)2,3)}");
		Func<double,double>f3 = x =>{double y=Sqrt(1-x*x);return y;};
		double val3 = integ.integrate(f3,0,1,acc,eps);
		WriteLine($"val3={Round(val3,3)}");
		WriteLine($"Pi/4={Round(PI/4,3)}");
		Func<double,double>f4 = x =>{double y=Log(x)/Sqrt(x);return y;};
		double val4 = integ.integrate(f4,0,1,acc,eps);
		WriteLine($"val4={Round(val4,3)}");
		WriteLine($"{-4}");
		var outstrm1 = new System.IO.StreamWriter("erf_data.txt");
		var outstrm2 = new System.IO.StreamWriter("erf_eps.txt");
		for(double i=0; i<0.1; i+=0.02){
			outstrm1.WriteLine($"{i},{integ.erf(i,acc,eps)}");
			}
		for(double i=0.1; i<2.5; i+=0.1){
			outstrm1.WriteLine($"{i},{integ.erf(i,acc,eps)}");
			}
		for(double i=2.5; i<4.0; i+=0.5){
			outstrm1.WriteLine($"{i},{integ.erf(i,acc,eps)}");
			}
		double boterf1 = 0.84270079294971486934;
		for(double a=0.1; a>1/1E5; a=a/10){
			var erf1 = integ.erf(1,a,0);
			WriteLine($"{boterf1}");
			WriteLine($"{erf1},{Abs(boterf1-erf1)}");
			outstrm2.WriteLine($"{a},{Abs(boterf1-erf1)}");
			}
		outstrm1.Close();
		outstrm2.Close();
		}
}
