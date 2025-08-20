using static System.Console;
using static System.Math;
using System;

static class main{
	static public void Main(){
		double acc = 0.001;
		double eps = 0.001;
		WriteLine("Part A");
		WriteLine("Debug using some functions");
		WriteLine("");

		Func<double,double>f1 = x =>{double y=Sqrt(x);return y;};
		int count1=0;
		double val1 = integ.integrate(f1,0,1,acc,eps,ref count1);
		WriteLine($"func1={val1}");		
		WriteLine($"expected: 2/3={(double)2/(double)3}");
		WriteLine($"no of iterations: {count1}");
		WriteLine($"");

		Func<double,double>f2 = x =>{double y=1/Sqrt(x);return y;};
		int count2=0;
		double val2 = integ.integrate(f2,0,1,acc,eps,ref count2);
		WriteLine($"func2={val2}");
		WriteLine($"expected: 2");
		WriteLine($"no of interations: {count2}");
		WriteLine("");

		Func<double,double>f3 = x =>{double y=Sqrt(1-x*x);return y;};
		int count3=0;
		double val3 = integ.integrate(f3,0,1,acc,eps,ref count3);
		WriteLine($"func3={val3}");
		WriteLine($"expected: Pi/4={PI/(double)4}");
		WriteLine($"no of interations: {count3}");
		WriteLine("");
		
		Func<double,double>f4 = x =>{double y=Log(x)/Sqrt(x);return y;};
		int count4 =0;
		double val4 = integ.integrate(f4,0,1,acc,eps,ref count4);
		WriteLine($"func4={val4}");
		WriteLine($"expected: -4");
		WriteLine($"no of iterations: {count4}");
		WriteLine("");
		

		WriteLine("Error Function can be viewed in errorFunc.svg");
		WriteLine("");
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
			outstrm2.WriteLine($"{a},{Abs(boterf1-erf1)}");
			}
		outstrm1.Close();
		outstrm2.Close();
		
		WriteLine("Part B");
		WriteLine("");
		Func<double,double> g = x => 1/Sqrt(x);
		Func<double,double> h = x => Log(x)/Sqrt(x);
		int iter_ccg=0,iter_cch=0,iter_ig=0,iter_ih=0;
		double ccg = integ.clenshaw_curtis(g,0,1,acc,eps,ref iter_ccg);
		double cch = integ.clenshaw_curtis(h,0,1,acc,eps,ref iter_cch);
		double ig = integ.integrate(g,0,1,acc,eps,ref iter_ig);
		double ih = integ.integrate(h,0,1,acc,eps,ref iter_ih);
		WriteLine("1/Sqrt(x):");
		WriteLine($"Integration with Clenshaw-Curtis yielded {ccg} (expected 2) with {iter_ccg} iterations - compared to {iter_ig} iterations with the original integration routine");
		WriteLine("");
		WriteLine("Log(x)/Sqrt(x):");
		WriteLine($"Integration with Clenshaw-Curtis yielded {cch} (expected -4) with {iter_cch} iterations - compared to {iter_ih} iterations with the original integration routine");	
		WriteLine("");
		WriteLine("testing a converging infinite limit integral: Sin(x)/x from 0 to -inf ");
		Func<double,double> gen = x => Sin(x)/x;
		int count = 0;
		double igen = integ.integrate(gen,0,double.PositiveInfinity,acc,eps,ref count);
		WriteLine($"Expected value pI/2 = {PI/2} - Integration yielded {igen}, with {count} iterations");
		}
}
