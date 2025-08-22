using System;
using static System.Console;
using static System.Math;

public static class hamiltonian{
	public static matrix generateH(double rmax, double dr){
		int n = (int) (rmax/dr)-1;
		vector r = new vector(n);
	//	WriteLine($"n={n}");
		for(int i=0; i<n; i++){
			r[i]=dr*(i+1);
		//	WriteLine($"r[{i}]= {dr}*{i}+1");
			}
		matrix H = new matrix(n,n);
		for(int i=0; i<n-1; i++){
			H[i,i] = -2*(-0.5/dr/dr);
			H[i,i+1] = 1*(-0.5/dr/dr);
			H[i+1,i] = 1*(-0.5/dr/dr);
			//if(H[i,i+1]!=0.0){WriteLine($"H[{i},{i+1}]={H[i,i+1]}");}
			}
		H[n-1,n-1]=-2*(0.5/dr/dr);
		for(int i=0; i<n; i++){
			H[i,i]+=-1/r[i];
			//WriteLine($"r[{i}]={r[i]}");
			//WriteLine($"H[{i},{i}]={H[i,i]}");
			}
		return H;
		}
	
}
