outB.txt: mainB.exe 
	mono mainB.exe > outB.txt
	gnuplot plt.gpi
	cat outB.txt

mainB.exe:hamil.dll EVD.dll matrix.dll vector.dll mainB.cs
	mcs -target:exe -out:mainB.exe -reference:hamil.dll,EVD.dll,matrix.dll,vector.dll mainB.cs

hamil.dll: matrix.dll vector.dll EVD.dll hamil.cs
	mcs -target:library -out:hamil.dll -reference:matrix.dll,vector.dll,EVD.dll hamil.cs

EVD.dll: matrix.dll vector.dll EVD.cs
	mcs -target:library -out:EVD.dll -reference:matrix.dll,vector.dll EVD.cs 

matrix.dll: vector.dll matrix.cs
	mcs -target:library -out:matrix.dll -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
clean:
	rm -f outB.txt
