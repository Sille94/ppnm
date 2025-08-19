using static System.Console;
using static System.Math;
using System;
static class main{
	static public void Main(){
		//Part A
		var outstrm1 = new System.IO.StreamWriter("SHO.txt");
		Func<double, vector, vector> f = (double x,vector y) => new vector(y[1],-y[0]);//simple harmonic oscillator
		vector y0 = new vector(0,1);//initial point
		(genlist<double> xs1, genlist<vector> ys1) = ode.driver(f,(0,4*PI),y0);
		for(int i=0; i<ys1.size; i++){outstrm1.WriteLine($"{xs1[i]},{ys1[i][0]}");}
		outstrm1.Close();
		
		var outstrm2 = new System.IO.StreamWriter("Damped.txt");
		Func<double, vector, vector> g = (double x, vector y) => new vector(y[1],-0.25*y[1]-5.0*Sin(y[0]));
		(genlist<double> xs2, genlist<vector> ys2) = ode.driver(g,(0,4*PI),y0);
		for(int j=0; j<ys2.size; j++){outstrm2.WriteLine($"{xs2[j]},{ys2[j][0]}");}
		outstrm2.Close();
		//Part B
		var newtCirc = new System.IO.StreamWriter("newtCirc.txt");
		var newtEllip = new System.IO.StreamWriter("newtEllip.txt");
		var relOrb = new System.IO.StreamWriter("relOrb.txt");
		var eps = 0.0;
		Func<double, vector, vector> orbit = (double x, vector y) => new vector(y[1],1-y[0]+eps*y[0]*y[0]);//function to calculate Orbit
		
		//Newtonian Circular orbit
		vector y0c = new vector("1,1e-1");//using 0 yielded very few data points
		(genlist<double>xsc,genlist<vector>ysc) = ode.driver(orbit,(0,12*PI),y0c);
		for(int i=0; i<ysc.size ;i++)newtCirc.WriteLine($"{1/ysc[i][0]*Cos(xsc[i])},{1/ysc[i][0]*Sin(xsc[i])}");
		newtCirc.Close();
		
		//Newtonian Elliptical orbit
		vector y0e = new vector("1,-0.5");
		(genlist<double>xse, genlist<vector>yse) = ode.driver(orbit,(0,12*PI),y0e);
		for(int i=0; i<yse.size; i++)newtEllip.WriteLine($"{1/yse[i][0]*Cos(xse[i])},{1/yse[i][0]*Sin(xse[i])}");
		newtEllip.Close();
		
		//Relativistic orbit
		vector y0rel = y0e.copy();
		eps = 0.01;
		(genlist<double> xsrel, genlist<vector> ysrel) = ode.driver(orbit,(0,20*PI),y0rel);
		for(int i=0; i<ysrel.size; i++)relOrb.WriteLine($"{1/ysrel[i][0]*Cos(xsrel[i])},{1/ysrel[i][0]-Sin(xsrel[i])}");
		relOrb.Close();
	}
}
