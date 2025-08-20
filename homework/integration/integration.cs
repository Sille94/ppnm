using System;
using static System.Math;
using static System.Console;

public static class integ{
	public static double integrate(Func<double,double>f,double a,double b,double acc, double eps, ref int count, double f2=Double.NaN, double f3=Double.NaN){
		if(!double.IsInfinity(a)&&!double.IsInfinity(b)){return integrator(f,a,b,acc,eps,ref count);}
		if(double.IsNegativeInfinity(a)&&double.IsPositiveInfinity(b)){Func<double,double> u = t=>(f((1-t)/t) + f(-(1-t)/t))/Pow(t,2);return integrator(u,0,1,acc,eps,ref count);}
		if(!double.IsInfinity(a)&&double.IsPositiveInfinity(b)){Func<double,double> u = t =>f(a+(1-t)/t)*t/Pow(1-t,2);return integrator(u,0,1,acc,eps,ref count);}
		if(double.IsNegativeInfinity(a)&& !double.IsInfinity(b)){Func<double,double> u = t=>f(b-(1-t)/t)/Pow(t,2); return integrator(u,0,1,acc,eps,ref count);}
		else{throw new Exception("Wrong Integration limit");}
		}
	static double integrator(Func<double, double> f, double a, double b, double acc,double eps, ref int count, double f2=Double.NaN, double f3=Double.NaN){
		count++;
		double h = b-a;
		if(Double.IsNaN(f2)){f2=f(a+2*h/6);f3=f(a+4*h/6);}
		double f1=f(a+h/6), f4=f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*h;
		double q = (f1+f2+f3+f4)/4*h;
		double err = Abs(Q-q);
		if(err <= acc+eps*Abs(Q)){return Q;}
		else {return integrate(f,a,(a+b)/2,acc/Sqrt(2),eps,ref count, f1,f2)+integrate(f,(a+b)/2,b,acc/Sqrt(2),eps,ref count,f3,f4);}
		}

	public static double erf(double z, double acc, double eps){
		int count=0;
		if(0<=z&&z<=1){
			Func<double,double>f=x=>{double y=Exp(-(x*x));return y;};
			return 2/Sqrt(PI)*integrate(f,0,z,acc,eps,ref count);
			}
		if(1<=z){
			Func<double,double>f=t=>{double y=Exp(-(z+(1-t)/t)*(z+(1-t)/t)/t/t);return y;};
			return 1-2/Sqrt(PI)*integrate(f,0,1,acc,eps,ref count);
			}
		else{return -erf(-z,acc,eps);}
		}

	public static double clenshaw_curtis(Func<double,double>f, double a,double b,double acc,double eps,ref int count){
		Func<double,double> cc = thet => f((a+b)/2+(b-a)/2*Cos(thet))*Sin(thet)*(b-a)/2;
		return integrate(cc,0,PI,acc,eps,ref count);
		}
}
