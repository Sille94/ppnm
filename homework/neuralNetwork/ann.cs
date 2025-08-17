using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //hidden neurons
	public Func<double,double> f = x=> x*Exp(-x*x);//activation function gaussian wavelet, can be changed
	public vector p;//network parameters 3 params for each neuron i.e. p = {a_1,b_1,w_1,a_2,...,w_n} 
	public ann(int n){//constructor creates p vector, with random initial guess
		p = new vector(n*3);
		for(int i=0; i < p.size; i++){
			p[i]= new Random().NextDouble();
			}
		}
	public double response(double x){//calculates the response of the network to the input signal
		double F = 0; 
		for(int i=0; i<p.size; i+=3){
			double yi =f((x-p[i])/p[i+1]);//calculating the weighted y_i=f((x-a_i)/b_i) values
			F+=yi*p[i+2];//sums all y_i
			}
		return F;
		}
	
	public void train(vector x, vector y){//training network to interpolate table (supervised training). x input, y desired output
		Func<vector, double> Cp = param =>{//cost function
			p = param;
			double c=0;
			for(int k=0;k<x.size;k++){c+=(response(x[k]-y[k]))*(response(x[k]-y[k]));}
			return c/n;
			};
		(vector opt_p, int count) = mini.newton(Cp,p);//minimizing cost function
		p=opt_p;//updating parameter vector	
		}
}
