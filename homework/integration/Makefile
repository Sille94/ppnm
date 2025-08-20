out.txt: main.exe
	mono main.exe > out.txt
	cat out.txt
	gnuplot plt.gpi

main.exe:integration.dll main.cs
	mcs -target:exe -out:main.exe -reference:integration.dll main.cs

integration.dll:integration.cs
	mcs -target:library -out:integration.dll integration.cs

clean:
	rm -f out.txt
