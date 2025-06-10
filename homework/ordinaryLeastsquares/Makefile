out.txt: main.exe 
	mono main.exe > out.txt

main.exe: leastsq.dll QR.dll matrix.dll vector.dll main.cs
	mcs -target:exe -out:main.exe -reference:leastsq.dll,QR.dll,matrix.dll,vector.dll main.cs

leastsq.dll: QR.dll matrix.dll vector.dll leastsq.cs
	mcs -target:library -out:leastsq.dll -reference:QR.dll,matrix.dll,vector.dll leastsq.cs

QR.dll: matrix.dll vector.dll QR.cs
	mcs -target:library -out:QR.dll -reference:matrix.dll,vector.dll QR.cs

matrix.dll: vector.dll matrix.cs
	mcs -target:library -out:matrix.dll -reference:vector.dll matrix.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs

