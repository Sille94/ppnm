out.txt: main.exe
	mono main.exe > out.txt
	gnuplot plt.gpi
	cat out.txt
	
main.exe: ann.dll vector.dll main.cs
	mcs -target:exe -reference:ann.dll,vector.dll main.cs

ann.dll: vector.dll mini.dll
	mcs -target:library -reference:vector.dll,mini.dll ann.cs
mini.dll: vector.dll matrix.dll QR.dll mini.cs
	mcs -target:library -reference:vector.dll,matrix.dll,QR.dll mini.cs
clean: 
	rm -f out.txt
