out.txt: main.exe
	mono main.exe > out.txt
	gnuplot plt.gpi
	cat out.txt

main.exe:ode.dll genlist.dll roots.dll vector.dll main.cs
	mcs -target:exe -reference:ode.dll,genlist.dll,vector.dll,roots.dll main.cs

roots.dll: matrix.dll QR.dll vector.dll roots.cs
	mcs -target:library -reference:vector.dll,QR.dll,matrix.dll roots.cs
clean:
	rm -f out.txt
