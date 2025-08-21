using static System.Console;
using System;
using static System.Math;
static class main{
	static public void Main(){
		WriteLine("PPNM Exam - Generalized Eigenvalue Problem");
		WriteLine("");
		WriteLine("Part A: Implementing the solver for the Generalized Eigenvalue Problem");
		WriteLine("");
		WriteLine("Testing the general eigenvalue problem solver");
		var rnd = new System.Random();
		int n = rnd.Next(2,6);
		WriteLine($"Creating a ({n} x {n}) real symmetric posetive definite matrix B");
		var M = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int j=i; j<n; j++){
				double val = 1+rnd.NextDouble();//only positive values
				if(i==j){M[i,j]=val;}//diagonal
				else{M[i,j]=val;M[j,i]=val;}//ensuring symmetry
				}
			}
		matrix M_T =M.transpose();
		if(!M.approx(M_T))throw new Exception("Error: M not symmetric");
		matrix  B = M*M.transpose();//Ensuring that B is definite
		Write("B=");B.print();
	
		WriteLine("");
		WriteLine($"Creating a ({n},{n}) real symmetric matrix A");
		matrix A = matrix.id(n);
		for(int i=0; i<n; i++){
			for(int j=i; j<n; j++){
				double val = 2*rnd.NextDouble()-1;//negative values are allowed;
				if(i==j){A[i,j]=val;}//diagonal
				else{A[i,j]=val;A[j,i]=val;}//symmetry 
				}
			}
		matrix A_T = A.transpose();
		if(!A.approx(A_T))throw new Exception("Error: A not symmetric");
		Write("A=");A.print();
		WriteLine("");

		WriteLine("Solving AV = BVE for V,E");
		gev ABsystem = new gev(A,B);
		(matrix E, matrix V) = ABsystem.solver();
		Write("E=");E.print();
		Write("V=");V.print();
		WriteLine("Calculating AV");
		matrix AV = A*V;
		Write("AV=");AV.print();
		WriteLine("Calculating BVE");
		matrix BVE = B*V*E;
		Write("BVE=");BVE.print();
		if(!AV.approx(BVE))throw new Exception("Error: AV =/= BVE, system not solved");
		else WriteLine("Generalised Eigenvalue Problem solved successfully, the implementation of the solver can be viewed in the file GEV.cs");	
	}	
}


