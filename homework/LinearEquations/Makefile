Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: QR.dll matrix.dll vector.dll main.cs
	mcs -target:exe -out:main.exe -reference:QR.dll -reference:matrix.dll -reference:vector.dll main.cs

matrix.dll: vector.dll matrix.cs
	mcs -target:library -out:matrix.dll -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
QR.dll: matrix.dll vector.dll QR.cs
	mcs -target:library -out:QR.dll -reference:matrix.dll -reference:vector.dll QR.cs


