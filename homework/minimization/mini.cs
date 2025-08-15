using System; 
using static System.Console;
using static System.Math;

public static class mini{
	public static (vector,int) newton(Func<vector,double> phi, vector x, double acc=1e-3){
		int i=0;
		do{
			if(i>10000){WriteLine("Max iterations reached"); break;}
			vector g = gradient(phi,x);
			if(g.norm() < acc) break;
			matrix H = hessian(phi,x);
			(matrix Q, matrix R) = QR.decomp(H);
			vector dx = QR.solve(Q,R,-g);
			double l = 1;
			do{
				if(phi(x+l*dx)<phi(x)) break;
				if(1/1024 <= l) break;
				l /= 2;
				}while(true);
			x+=l*dx;
			i++;
			}while(true);
		return (x,i);	
		}
	static vector gradient(Func<vector,double> phi, vector x){
		double phix = phi(x);
		vector gphi = new vector(x.size);
		for(int i=0 ;i<x.size; i++){
			double dxi = (1+Abs(x[i]))*Pow(2,-26);
			vector x_step = x.copy();
			x_step[i]+=dxi;
			gphi[i]=(phi(x_step)-phix)/dxi;
			}
		return gphi;
		}
	static matrix hessian(Func<vector,double> phi,vector x){
		matrix H = new matrix(x.size,x.size);
		vector gphix = gradient(phi,x);
		for(int j=0; j<x.size; j++){
			double dxj = (1+Abs(x[j]))*Pow(2,-13);
			vector step = x.copy();
			step[j] +=dxj;
			vector dgphi = gradient(phi,step)-gphix;
			for(int i=0; i<x.size;i++){
				H[i,j]=dgphi[i]/dxj;
				}
			}
		return H;
		}
}
