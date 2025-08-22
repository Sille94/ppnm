using System;
using static System.Math;
using static System.Console;
static class main{
	public static void Main(){
		//Doing some debugging
		WriteLine("");
		WriteLine("Part A");
		WriteLine("test one-dimentional eqation x/3+2=0");
		vector x0_t1 = new vector("1");
		Func<vector,vector> f_t1= x => {vector y = new vector(1); y[0] = x[0]/3+2; return y;};
		vector x_t1 = roots.newton(f_t1,x0_t1);	
		WriteLine($"result x = {x_t1[0]}");
		WriteLine($"f(x)={f_t1(x_t1)[0]}");
		WriteLine("");
		WriteLine("test two-dimentional equation x/3+2=0,x+2*y=0");
		vector x0_t2 = new vector("1,1");
		Func<vector,vector> f_t2= x =>{vector y = new vector(2);y[0]=x[0]/3+2;y[1]=x[0]+2*x[1]; return y;};
		vector x_t2 = roots.newton(f_t2,x0_t2);		
		WriteLine($"result x = ({x_t2[0]},{x_t2[1]})");
		WriteLine($"f(x,y)={f_t2(x_t2)[0]}"); 
		WriteLine("");
		//Start Part A
		WriteLine($"Rosenbrock's valley function");
		Func<vector,vector> rv = x =>{
			vector res = new vector(2);
			res[0] = -2*(1-x[0])-400*x[0]*(x[1]-x[0]*x[0]);
			res[1] = 200*(x[1]-x[0]*x[0]);
			return res;
			};
		
		vector x0_rv = new vector("0.3,0.3");
		vector x_rv = roots.newton(rv,x0_rv);
		WriteLine($"Initial guess: ({x0_rv[0]},{x0_rv[1]})");
		WriteLine($"Found Roots: ({x_rv[0]},{x_rv[1]})");
		WriteLine($"Norm f(x,y) = {rv(x_rv).norm()}");
		WriteLine("");
		WriteLine("Himmelblau's function");
		Func<vector,vector> hb = x =>{
			vector res = new vector(2);
			res[0] = 4*x[0]*(x[0]*x[0]+x[1]-11)+2*(x[0]+x[1]*x[1]-7);
			res[1] = 2*(x[0]*x[0]+x[1]-11)+4*x[1]*(x[0]+x[1]*x[1]-7);
			return res;
			};
		vector x0_hb = new vector("5,5");
		WriteLine($"Initial guess: ({x0_hb[0]},{x0_hb[1]})");
		vector x_hb = roots.newton(hb,x0_hb);
		WriteLine($"Found Roots: ({x_hb[0]},{x_hb[1]})");
		WriteLine($"Norm f(x,y)={hb(x_hb).norm()}");
		WriteLine("");
		WriteLine("Part B");
		
		double rmin = 1e-5;
		double rmax =  8;
		vector w0 = new vector(rmin-rmin*rmin,1-2*rmin);
		
		Func<double, double> M = E =>{
			(genlist<double> rs,genlist<vector> fr) = ode.driver(w(E),(rmin,rmax),w0);
			vector es= fr[rs.size-1];
			double e0 = es[0];
			return e0;
			};
		
		double E0 = roots.bisec(M,-1.0,-0.1,1e-6);
		WriteLine($"Shooting method ground state energy E0={E0}"); 
		WriteLine($"Expected: -0.5");
		WriteLine($"Plot of wavefunction can be viewed in wavefunction.svg");

		var outstrm = new System.IO.StreamWriter("wavefunct.txt");
		Func<double, vector, vector> wE = w(E0);//radial wavefunctions found with routine
		Func<double, double> f = r =>r*Exp(-r);//excact
		(genlist<double> Rs,  genlist<double> fs) = w_r(wE,(rmin,rmax),w0);
		for(int i=0; i<Rs.size; i++){
			outstrm.WriteLine($"{Rs[i]},{fs[i]},{f(Rs[i])}");
			}	
		outstrm.Close();

			
			}
		}

		public static (genlist<double>,genlist<double>) w_r(Func<double,vector,vector> we,(double,double)range,vector w0){
			(genlist<double> rs,genlist<vector>frs) =ode.driver(we,range,w0);
			genlist<double> fr = new genlist<double>();
			for(int i=0; i<rs.size;i++){fr.add(frs[i][0]);}
			return (rs,fr);
			}	
		
		public static Func<double, vector, vector> w(double E) => (r,f) =>{	
			double df = f[1];
			double d2f = -2*(E+1/r)*f[0];
			return new vector(df,d2f); 
			};
}

