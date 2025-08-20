using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //hidden neurons
	public Func<double,double> f = x=> x*Exp(-x*x);//activation function gaussian wavelet, can be changed
	public Func<double,double> df = x => (1-2*x*x)*Exp(-x*x)//first deriviative of activation function
	public Func<double,double> d2f = x =>2*x*(2*x*x-3)*Exp(-x*x) //secon deriviative of activation function
	public Func<double,double> antif = x =>-Exp(-x*x)/2 //anti-deriviative of activation function
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

	public double response(double x){//calculates the response of the network to the input signal
		double F = 0; 
		for(int i=0; i<n; i++){
			double yi =f((x-p[3*i])/p[3*i+1]);//calculating the y_i=f((x-a_i)/b_i) values
			F+=yi*p[3*i+2];//sums all wighted y_i
			}
		return F;
		}
	public double deriviative(double x){
		double dF = 0;
		for(int i=0; i<n; i++){dF+=p[3*i+2]*df((x-p[3*i])/p[3*i+1]);}
		return dF;
		}
	public double secon_deriviative(double x){
		double d2F = 0;
		for(int i=0; i<n; i++){d2F+=p[3*i+2]*d2f((x-p[3*i])/p[3*i+1];}
		return d2F;
		}
	public double antideriviative(double x){
		double antiF = 0;
		for(int i=0; i<n; i++){antiF+=p[3*i+2]*antf((x-p[3*i+1)/p[3*i+1]);}
		return intiF;
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
