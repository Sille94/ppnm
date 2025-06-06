using static System.Console;
using System;
static class main{
	static public void Main(){
		int n;
		int m;
		var rnd = new System.Random();
		n = rnd.Next(2,6);
		m = rnd.Next(2,n);
		if(n<m) throw new Exception("n<m");
		WriteLine($"Creating a vector b size n={n}");
		vector b = new vector(n);
		WriteLine("adding data to b");
		for(int i=0; i<n; i++){
			double d = rnd.NextDouble();
			b[i] = d;
			WriteLine($"b_{i+1}={d}");
		}
		Write("b=");b.print();
		WriteLine($"Creating a (n={n} x m={m}) matrix A");
		matrix A = new matrix(n,m); 
		WriteLine("adding data to A");
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				double d = rnd.NextDouble();
				A[i,j] = d;
				WriteLine($"A_{i},{j} ={d}"); 
			}
		}
		Write("A=");A.print();	
		WriteLine("Decomposition A:");
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
		WriteLine("Solve Ax=b:");
		vector x = QR.solve(Q,R,b);
		Write("x=");x.print();
		WriteLine("Test Ax=b");
		vector c = A*x;
		for(int i=0; i<n; i++){
			if(!approx(c[i],b[i])){
				Write("Ax=");c.print();
				Write("b=");b.print();
				throw new Exception("Ax=b test failed");
			}
		}
		Write("Ax=");c.print();
		Write("b=");b.print();
		WriteLine("Determinant of R");
		double det = QR.det(R);
		Write($"det|R|={det}");
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

}
