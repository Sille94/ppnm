using System;
using System.Collections.Generic;
using static System.Console;
using static System.Math;

public class halton{
	List<int> bases; 
	int dim;
	public halton(int d){//constuctor
		dim = d;
		bases = prime_numbers(dim);
		}
	public vector xb(int n){
		vector x = new vector(dim);
		for(int i=0; i<dim; i++){
			x[i]=corput(n,bases[i]);
			}
		return x;
		}	
	
	private List<int> prime_numbers(int n){//creating a list of the first n primenumbers
		List<int> primes= new List<int>(); int cand = 2;
		while(primes.Count <n){	
			bool isPrime = true;
			foreach(int p in primes){
				if(p*p>cand) break;
				if(cand%p==0){isPrime=false;break;}
				}
			if(isPrime) primes.Add(cand);
			cand++;
			}
		return primes;
		}
	
	private double corput(int n, int b=2){
		double q=0,bk=1.0/b;
		while(n>0){
			q+= n % b*bk;
			n/=b;
			bk/=b;
			}
		return q;
		} 
}
