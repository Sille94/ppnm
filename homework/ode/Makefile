out.txt:  main.exe
	mono main.exe > out.txt 
	gnuplot ode.gpi
	gnuplot orbit.gpi
	cat out.txt

main.exe:genlist.dll vector.dll ode.dll main.cs
	mcs -target:exe -out:main.exe -reference:genlist.dll,vector.dll,ode.dll main.cs

ode.dll: vector.dll genlist.dll ODE.cs
	mcs -target:library -out:ode.dll -reference:vector.dll,genlist.dll ODE.cs

vector.dll: vector.cs
	mcs -target:library -out:vector.dll vector.cs
genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

clean: 
	rm -f out.txt
