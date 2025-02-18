public static class MachineEps{
	public static void min_max(){
		int i = 1;
		while(i+1>i){i++;}
		System.Console.Write($"max int = {i} should equal 2147483647\n");
		int j = 1;
		while(j-1<j){j--;}
		System.Console.Write($"min int = {j} should equal -2147483648\n");
	}
	public static void mach_eps(){
		double x=1;
		while(x+1!=1){x/=2;}x*=2;
		System.Console.Write($"double Machine Eps = {x} should be about {System.Math.Pow(2,-52)}\n");
		float y =1f;
		while((float)(1f+y)!=1){y/=2f;}y*=2f;
		System.Console.Write($"float Machine Eps = {y} should be about {System.Math.Pow(2,-23)}\n");
	}
	public static void tiny_eps(){
		double eps = System.Math.Pow(2,-52);
		double tiny = eps/2;
		System.Console.Write($"tiny = eps/2 =  {tiny}\n");
		double a = tiny+tiny+1;
		double b = 1+tiny+tiny;
		System.Console.Write($"a = tiny+tiny+1 = {a:e15}\n");
		System.Console.Write($"b = 1+tiny+tiny = {b:e15}\n");
		System.Console.Write($"a==b {a==b}\n");
		System.Console.Write($"a>1 {a>1}\n");
		System.Console.Write($"b>1 {b>1}\n");

	}
	public static bool approx(double a,double b){
		double acc = 1e-9;
		double eps = 1e-9;
		double abs_ab = System.Math.Abs(a-b);
		double abs_a = System.Math.Abs(a);
		double abs_b = System.Math.Abs(b);
		if (abs_ab <= acc) return true;
		if (abs_ab <= System.Math.Max(abs_a,abs_b)*eps) return true;
		return false;
		}
}

