using static System.Console;
using System;
static class main{
	static public void Main(){
		var rnd = new System.Random();
		int n = rnd.Next(2,6);
		WriteLine("=====Preparaion=====");
		WriteLine($"Creating a (n x n) symmetric matrix A, with n={n}");
		matrix A = new matrix(n,n);
		for(int i=0; i<n; i++){
			for(int j=i; j<n; j++){
				double val = rnd.NextDouble();
				if(i==j){A[i,j]=val;}
				else{A[i,j]=val;A[j,i]=val;}
			}
		}
		WriteLine($">>Test symmetry of A: A^T=A");
		matrix A_T =A.transpose();
		if(!A.approx(A_T)){
			Write("A=");A.print();
			throw new Exception(">>symmetric A: Failed");
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine("=====Run EVD=====");
		(vector w, matrix V) = jacobi.cyclic(A);
		WriteLine("create diagonal matrix D");
		matrix D = matrix.id(n);
		for(int i=0; i<n; i++){
			D[i,i]=w[i];
		}
		WriteLine(">>Test V^TAV=D");
		var M = V.transpose()*A*V;
		if(!D.approx(M)){
			Write("V^TAV=");M.print();
			Write("D=");D.print();
			throw new Exception(">>V^TAV=D: Failed");	
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine(">>Test VDV^T=A");
		M = V*D*V.transpose();
		if(!A.approx(M)){
			Write("VDV^T=");M.print();
			Write("A=");A.print();
			throw new Exception(">>VDV^T=A: Failed");
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine(">>Test V^TV=VV^T=I");
		matrix I = matrix.id(n);
		M = V.transpose()*V;
		if(!I.approx(M)){
			Write("V^TV=");M.print();
			throw new Exception(">>V^TV=I: Failed");
		}
		M = V*V.transpose();
		if(!I.approx(M)){
			Write("VV^T=");M.print();
			throw new Exception(">>VV^T=I: Failed");
		}
		WriteLine(">>ALL TEST COMPLETED SUCCESSFULLY");
		WriteLine("");
		WriteLine("=====RESULTS=====");
		Write("A=");A.print();
		Write("V=");V.print();
		Write("D=");D.print();
	}	
}


