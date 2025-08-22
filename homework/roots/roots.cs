using static System.Console;
using static System.Math;
using System;
public static class roots{
	public static vector newton(Func<vector,vector> f,vector start, double acc=1e-2, vector dx=null){
		vector x=start.copy();
		vector fx=f(x),z,fz;
		int i =1;
		do{
			if(fx.norm() <acc) break;
			if(i>10000) break;
			matrix J=jacobian(f,x,fx,dx);
			(matrix QJ,matrix RJ) = QR.decomp(J);
			vector Dx = QR.solve(QJ,RJ,-fx);
			double lambda = 1.0;
			do{
				z=x+lambda*Dx;
				fz=f(z);
				if(fz.norm() < (1-lambda/2)*fx.norm()) break;
				if(lambda < 1.0/1024) break;
				lambda/=2;
				}while(true);
			i++;
			x=z; fx=fz;
			}while(true);
		return x;
		}
	static matrix jacobian(Func<vector,vector> f, vector x, vector fx=null, vector dx=null){
		if(dx == null) dx = x.map(xi => Abs(xi)*Pow(2,-26));
		if(fx == null) fx = f(x);
		matrix J=new matrix(x.size);
		for(int j=0; j< x.size; j++){
			x[j]+=dx[j];
			vector df=f(x)-fx;
			for(int i = 0; i<x.size; i++) J[i,j]=df[i]/dx[j];
			x[j]-=dx[j];
			}
		return J;
		}
	public static double bisec(Func<double,double> f, double x, double y, double tol){
		double fx=f(x),fy=f(y);
		if(fx*fy > 0) throw new Exception("Not backtracked");
		while(y-x<tol){	
			double xy = (x+y)/2;
			double fxy = f(xy);
			if(fx*fxy < 0){	y=xy;fy = fxy;}
			else{x=xy;fy=fxy;}
			}
		return(x+y)/2;	
		}
}
