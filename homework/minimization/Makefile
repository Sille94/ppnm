out.txt: main.exe
	mono main.exe<higgs_data.txt 1> out.txt 2> log
	gnuplot plt.gpi
	cat out.txt

main.exe:genlist.dll mini.dll vector.dll main.cs
	mcs -target:exe -reference:genlist.dll,vector.dll,mini.dll main.cs

mini.dll: matrix.dll QR.dll vector.dll mini.cs
	mcs -target:library -reference:vector.dll,QR.dll,matrix.dll mini.cs

clean:
	rm -f out.txt
