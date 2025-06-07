out.txt: main.exe 
	mono main.exe > out.txt

main.exe: EVD.dll matrix.dll vector.dll main.cs
	mcs -target:exe -out:main.exe -reference:EVD.dll,matrix.dll,vector.dll main.cs

EVD.dll: matrix.dll vector.dll EVD.cs
	mcs -target:library -out:EVD.dll -reference:matrix.dll,vector.dll EVD.cs 

matrix.dll: vector.dll matrix.cs
	mcs -target:library -out:matrix.dll -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs

