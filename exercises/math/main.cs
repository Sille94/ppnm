public static class main{
	static double x = 2;
	static double y = 1/5;
	static double pi = System.Math.PI;
	static double e = System.Math.E;
	public static int Main(){
		System.Console.Write("1. Simple Math\n");
		double a = sqrt(x);
		System.Console.Write($"Tjek sqrt(2)^2 ={a*a} sould equal {x}\n");
		double b = pow(x,y);
		double tjek_b = pow(b,5);
		System.Console.Write($"Tjek (2^1/5)^5 = {tjek_b} should equal 1\n");
		double c = exp(pi);		
		double tjek_c = System.Math.Log(c);
		System.Console.Write($"Tjek ln(exp(pi)) = {tjek_c} should equal {pi}\n");
		double d = pow(pi,e);
		System.Console.Write($"pi^e = {d} sould equal 22.45\n");
		System.Console.Write("2. Gamma Function and 3. log Gamma function\n");
		for (double i=1;i<=10;i++){
			double g=sfuns.fgamma(i);
			double lng = sfuns.lngamma(i);
			System.Console.Write($"gamma({i})={g}\n");
			System.Console.Write($"lngamma({i})={lng} eqals approx ln({g})={log(g)}\n");
		}
		return 0;
	}
	static double sqrt(double n){
		double r = System.Math.Sqrt(n);
		return r;
	}
	static double pow(double x, double y){
		double r = System.Math.Pow(x,y);
		return r;
	}
	static double exp(double n){
		double r = System.Math.Exp(n);
		return r;
	}
	static double log(double n){
		double r = System.Math.Log(n);
		return r;
	}
}
		
