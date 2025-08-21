out.txt: main.exe
	mono main.exe > out.txt
	cat out.txt
	gnuplot plt.gpi

main.exe: montecarlo.dll vector.dll main.cs
	mcs -target:exe -out:main.exe -reference:montecarlo.dll,vector.dll main.cs

montecarlo.dll: vector.dll halton.dll montecarlo.cs
	mcs -target:library -out:montecarlo.dll -reference:vector.dll,halton.dll montecarlo.cs

halton.dll:vector.dll halton.cs
	mcs -target:library -out:halton.dll -reference:vector.dll halton.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
