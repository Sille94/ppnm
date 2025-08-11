out.txt: main.exe
	mono main.exe > out.txt

main.exe: montecarlo.dll vector.dll main.cs
	mcs -target:exe -out:main.exe -reference:montecarlo.dll,vector.dll main.cs

montecarlo.dll: vector.dll montecarlo.cs
	mcs -target:library -out:montecarlo.dll -reference:vector.dll montecarlo.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
