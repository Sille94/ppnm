using static System.Console;
using System;
using static System.Math;
using System.Linq;
static class main{
	static public void Main(){
		Func<double, double[]>fs = x =>{double[] v = {1,-x};return v;};
		//Data for ThX
		double[] ts = {1,2,3,4,6,9,10,13,15};
		double[] ys = {117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dy = {7,6,5,4,4,4,3,3,2,2};
		//Function ln(y+dy) =ln(y(1+dy/y) = ln(y)+ln(1+dy/y) = ln(y)+dy/y
		int n = ys.Length;
		double[] lny = new double[n];
		double[] lndy = new double[n];
		var outstrm1 = new System.IO.StreamWriter("ln_data.txt");
		var outstrm2 = new System.IO.StreamWriter("ln_fit.txt");
		var outstrm3 = new System.IO.StreamWriter("data.txt");
		var outstrm4 = new System.IO.StreamWriter("fit.txt");
		for(int i=0; i<n; i++){
			outstrm3.WriteLine($"{ts[i]},{ys[i]},{dy[i]}");
			double templny = Log(ys[i]);
			double templndy = dy[i]/ys[i];
			lny[i]=templny;//ln(y) values 
			lndy[i]=templndy;//ln(1+dy/y) values	
			outstrm1.WriteLine($"{ts[i]},{templny},{templndy}");
		}
		vector c= leastSquares.lsfit2(fs,ts,lny,lndy);
		double lna = c[0];
		double lambda = c[1];
		Func<double, double>fit = x=> lna-x*lambda;
		int steps = 100;
		double step =ts.Max()/steps+2/steps;
		for(double t=0; t<ts.Max()+2; t+=step){
			outstrm2.WriteLine($"{t},{fit(t)}");
			outstrm4.WriteLine($"{t},{Exp(fit(t))}");
		}
		outstrm1.Close();
		outstrm2.Close();
		outstrm3.Close();
		outstrm4.Close();
		double hlife = Log(2)/lambda;
		WriteLine($"ln(a)={lna}, lambda={lambda}, T_1/2={hlife}");
		WriteLine($"modern value T_1/2 =3.63");
	}
	static public void testQR(){
		WriteLine("=====Preparation=====");
		var rnd = new System.Random();
		int n = rnd.Next(2,6);
		int m = rnd.Next(n,7);
		if(n>m){ 
			WriteLine($"n={n}");
			WriteLine($"m={m}");
			throw new Exception("n>m");
		}
		WriteLine($"Creating a random ({n} x {m}) Matrix A");
		matrix A = randomMatrix(n,m);
		WriteLine("");
		WriteLine("=====Decomposition M using QR=====");
		(matrix Q, matrix R) = QR.decomp(A);
		WriteLine(">>Test R right triangular");
		for(int i=0; i<m; i++){
			for(int j=0; j<m; j++){
				if(j<i){
					if(R[i,j]!=0){
						Write("R=");R.print();
						throw new Exception(">>R right triangular: Faled");
					}
				}		
			}
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine(">>Test Q^TQ=I");
		matrix I = matrix.id(Q.size1);
		matrix QTQ = Q.transpose()*Q;
		if(!I.approx(QTQ)){
			Write("Q^TQ=");QTQ.print();
			Write("I=");I.print();
			throw new Exception(">>Q^TQ: Failed");
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine(">>Test A=RQ");
		matrix qr = Q*R;
		if(!A.approx(qr)){ 
			Write("QR=");qr.print();
			Write("A=");Q.print();
			throw new Exception(">>A=QRR: Failed");
		}
		WriteLine(">>All good");
		WriteLine("");
		WriteLine("======RESULTS======");
		Write("A=");A.print();
		Write("Q=");Q.print();
		Write("R=");R.print();
	}
	static public matrix randomMatrix(int n, int m){
		var rnd = new System.Random();
		matrix M = new matrix(n,m);
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				M[i,j] =rnd.NextDouble();
			}
		}
	return M;
	}	
}
