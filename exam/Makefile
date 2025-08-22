outB.txt: mainB.exe 
	mono mainB.exe > outB.txt
	cat outB.txt


mainC.exe:GEV.dll matrix.dll vector.dll mainC.cs
	mcs -target:exe -out:mainC.exe -reference:GEV.dll,matrix.dll,vector.dll mainC.cs

mainB.exe:hydrogen.dll GEV.dll matrix.dll vector.dll mainB.cs
	mcs -target:exe -out:mainB.exe -reference:hydrogen.dll,GEV.dll,matrix.dll,vector.dll mainB.cs

mainA.exe: GEV.dll matrix.dll vector.dll mainA.cs
	mcs -target:exe -out:mainA.exe -reference:GEV.dll,matrix.dll,vector.dll mainA.cs

hydrogen.dll: matrix.dll vector.dll GEV.dll mini.dll hydrogen.cs
	mcs -target:library -out:hydrogen.dll -reference:matrix.dll,vector.dll,GEV.dll,mini.dll hydrogen.cs

EVD.dll: matrix.dll vector.dll EVD.cs
	mcs -target:library -out:EVD.dll -reference:matrix.dll,vector.dll EVD.cs 

GEV.dll: QR.dll EVD.dll matrix.dll vector.dll GEV.cs
	mcs -target:library -out:GEV.dll -reference:QR.dll,EVD.dll,matrix.dll,vector.dll GEV.cs

QR.dll: vector.dll matrix.dll QR.cs
	mcs -target:library -out:QR.dll -reference:vector.dll,matrix.dll QR.cs
matrix.dll: vector.dll matrix.cs
	mcs -target:library -out:matrix.dll -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
clean:
	rm -f outC.txt

