using System;
using static System.Console;
public static class QR{ 
	public static (matrix, matrix) decomp(matrix A){//decomp function: returns touple (matrix Q, matrix R), argument (n x m) matrix A, such that QR=A
		int n = A.size1;
		int m = A.size2;
		if(n < m) throw new ArgumentException("n<m for the (n x m) matrix A"); //tjek that n larger than m 
		matrix Q = A.copy();	
		matrix R = new matrix(m,m);
		for(int i=0; i<m; i++){
			R[i,i] = Q[i].norm(); //optain the (i,i)-th element of R
			Q[i]/=R[i,i]; //optain the i-th collumn of Q
			for(int j=i+1; j<m; j++){
				R[i,j] = Q[i].dot(Q[j]);//optain the (i,j)-th element of R
				Q[j]-=Q[i]*R[i,j];//optain the j-th collumn of Q
			}
		}
		return(Q,R);
		
	}
	public static vector solve(matrix Q, matrix R, vector b){//solve function: returns vector x, arguments (n x m) matrix Q, (m x m) matrix R, vector b. solves the equation Ax=b for x, where A=QR; therefore Rx=Q^Tb. (Q^T is Q transposed)
		int m = Q.size2;
		//calculate vector v=Q^Tb
		vector c = Q.transpose()*b;
		Write("Q=");Q.print();
		Write("Q^T=");Q.transpose().print();
		Write("b=");b.print();
		Write("Q^T*b=");c.print();
		//solve Rx = v by backsubstitution since R is right/upper triangular
		vector x = new vector(m);
		for(int i=m-1; i>=0; i--){
			double sum = 0;
			for(int k=i+1; k<m; k++){sum+=R[i,k]*x[k];}
			x[i]=(c[i]-sum)/R[i,i];
		}
		return x;
	}
	public static double det(matrix R){//det function: returns scalar a, argument (m x m) matrix R. calculates the determinant of R.
		int m = R.size1;
		var prod = (double)1;
		for(int i=0; i<m; i++){
			prod*=R[i,i];
		}
		return prod;
	}
}
