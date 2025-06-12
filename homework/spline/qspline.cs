using System;
using static System.Math;
using static System.Console;
public class Qspline{
	vector x,y,b,c;
	public Qspline(vector xs, vector ys){
		x=xs.copy(); 
		y=ys.copy(); 
		c = calcc(x.size);
		b = calcb(x.size);
		}
	public double evaluate(double z){
		int i = binsearch(x,z);
		return y[i]+b[i]*(z-x[i])+c[i]*Pow(z-x[i],2);
		}
	public double derivative(double z){
		int i = binsearch(x,z);
		return b[i]+2*c[i]*(z-x[i]);
		}
	public double integral(double z){
		int i = binsearch(x,z);
		return y[i]*(z-x[i])+b[i]*Pow(z-x[i],2)/2+c[i]*Pow(z-x[i],3)/3;
		}
	int binsearch(vector x, double z){
		if(z<x[0] || z>x[x.size-1]) throw new Exception("Binsearch: bad z");
		int i = 0, j=x.size-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
			}
		return  i;
		}
	double[] forc(int n){
		WriteLine($"forc({n})");
		WriteLine($"double[] c= new double[{n-2}]");
		double[] c = new double[n-2];
		c[0]=0;
		for(int i =1; i<n-2; i++){
			double dx=x[i+1]-x[i];
			double dxm=x[i]-x[i-1];
			c[i]=1/dx*(p(i)-p(i-1)-c[i-1]*dxm);
			WriteLine($"forc iteration{i}");
			}
		WriteLine($"forc.length={c.Length}");
		return c;
		}
	double[] backc(int n){
		WriteLine($"backc({n})");
		WriteLine($"double[] bc = new double[{n-2}]"); 
		double[] c = new double[n-2];
		c[n-3] = 0;
		for(int i=n-4; i>=0; i--){
			double dx = x[i+1]-x[i];
			double dxp = x[i+2]-x[i+1];
			c[i]=1/dx*(p(i+1)-p(i)-c[i+1]*dxp);
			}
		return c;
		}
	vector calcc(int n){
		double[] bc = backc(n);
		double[] fc = forc(n);
		vector c = new vector(n-2);
		for(int i=0;i<n-2;i++)c[i]=bc[i]/2+fc[i]/2;			
		return c;
		}
	vector calcb(int n){
		vector b = new vector(n-2);
		for(int i=0; i<n-2; i++) b[i]=p(i)-c[i]*(x[i+1]-x[i]);
		return b;
		}	
	double p(int i){
		double dx=x[i+1]-x[i];
		double dy=y[i+1]-y[i];
		return dx/dy;
		}
}
