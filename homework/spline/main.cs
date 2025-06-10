using System;
using static System.Console;
using static System.Math; 

static class main{
	static public void Main(){
		double[] xs = {0,1,2,3,4,5,6,7,8,9};
		double[] ys = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){
			ys[i]=Cos(xs[i]);
		}
		double[] vals = new double[xs.Length];
		double[] valsInteg = new double[xs.Length];
		int count = 0;
		foreach(double z in xs){
			double val = spline.linterp(xs,ys,z);
			double valInteg = spline.linterpInteg(xs,ys,z);
			vals[count]=val;
			valsInteg[count]=valInteg;
			WriteLine($"{z},{val},{valInteg},{ys[count]}");
			count++;
		}
	}
}
