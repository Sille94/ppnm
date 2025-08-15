out.txt: main.exe
	mono main.exe > out.txt

main.exe: mini.dll vector.dll main.cs
	mcs -target:exe -reference:vector.dll,mini.dll main.cs

mini.dll: matrix.dll QR.dll vector.dll mini.cs
	mcs -target:library -reference:vector.dll,QR.dll,matrix.dll mini.cs

