using static System.Console;
using System;
using static System.Math;
static class main{
	static public void Main(){
		WriteLine("Part B");
		vector v =new vector("0.02,0.1,0.38");
		Write("alph_init=");v.print();
		(matrix H, matrix N) = hydrogen.HN(v);
		H.print();
		N.print();
		(vector alph_opt, matrix E, matrix C) = hydrogen.system_solve(v);
		Write("alph_opt=");alph_opt.print();
		Write("E=");E.print();
		Write("C=");C.print();
		}
}

