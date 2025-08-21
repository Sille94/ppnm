using System;
using static System.Console;
using static System.Math;

public static class hydrogen{
	public static (matrix, matrix) HN(vector alpha){//builds the matrices H and N
		int n = alpha.size;
		matrix H = new matrix(n,n);
		matrix N = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int j=i; j<n; j++){
				double a = alpha[i];
				if(i==j){
					H[i,i]=3.0/2.0*Sqrt(PI)*Pow(a,2)*Pow(2.0*a,-5.0/2.0)-1.0/(4.0*a);
					N[i,i]=1.0/4.0*Sqrt(PI)*Pow(2*a,-3.0/2.0);
					}
				else{
					double b = alpha[j];	
					H[i,j]=+3.0/2.0*Sqrt(PI)*a*b*Pow((a+b),-5.0/2.0)-1.0/(2.0*(a+b));
					H[j,i]=H[i,j];
					N[i,j]=1.0/4.0*Sqrt(PI)*Pow((a+b),-3.0/2.0);
					N[j,i]=N[i,j];
					}
				}
			}	
		return (H,N);
		}	
	public static vector find_a(vector alpha){
		Func<vector, double> eigen = a =>{
			(matrix H, matrix N) = HN(a);
			gev HNsystem = new gev(H,N);
			(matrix E, matrix C) = HNsystem.cholesky_solver();
			double E0=E[0,0];
			for(int i =0; i<E.size1; i++){
				if(E0 > E[i,i]) E0=E[i,i];
				}
			return E0;}; //ground state energy
		(vector opt_a, int count) = mini.newton(eigen,alpha);
		return opt_a;
		}
	public static (vector, matrix, matrix) system_solve(vector alpha){
		vector opt_a = find_a(alpha);
		(matrix H, matrix N) = HN(opt_a);
		gev HNsystem = new gev(H,N);
		(matrix E, matrix C) =  HNsystem.solver();
		return(opt_a, E, C);
		}
}
