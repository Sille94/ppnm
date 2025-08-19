using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
	//Part A
	var outstrm1 = new System.IO.StreamWriter("data.txt");
	var outstrm2 = new System.IO.StreamWriter("ann_data.txt");
	
	Func<double,double> f = x => Cos(5*x-1)*Exp(-x*x);//function used to create training data
	int np = 100;//number of data points
	//creating data
	vector xs = new vector(np); vector ys = new vector(np);
	double a = -1; double b = 1;
	for(int i=0; i<np; i++){
		double x = a+(b-a)*i/(np-1);
		double y = f(x);
		xs[i]=x;
		ys[i]=y;
		outstrm1.WriteLine($"{x},{y}");
		}
	outstrm1.Close();

	//training ann	
	ann nn = new ann(5);
	Write("initial params=");
	nn.p.print();	
	nn.train(xs,ys);
	Write("found params=");
	nn.p.print();
	for(int i=0; i<xs.size; i++) outstrm2.WriteLine($"{xs[i]},{nn.response(xs[i])}");
	outstrm2.Close();
	}
	
}
