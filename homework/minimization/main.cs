using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		WriteLine("Part A");	
		WriteLine("Rosenbrock's valley function");
		Func<vector, double> rv = x =>{return Pow(1-x[0],2)+100*Pow(x[1]-Pow(x[0],2),2);};
		vector x0_rv = new vector("100,100");
		(vector x_rv, int count1) = mini.newton(rv,x0_rv);
		if(count1<10001){
			WriteLine($"minimum found at rv({x_rv[0]},{x_rv[1]}), expected at (1,1)");
			WriteLine($"with {count1} iterations");
			}
		WriteLine("");
		WriteLine("Himmelblau's function");
		Func<vector,double> hb = x =>{return Pow(Pow(x[0],2)+x[1]-11,2)+Pow(x[0]+Pow(x[1],2)-7,2);};
		vector x0_hb = new vector("50,50");
		(vector x_hb, int count2) = mini.newton(hb,x0_hb);
			if(count2<10001){
				WriteLine($"minimum found at hb({x_hb[0]},{x_hb[1]}), expectet at (3,2), (-2.8,3.13), (-3.78,-3.28) or (3.58,-1.85)");
				WriteLine($"with {count2} iterations");
				}
		WriteLine("Part B");
		//loading data from file
		var energy = new genlist<double>();
		var signal = new genlist<double>();
		var error = new genlist<double>();
		var separators = new char[] {' ','\t',','};
		var options = StringSplitOptions.RemoveEmptyEntries;
		do{
			string line=Console.In.ReadLine();
			if(line==null)break;
			string[] words = line.Split(separators,options);
			energy.add(double.Parse(words[0]));
			signal.add(double.Parse(words[1]));
			error.add(double.Parse(words[2]));
			}while(true);
		Func<vector, double> bw = p =>{//The Breit-Winger function
			double E = p[0];//energy
			double m = p[1];//mass
			double G = p[2];//width
			double A = p[3];//amplitude
			return A/(Pow(E-m,2)+Pow(G,2)/4);
			};
		Func<vector, double> deviation = p =>{//The Deviation function
			double m=p[0];
			double G=p[1];
			double A=p[2];
			double sum=0;
			for(int i=0; i<energy.size; i++){
				vector paramE = new vector(energy[i],m,G,A);
				sum+=Pow((bw(paramE)-signal[i])/error[i],2);
				}
			return sum;
			};
		double m_guess = 125;
		double g_guess = 7;
		double A_guess = 60;
		vector init = new vector(m_guess,g_guess,A_guess);
		WriteLine($"Minimizing with initial guess m={m_guess}, Gamma={g_guess}, A={A_guess}");
		(vector fit_param, int count) =mini.newton(deviation,init);
		WriteLine($"Found with {count} itarations, parameters for Higgs are m={fit_param[0]}, Gamma = {fit_param[1]}, A={fit_param[2]}");
		var outstrm = new System.IO.StreamWriter("higgs_fit.txt");
		//creating fit
		int n = 100;
		double step =(double)(159-101)/(double)(n-1);
		double fit_m = fit_param[0];
		double fit_G = fit_param[1];
		double fit_A = fit_param[2];
		vector es = new vector(n);
		for(int i=0; i<n; i++){es[i]=100+i*step;}
		for(int i=0; i<n; i++){
			vector param = new vector(es[i],fit_m,fit_G,fit_A);
			//vector param = new vector(es[i],125,7,66);
			outstrm.WriteLine($"{es[i]},{bw(param)}");
			}	
		outstrm.Close();
		}
}
