public static class sfuns{
	static double pi = System.Math.PI;
	public static double fgamma(double x){
		if (x<0) return pi/sin(pi*x);
		if (x<9) return fgamma(x+1)/x;
		double lnfgamma = x*log(x+1/(12*x-1/x/10))-x+log(2*pi/x)/2;
		return exp(lnfgamma);
	}
	public static double lngamma(double x){
		if (x<0) return double.NaN;
		if (x<9) return lngamma(x+1)-log(x);
		double lng = x*log(x+1/(12*x-1/x/10))-x-log(2*pi/x)/2;
		return lng;
	}
	static double log(double x){return System.Math.Log(x);}
	static double sin(double x){return System.Math.Sin(x);}
	static double exp(double x){return System.Math.Exp(x);}

}
