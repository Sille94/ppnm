using static System.Array;

public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i];
	public genlist(){
		data = new T[0];
	}
	public void add(T item){
		T[] newdata = new T[size+1];
		Copy(data,newdata,size);
		newdata[size] = item;
		data = newdata;
	}
	public void remove(int i){
		T[] newdata = new T[size-1];
		for(int j=0; j < size; j++){
			if(j!=i)newdata[j]=data[j];
		}
		data = newdata;
	}		
}

