using static System.Console;
using static System.Math;

static class main{
	static int Main(){
		WriteLine("Create two Vectors");
		var rnd = new System.Random();
		var u = new vec(rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble());
		var v = new vec(rnd.NextDouble(),rnd.NextDouble(),rnd.NextDouble());
		WriteLine("Check Print Method");
		u.print("u=");
		v.print("v=");
		WriteLine($"v={v}");
		WriteLine($"v={v}");
		WriteLine();

		vec t;
		WriteLine("Check Vector Operators");
		WriteLine();
		WriteLine("crate vector t = -u");
		t = new vec(-u.x,-u.y,-u.z);
		(-u).print("-u=");
		t.print("t=");
		if(vec.approx(t,-u)) WriteLine("test 'unary -' passed");
		
		WriteLine();
		WriteLine("create vector t = v-u");
		t = new vec(v.x-u.x,v.y-u.y,v.z-u.z);
		(v-u).print("v-u=");
		t.print("t=");
		if(vec.approx(t,v-u)) WriteLine("test operator - passed");

		WriteLine();
		WriteLine("create vector t = u+v");
		t = new vec(u.x+v.x,u.y+v.y,u.z+v.z);
		(u+v).print("u+v=");
		t.print("t=");
		if(vec.approx(t,u+v))WriteLine("test operator + passed");

		WriteLine();
		WriteLine("create scalar c and vector t= u*c");
		double c = rnd.NextDouble();
		t = new vec(u.x*c,u.y*c,u.z*c);
		var tempt = u*c;
		tempt.print("u*c=");
		t.print("t=");
		if(vec.approx(t,u*c))WriteLine("test operator * passed");

		WriteLine();
		WriteLine("calculate d = u /dot v");
		var d = u.x*v.x+u.y*v.y+u.z*v.z;
		var tempd = vec.dot(u,v);
		WriteLine($"vec.dot(u,v)={tempd}");
	        WriteLine($"d={d}");
		if(approx(tempd,d))WriteLine("test vec.dot(u,v) method passed");
		tempd = u.dot(v);
		WriteLine($"u.dot(v)= {tempd}");
		if(approx(tempd,d))WriteLine("test u.dot(v) method passed");
			
		WriteLine();
		WriteLine("calculate t = u /cross v");
		t = new vec(u.y*v.z-u.z*v.y,u.z*v.x-u.x*v.z,u.x*v.y-u.y*v.x);
		t.print("t=");
		vec.cross(u,v).print("vec.cross(u,v)=");
		u.cross(v).print("u.cross(v)=");
		if(vec.approx(t,vec.cross(u,v)))WriteLine("test vec.cross(u,v) passed");
		if(vec.approx(t,u.cross(v)))WriteLine("test u.cross(v) passed");

		WriteLine();
		WriteLine("calculate d = ||u||");
		d = Sqrt(u.x*u.x+u.y*u.y+u.z*u.z);
		tempd = u.norm();
		WriteLine($"d={d}");
		WriteLine($"u.norm()={tempd}");
		if(approx(d,tempd))WriteLine("test u.norm() passed");
		tempd = vec.norm(u);
		WriteLine($"vec.norm(u)={tempd}");
		if(approx(d,tempd))WriteLine("test vec.norm(u) passed");
		
		return 0;
	}
	static bool approx(double a, double b){
		double acc = 1e-9;
		double eps = 1e-9;
		if(Abs(a-b) < acc) return true;
		if(Abs(b-a) < (Abs(a)+Abs(b))*eps) return true;
		return false;
	}
}
