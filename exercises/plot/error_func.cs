using static System.Console;
using static System.Math;
static class main{
	static int Main(){
	for(double i = 0; i<0.1; i+=0.02){
	WriteLine($"{i},{erf(i)}");}
	for(double i =0.1; i<2.5; i+=0.1){
	WriteLine($"{i},{erf(i)}");}
	for(double i=2.5; i<4.0 ; i+=0.5){
	WriteLine($"{i},{erf(i)}");}
	return 0;}
static double erf(double x){
	if (x<0) return -erf(-x);
	double[] a={0.254829592,-0.284496736,1.4214131741,-1.4543152027, 1.061405429};
	double t=1/(1+0.3275911*x);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));
	return 1-sum*Exp(-x*x);
	}
} 
