using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		WriteLine("Part B: convergence can be vied in convergence_dr.svg and convergence_rmax.svg");
		double rmax = 10;
		vector dr = new vector(10);
		for(int i=1; i<dr.size+1; i++){dr[i-1]=0.1*i;}
		var outstrm = new System.IO.StreamWriter("converg_dr.txt");
		for(int i=0; i<dr.size; i++){
			matrix H = hamiltonian.generateH(rmax,dr[i]);
			(vector e, matrix V) = jacobi.cyclic(H);
			double e0 = 0;
			for(int k=0; k<e.size; k++){if(e0 >e[k]) e0=e[k];}
			outstrm.WriteLine($"{dr[i]},{e[1]}");
			}
		outstrm.Close();
		
		vector rmaxs = new vector(10);
		for(int i=1; i<rmaxs.size+1; i++)rmaxs[i-1]=i;
		var outstrm2 = new System.IO.StreamWriter("converg_rmax.txt");
		for(int i=0; i<rmaxs.size; i++){
			matrix H = hamiltonian.generateH(rmaxs[i],0.3);
			(vector e, matrix V) = jacobi.cyclic(H);
			double e0=0;
			for(int k=0; k<e.size; k++){if(e0>e[k])e0=e[k];}
			outstrm2.WriteLine($"{rmaxs[i]},{e[1]}");
			}
		outstrm2.Close();
		
		matrix h = hamiltonian.generateH(10,0.1);
		(vector eigenval, matrix wavefunc) =jacobi.cyclic(h);
		var outstrm3 = new System.IO.StreamWriter("wavefunctions.txt");
		for(int i=0; i<eigenval.size; i++){
			double r = 0.1*(i+1);
			double w0 = 1/Sqrt(0.1)*wavefunc[i,1];
			double w1 = 1/Sqrt(0.1)*wavefunc[i,2];
			double w2 = 1/Sqrt(0.1)*wavefunc[i,3];
			outstrm3.WriteLine($"{r},{w0},{w1},{w2}");
			}	  	
		outstrm3.Close();
		}
}
