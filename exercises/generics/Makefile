Out.txt: main.exe
	echo 1	2 3   5| mono main.exe 1> Out.txt

genlist.dll: genlist.cs
	mcs -target:library -out:genlist.dll genlist.cs

main.exe: main.cs genlist.dll
	mcs -target:exe -out:main.exe -reference:genlist.dll main.cs




