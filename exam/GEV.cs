using System;
using static System.Math;
using static System.Console;

public class gev{
	public matrix A;
	public matrix B;
	public matrix Q;
	public matrix S;
	int n;
	public gev(matrix A, matrix B){//constuctor
		n = B.size1;
		this.B = B;
		this.A = A;
		//Calculating Q and S, such that B=QSQ^T, using the Jacobi Algorythm implemented in Homework 2"
		(vector w, matrix q) = jacobi.cyclic(B);
		Q=q;
		//creating diagonal positive matrix S 
		S = matrix.id(n);	
		for(int i=0; i<n; i++){S[i,i]=w[i];}

		//Checking that B=QSQ^T
		var M = Q*S*Q.transpose();
		if(!B.approx(M))throw new Exception("Error: B =/= QSQ^T");
	
		//Checking that Q^TQ=QQ^T=I
		matrix I = matrix.id(n);
		M = Q.transpose()*Q;
		if(!I.approx(M))throw new Exception("Error: Q^TQ =/= I");
		M = Q*Q.transpose();
		if(!I.approx(M))throw new Exception("Error: QQ^T =/= I");
		}
	public (matrix, matrix) solver(){//solves the system AV=BVE
		matrix Snroot = matrix.id(n);
		for(int i=0; i<n; i++){Snroot[i,i]=1/Sqrt(S[i,i]);}//creates S^-½
		matrix Ã = Snroot*Q.transpose()*A*Q*Snroot; //creates matrix Ã
		(vector e, matrix X) = jacobi.cyclic(Ã);//solving the ordenary real eigenvalue problem, where e is the vector with the generalized eigen values 
		matrix V = Q*Snroot*X;//calculates the matrix V with the eigenvectors
		matrix E = matrix.id(n);
		for(int i=0; i<n; i++){E[i,i]=e[i];}//creates the diagonal matrix E with the eigenvalues 
		return (E,V);
		}
	public matrix cholesky_decomp(matrix B){
		matrix L = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int j=0; j<=i; j++){
				double sum =0.0;
				for(int k=0; k<j; k++){sum += L[i,k]*L[j,k];}
				if(i==j){L[i,j]=Sqrt(B[i,i]-sum);}
				else{L[i,j]=(B[i,j]-sum)/L[j,j];}
					}
				} 
		return L;
		}
	public (matrix,matrix) cholesky_solver(){//solved the system AV=BVE using cholesky decomp
		matrix L = cholesky_decomp(B);
		matrix L_inverse = QR.inverse(L);
		matrix LT = L.transpose();
		matrix LT_inverse = QR.inverse(LT);
		matrix Ã = L_inverse*A*LT_inverse;
		(vector e, matrix Y) = jacobi.cyclic(Ã);
		matrix V = LT_inverse*Y;
		matrix E = matrix.id(n);
		for(int i=0; i<n; i++){E[i,i]=e[i];}
		return(E,V);
		}
	}
