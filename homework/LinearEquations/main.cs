using static System.Console;
using System;
static class main{
	static public void Main(){
		WriteLine("======TASK A======");
		WriteLine("Test Decompostion Function A=QR");
		var rnd = new System.Random();
		int n = rnd.Next(2,6);
		int m = rnd.Next(2,n);
		if(n<m) throw new Exception("n<m");
		WriteLine($"Creating a (n={n} x m={m}) matrix A");
		matrix A = randomMatrix(n,m);
		Write("A=");A.print();	
		WriteLine("Decomposition A");
		(matrix Q, matrix R) = QR.decomp(A);
		WriteLine("Test right triangular R");
		for(int i=0; i<m; i++){
			for(int j=0; j<m; j++){
				if(j<i){
					if(R[i,j]!=0){
						Write("R=");R.print();
						throw new Exception("right triangular R Failed");
					}
				}	
			}
		}
		Write("right triangular R=");R.print();
		WriteLine("Test Q^TQ=I");
		matrix I = Q.transpose()*Q;
		for(int i=0; i<m; i++){
			for(int j=0; j<m; j++){
				if(i==j){
					if(!approx(I[i,j],1)){
						Write("Q^TQ=");I.print();	
						throw new Exception("Q^TQ=I failed: diagonal not 1");
					}
				}
				if(i!=j){
					if(!approx(I[i,j],0)){
						Write("Q^TQ=");I.print();
						throw new Exception("Q^TQ=I failed: triangle not 0");
					}
				}	
			}
		}
		Write("Q^TQ=I");I.print();
		WriteLine("Test QR=A");
		matrix B = Q*R;
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				if(!approx(B[i,j],A[i,j])){
				Write("QR=");B.print();
				Write("A=");A.print();
				throw new Exception("QR=A test failed");
				}
			}
		}
		Write("QR=");B.print();
		Write("A=");A.print();
		WriteLine("DECOMPOSITION TEST SUCCESSFULL");
		WriteLine("");
		WriteLine("Test solve function Ax=b");
		WriteLine($"Creating a random square ({n} x {n}) matrix A2");
		matrix A2  = randomMatrix(n,n);
		Write("A2=");A2.print();
		WriteLine($"Creating a random vector b of size {n}");
		vector b = new vector(n);
		for(int i=0; i<n; i++){
			b[i]=rnd.NextDouble();
		}
		Write("b=");b.print();
		WriteLine("Solve Ax=b:");
		(matrix Q2, matrix R2) = QR.decomp(A2);
		vector x = QR.solve(Q2,R2,b);
		Write("x=");x.print();
		WriteLine("Test Ax=b");
		vector c = A2*x;
		for(int i=0; i<n; i++){
			if(!approx(c[i],b[i])){
				Write("Ax=");c.print();
				Write("b=");b.print();
				throw new Exception("Ax=b test failed");
			}
		}
		Write("Ax=");c.print();
		WriteLine("SOLVE TEST SUCCESSFULL");
		WriteLine("");
		WriteLine("Calculate Determinant of R");
		double det = QR.det(R);
		Write($"det|R|={det}");
		WriteLine("");
		WriteLine("=====TASK B======");
		WriteLine("calculate A  invers");
		matrix A2_inv = QR.inverse(Q2,R2);
		WriteLine("Test AA_inv=I");
		matrix Id = matrix.id(n);
		if(!Id.approx(A2*A2_inv)){throw new Exception("Test failed!");}
		WriteLine("ALL TESTS COMPELTED SUCCESSFULLY");
	}
	public static bool approx(double a,double b){
		double acc = 1e-9;
		double eps = 1e-9;
		double abs_ab = System.Math.Abs(a-b);
		double abs_a = System.Math.Abs(a);
		double abs_b = System.Math.Abs(b);
		if (abs_ab <= acc) return true;
		if (abs_ab <= System.Math.Max(abs_a,abs_b)*eps) return true;
		return false;
	}
	public static matrix randomMatrix(int n, int m){
		var rnd = new System.Random();
		matrix M = new matrix(n,m);
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				M[i,j]=rnd.NextDouble();
			}
		}
		return M;
	}

}
