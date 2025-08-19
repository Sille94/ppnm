using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //hidden neurons
	public Func<double,double> f = x=> x*Exp(-x*x);//activation function gaussian wavelet, can be changed
	public vector p;//network parameters 3 params for each neuron i.e. p = {a_1,b_1,w_1,a_2,...,w_n} 
	public ann(int n){//constructor creates p vector, with random initial guess
		p = new vector(n*3);
		this.n =n;
		var rnd = new Random();
		for(int i=0; i < p.size; i+=3){
			p[i]=2*rnd.NextDouble()-1;//a
			p[i+1]=1-0.5*rnd.NextDouble();//b can not be 0
			p[i+2]=2*rnd.NextDouble()-1;//w
			}
		}
	//Part A - Not Working for some reason
	public double response(double x){//calculates the response of the network to the input signal
		double F = 0; 
		for(int i=0; i<n; i++){
			double yi =f((x-p[3*i])/p[3*i+1]);//calculating the y_i=f((x-a_i)/b_i) values
			F+=yi*p[3*i+2];//sums all wighted y_i
			}
		return F;
		}
	
	public void train(vector x, vector y){//training network to interpolate table (supervised training). x input, y desired output
		Func<vector, double> Cp = param =>{//cost function
			double sum=0;
			for(int k=0;k<x.size;k++){
				double res=0;
				for(int i=0; i<n; i++){	
					res+=f((x[k]-param[3*i])/param[3*i+1])*param[3*i+2];
					}
				sum+=(res-y[k])*(res-y[k]);
				}
			return sum/x.size;
			};
		(vector foundp, int count) = mini.newton(Cp,this.p);//minimizing cost function
		this.p=foundp;//updating parameter vector
		}	
}	
