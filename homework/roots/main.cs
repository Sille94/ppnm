using System;
using static System.Math;
using static System.Console;
static class main{
	public static void Main(){
		double tol_t = 1e-2;
		WriteLine("test one-dimentional eqation x/3+2=0");
		vector x0_t1 = new vector("1");
		Func<vector,vector> f_t1= x => {vector y = new vector(1); y[0] = x[0]/3+2; return y;};
		vector x_t1 = roots.newton(f_t1,x0_t1,tol_t);	
		WriteLine($"result x = {x_t1[0]}");
		WriteLine($"f(x)={(int)f_t1(x_t1)[0]}");
		WriteLine("");
		WriteLine("test two-dimentional equation x/3+2=0,x+2*y=0");
		vector x0_t2 = new vector("1,1");
		Func<vector,vector> f_t2= x =>{vector y = new vector(2);y[0]=x[0]/3+2;y[1]=x[0]+2*x[1]; return y;};
		vector x_t2 = roots.newton(f_t2,x0_t2,tol_t);		
		WriteLine($"result x = {x_t2[0]}, y={x_t2[1]}");
		WriteLine($"f(x,y)={(int)f_t2(x_t2)[0]},{(int)f_t2(x_t2)[1]}"); 
		WriteLine("");
		double tol = 1e-6;
		WriteLine($"Rosenbrock's valley function");
		WriteLine("Gradient: d/dx = 400x^3-400xy-2x, d/dy = 200y-200x^2");
		Func<vector,vector> rv = x =>{
			vector res = new vector(2);
			res[0] = 400*x[0]*x[0]*x[0]-400*x[0]*x[1]-2*x[0];
			res[1] = 200*x[1]-200*x[0]*x[0];
			return res;
			};
		vector x0_rv = new vector("1,1");
		vector x_rv = roots.newton(rv,x0_rv,tol);
		WriteLine($"roots ={x_rv[0]},{x_rv[1]}");
		WriteLine($"rv(x,y)={rv(x_rv)[0]},{rv(x_rv)[1]}");
		WriteLine("");
		WriteLine("Himmelblau's function");
		WriteLine("Gradient: d/dx =4x^3+4xy-42x+2y^2-14, d/dy = 2x^2+4xy+4y^3-26y-22");	
		Func<vector,vector> hb = x =>{
			vector res = new vector(2);
			res[0] = 4*x[0]*x[0]*x[0]+4*x[0]*x[1]-42*x[0]+2*x[1]*x[1]-14;
			res[1] = 2*x[0]*x[0]+4*x[0]*x[1]+4*x[1]*x[1]*x[1]-26*x[1]-22;
			return res;
			};
		vector x0_hb = new vector("1,1");
		vector x_hb = roots.newton(hb,x0_hb,tol);
		WriteLine($"roots = {x_hb[0]},{x_hb[1]}");
		WriteLine($"hb(x,y)={hb(x_hb)[0]},{hb(x_hb)[1]}");
		}
}
