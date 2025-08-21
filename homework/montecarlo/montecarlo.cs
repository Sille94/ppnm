using System;
using static System.Math;
using static System.Console;

public static class monte{
	public static (double,double) plainmc(Func<vector,double> f,vector a, vector b, int N){
		int dim = a.size; double V=1;
		for(int i=0; i<dim; i++){V*=b[i]-a[i];}
		double sum=0,sum2=0;
		//generating pseudo-random points
		var x = new vector(dim);
		var rnd = new Random();
		for(int i=0; i<N; i++){
			for(int k=0; k<dim; k++){x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);}
			double fx = f(x); sum+=fx; sum2+=fx*fx;
			} 
		double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;
		}

	public static (double,double) multiDmc(Func<vector,double> f,vector a, vector b, int N){
		int dim = a.size; double V=1;
		for(int i=0; i<dim; i++){V*=b[i]-a[i];}
		double sum=0,sum2=0;
		//using quasi random (Halton sequence) to generate points
		halton h1 = new halton(dim);
		halton h2 = new halton(dim+1); //using two sequences in order to estimate error
		vector x1 = new vector(dim);
		vector x2 = new vector(dim+1);
		for(int i=0; i<N; i++){
		vector xb1 = h1.xb(i);
		vector xb2 = h2.xb(i);
			for(int k=0; k<dim; k++){
				x1[k]=a[k]+xb1[k]*(b[k]-a[k]);//using the k'th element from the n'th halton point in stead of rnd.Random
				x2[k]=a[k]+xb2[k]*(b[k]-a[k]);
				}
			double fx1 =f(x1), fx2 =f(x2);
			sum+=fx1+fx2; sum2+=fx1*fx1+fx2*fx2; 
			}
		double mean=sum/(2*N), sigma=Sqrt(sum2/(2*N)-mean*mean);
		var result = (mean*V,sigma*V/Sqrt(2*N));
		return result;
		}
}
