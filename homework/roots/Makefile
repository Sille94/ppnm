out.txt: main.exe
	mono main.exe > out.txt

main.exe: roots.dll vector.dll main.cs
	mcs -target:exe -reference:vector.dll,roots.dll main.cs

roots.dll: matrix.dll QR.dll vector.dll roots.cs
	mcs -target:library -reference:vector.dll,QR.dll,matrix.dll roots.cs

