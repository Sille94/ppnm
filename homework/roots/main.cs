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
		}
}
