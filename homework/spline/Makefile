out.txt: main.exe
	mono main.exe > out.txt

main.exe: vector.dll spline.dll qspline.dll main.cs
	mcs -target:exe -out:main.exe -reference:vector.dll,spline.dll,qspline.dll main.cs

spline.dll: spline.cs
	mcs -target:library -out:spline.dll spline.cs

qspline.dll: vector.dll qspline.cs
	mcs -target:library -out:qspline.dll -reference:vector.dll qspline.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs

