using static System.Console;
using System;
using System.Threading;
using System.Linq;
public class main{
	public static void Main(string[] args){
		int N = 0;
		foreach(string arg in args){
			var words = arg.Split(':');
			if(words[0] =="-terms") N =(int)double.Parse(words[1]);
			if(words[0] =="-task" && words[1]=="1"){
				double sum = 0;
				System.Threading.Tasks.Parallel.For(1,N+1, (int i) => sum+=1.0/i);
				WriteLine($"harmonic sum pitfalls task1 = {sum}");
			}
			if(words[0] =="-task" && words[1]=="2"){	
				var sum = new ThreadLocal<double>(()=>0, trackAllValues:true);
				System.Threading.Tasks.Parallel.For(1,N+1, (int i) => sum.Value+=1.0/i);
				double totalsum=sum.Values.Sum();
				WriteLine($"harmonic sum pitfalls task2 = {sum}");
			}
		}	
	}
}
