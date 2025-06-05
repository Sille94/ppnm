Out.txt: cmdln.exe flstrm.exe stdin.exe
	@echo test 1
	mono cmdln.exe -numbers:1,2,3,4,5 > Out.txt
	@echo test 2
	echo "-numbers:1,2,3,4,5" > inputfile
	mono cmdln.exe $$(cat inputfile) >> Out.txt
	@echo test 3
	echo 1 2 3 4 5 | mono stdin.exe 2>> Out.txt
	@echo test 4
	echo 1 2 3 4 5 > input.txt
	mono stdin.exe < input.txt 2>> Out.txt
	@echo test 5
	cat input.txt | mono stdin.exe 2>> Out.txt
	@echo test 6
	mono flstrm.exe -input:input.txt -output:Out.txt

cmdln.exe: cmdln.cs
	mcs -target:exe -out:cmdln.exe cmdln.cs
flstrm.exe: flstrm.cs
	mcs -target:exe -out:flstrm.exe flstrm.cs
stdin.exe: stdin.cs
	mcs -target:exe -out:stdin.exe stdin.cs

