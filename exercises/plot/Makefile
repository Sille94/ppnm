default: Out_err.txt Out_gm.txt

Out_err.txt: error_func.exe
	mono error_func.exe > Out_err.txt
Out_gm.txt: gamma_func.exe
	mono gamma_func.exe > Out_gm.txt
error_func.exe: error_func.cs
	mcs -target:exe -out:error_func.exe error_func.cs
gamma_func.exe: gamma_func.cs
	mcs -target:exe -out:gamma_func.exe gamma_func.cs

