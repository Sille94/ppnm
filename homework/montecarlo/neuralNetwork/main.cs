using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
	var outstrm1 = new System.IO.StreamWriter("data.txt");
	var outstrm2 = new System.IO.StreamWriter("ann_data.txt");
	Func<double,double> f = x => Cos(5*x-1)*Exp(-x*x);//function used to create training data
	int np = 100;//number of data points
	vector xs = new vector(np); vector ys = new vector(np);
	var rnd = new Random();
	for(int i=0; i<np; i++){
		double xi;
		if(rnd.Next(0,2)==1){xi = rnd.NextDouble();}
		else{xi = -rnd.NextDouble();}
		double yi = f(xi);
		xs[i]=xi;
		ys[i]=yi;
		outstrm1.WriteLine($"{xi},{yi}");
		}
	outstrm1.Close();	
	ann nn = new ann(6);
	Write("initial params=");
	nn.p.print();	
	nn.train(xs,ys);
	vector param = nn.p;
	Write("found params=");
	param.print();
	for(int i=0; i<np; i++) outstrm2.WriteLine($"{xs[i]},{nn.response(xs[i])}");
	outstrm2.Close();
	}
	
}
