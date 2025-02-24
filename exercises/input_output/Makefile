Out.txt: main.exe
	echo 1 2 3 4 5 | mono main.exe 2> Out.txt
main.exe: main.cs
	mcs -target:exe -out:main.exe main.cs

