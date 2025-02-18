public static class main{
	public static int Main(){
		MachineEps.min_max();
		MachineEps.mach_eps();
		MachineEps.tiny_eps();
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;
		System.Console.WriteLine($"d1 = {d1:e15}");
		System.Console.WriteLine($"d2 = {d2:e15}");
		System.Console.WriteLine($"d1 == d2 = {d1==d2}");
		bool approx = MachineEps.approx(d1,d2);
		System.Console.WriteLine($"approx d1==d2 = {approx}");	
		return 0;
	}
}
