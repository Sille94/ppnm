Out.txt:  main.exe
	mono main.exe > Out.txt
mac_eps.dll: mac_eps.cs
	mcs -target:library -out:mac_eps.dll mac_eps.cs
main.exe: main.cs mac_eps.dll
	mcs -target:exe -out:main.exe -reference:mac_eps.dll main.cs

