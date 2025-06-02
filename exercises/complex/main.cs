using static System.Console;
using System.Numerics;
public static class main{
	public static int Main(){
		var c = new Complex(-1,0);
		c =Complex.Sqrt(c);
		WriteLine($"sqr(-1)={c}");
		return 0;
	}
}

