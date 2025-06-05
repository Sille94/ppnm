using static System.Console;
using static System.Math;
using System;
static class main{
	static int Main(){
		for(int i = 1; i<13; i+=1){WriteLine($"{i},{factorial(i)},{sgamma(i)},{Log(factorial(i))},{lngamma(i)}");}
		return 0;
	}
	static double sgamma(double x){
		if(x<0)return PI/Sin(PI*x)/sgamma(1-x);
		if(x<9) return sgamma(x+1)/x;
		double lnsgamma=Log(2*PI)/2+(x-0.5)*Log(x)-x+(1.0/12)/x-(1.0/360)/(x*x*x)+(1.0/1260)/(x*x*x*x*x);
		return Exp(lnsgamma);
	}
	static double lngamma(double x){
		if(x<=0) throw new ArgumentException("lngamma: x<=0");
		if(x<9) return lngamma(x+1)-Log(x);
		return x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	}
	static int factorial(int x){
		var fac = 1;
		for(int i=1; i<=x; i++){
			fac = fac*i;
		}
		return fac; 
	}
} 
