using static System.Console;
using System;
using System.Threading;

public class data {public int a,b; public double sum;}
public class main{
	public static void harm(object obj){
		var arg = (data)obj;
		arg.sum = 0;
		for(int i=arg.a; i<arg.b; i++)arg.sum+=1.0/i;
	}
	public static void Main(string[] args){
		int nthreads = 1, nterms = (int)1e8;
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-threads") nthreads = int.Parse(words[1]);
			if(words[0]=="-terms") nterms = (int)double.Parse(words[1]);
		}
		data[] param =  new data[nthreads];
		for(int i=0; i<nthreads; i++){
			param[i] = new data();
			param[i].a = 1+nterms/nthreads*i;
			param[i].b = 1+nterms/nthreads*(i+1);
		}
		param[param.Length-1].b=nterms+1;
		var threads = new Thread[nthreads];
		for(int i=0; i<nthreads; i++){
			threads[i] = new Thread(harm);
			threads[i].Start(param[i]);
		}
		foreach(var thread in threads) thread.Join();
		double total=0; foreach(var p in param) total+=p.sum;
		WriteLine($"harmonic sum ={total} with {nthreads} threads");
	}	
}
