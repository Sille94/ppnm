using static System.Math;
using static System.Console;
using System;
using System.Collections.Generic;

public static class leastSquares{
	public static vector lsfit(Func<double,double[]> fs, vector x, vector y, vector dy){
		int n = x.size;
		var vals = fs(x[0]);
		int m = vals.Length;
		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i]=y[i]/dy[i];
			for(int k=0; k<m; k++)A[i,k]=fs(x[i])[k]/dy[i];
		}
		A.print();
		(matrix Q, matrix R) = QR.decomp(A);
		vector c = QR.solve(Q,R,b);
		return c;
	}
	public static vector lsfit2(Func<double,double[]> fs, vector x, vector y, vector dy){
		//Determine the size of the system
		var vals = fs(x[0]);
		int m =vals.Length;//m = number of therms in fitting function
		int n = y.size;//n = the number of data points
		matrix A = new matrix(n,m+1);//creating the (n x m) matrix
		for(int i=0; i<n; i++){
			var temp = new List<double>();
			foreach(double f in fs(x[i]))temp.Add(f);
			temp.Add(dy[i]);
			for(int j=0; j<m+1; j++)A[i,j]=temp[j];
		}
		//Solve with uncertainties
		vector yunc = new vector(n);
		for(int i=0; i<n; i++){yunc[i]=y[i]+dy[i];}
		(matrix Q, matrix R) = QR.decomp(A);
		vector c = QR.solve(Q,R,yunc);
		return c;
	}
}
