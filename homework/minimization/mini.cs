using System; 
using static System.Console;
using static System.Math;

public static class mini{
	public static (vector,int) newton(Func<vector,double> f, vector x, double acc=1e-3){
		int i=0;
		do{
			if(i>1000){WriteLine("Max iterations reached"); break;}
			vector gf = gradient(f,x);
			if(gf.norm() < acc) break;
			matrix H = hessian(f,x);
			(matrix Q, matrix R) = QR.decomp(H);
			vector dx = QR.solve(Q,R,-gf);
			double l = 1.0;
			do{
				if(f(x+l*dx)<f(x)) break;
				if(1.0/1024 > l) break;
				l=l/2;
				}while(true);
			x+=l*dx;
			i++;
			}while(true);
		return (x,i);	
		}
	static vector gradient(Func<vector,double> f, vector x){
		double fx = f(x);
		vector gf = new vector(x.size);
		for(int i=0 ;i<x.size; i++){
			double dxi = (1+Abs(x[i]))*Pow(2,-26);
			//vector x_step = x.copy();
			//x_step[i]+=dxi;
			x[i]+=dxi;
			gf[i]=(f(x)-fx)/dxi;
			x[i]-=dxi;
			}
		return gf;
		}
	static matrix hessian(Func<vector,double> f,vector x){
		matrix H = new matrix(x.size,x.size);
		vector gfx = gradient(f,x);
		for(int j=0; j<x.size; j++){
			double dxj = (1+Abs(x[j]))*Pow(2,-13);
			//vector x_step = x.copy();
			//x_step[j] +=dxj;
			x[j]+=dxj;
			vector dg = gradient(f,x)-gfx;
			for(int i=0; i<x.size;i++){
				H[i,j]=dg[i]/dxj;
				}
			x[j]-=dxj;
			}
		return H;
		}
}
