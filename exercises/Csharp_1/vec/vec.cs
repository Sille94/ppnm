using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z; //vector componments
	public vec(){x=y=z=0;} //default constructor
	public vec(double x, double y, double z){ //parameterized constructor
		this.x=x;
		this.y=y;
		this.z=z;
	}
	//C# operators:
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x,u.y+v.y,u.z+v.z);}
	public static vec operator-(vec u){return new vec(-u.x,-u.y,-u.z);}
	public static vec operator-(vec u, vec v){v = -v; return u+v;}
	public static vec operator*(vec v, double c){return new vec(c*v.x,c*v.y,c*v.z);}
	public static vec operator*(double c, vec v){return v*c;}
	public static vec operator/(vec v, double c){c = 1/c; return v*c;}
	//Print Method
	public void print(string s=""){Write(s);WriteLine($"{x} {y} {z}");}
	//dot,cross and norm
	public double dot(vec other) => this.x*other.x+this.y*other.y+this.z*other.z;
	public static  double dot(vec v, vec w) => v.x*w.x+v.y*w.y+v.z*w.z;
	public double norm() => Sqrt(this.x*this.x+this.y*this.y+this.z*this.z);
	public static double norm(vec v) => Sqrt(v.x*v.x+v.y*v.y+v.z*v.z);
	public vec cross(vec other) => new vec(this.y*other.z-this.z*other.y,this.z*other.x-this.x*other.z,this.x*other.y-this.y*other.x);
	public static vec cross(vec v, vec w) => new vec(v.y*w.z-v.z*v.y,v.z*w.x-v.x*w.z,v.x*w.y-w.x*v.y);
	// Compare two vectors
	static bool approx(double a, double b){
		double acc = 1e-9;
		double eps = 1e-9;
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}
	public bool approx(vec other){
		if(!approx(this.x,other.x)) return false;
		if(!approx(this.y,other.y)) return false;
		if(!approx(this.z,other.z)) return false;
		return true;
	}
	public static bool approx(vec v, vec w){
		if(!approx(v.x,w.x)) return false;
		if(!approx(v.y,w.y)) return false;
		if(!approx(v.z,w.z)) return false;
		return true;
	}
	public override string ToString() =>$"{x} {y} {z}";
		
}
