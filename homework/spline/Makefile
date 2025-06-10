out.txt: main.exe
	mono main.exe > out.txt

main.exe: spline.dll main.cs
	mcs -target:exe -out:main.exe -reference:spline.dll main.cs

spline.dll: spline.cs
	mcs -target:library -out:spline.dll spline.cs
