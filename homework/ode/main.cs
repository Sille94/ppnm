using static System.Console;
using static System.Math;
using System;
static class main{
	static public void Main(){
		Func<double, vector, vector> f = (x,y) => {vector v = x*y;return v;};
		double[] vals = {2,3};
		vector u = new vector(vals);
		f(2,u).print();
	}
}
