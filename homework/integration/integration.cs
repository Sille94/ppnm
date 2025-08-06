using System;
using static System.Math;
using static System.Console;

public static class integ{
	public static double integrate(Func<double, double> f, double a, double b, double acc,double eps, double f2=Double.NaN, double f3=Double.NaN){
		double h = b-a;
		if(Double.IsNaN(f2)){f2=f(a+2*h/6);f3=f(a+4*h/6);}
		double f1=f(a+h/6), f4=f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
		double q = (f1+f2+f3+f4)/4*(b-a);
		double err = Abs(Q-q);
		if(err <= acc+eps*Abs(Q)){return Q;}
		else {return integrate(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2)+integrate(f,(a+b)/2,b,acc/Sqrt(2),eps,f3,f4);}
		}
	public static double erf(double z, double acc, double eps){
		if(0<=z&&z<=1){
			Func<double,double>f=x=>{double y=Exp(-(x*x));return y;};
			return 2/Sqrt(PI)*integrate(f,0,z,acc,eps);
			}
		if(1<=z){
			Func<double,double>f=t=>{double y=Exp(-(z+(1-t)/t)*(z+(1-t)/t)/t/t);return y;};
			return 1-2/Sqrt(PI)*integrate(f,0,1,acc,eps);
			}
		else{return -erf(-z,acc,eps);}
		}
}
