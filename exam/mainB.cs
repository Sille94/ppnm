using static System.Console;
using System;
using static System.Math;
static class main{
	static public void Main(){
		WriteLine("Part B");
		var outstrm = new System.IO.StreamWriter("hydrogen_data.txt");
		var rnd = new Random();
		for(int N=1; N<7; N++){
			vector v = new vector(N);
			for(int i=0; i<N; i++){
				v[i]=rnd.NextDouble();
				}
			(vector alpha, matrix E, matrix C) = hydrogen.system_solve(v);
			double E0 = 0;
			for(int i=0; i<E.size1; i++){if(E0 > E[i,i])E0=E[i,i];}
			outstrm.WriteLine($"{N},{E0}");
			}
		outstrm.Close();
		}
}

