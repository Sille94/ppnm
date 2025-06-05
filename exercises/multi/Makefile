N=1e8
TIME = time --portability --append --output $@
Out.txt : main.exe ptfll.exe
	>$@
	$(TIME) mono main.exe -terms:$N -threads:1 >>$@
	$(TIME) mono main.exe -terms:$N -threads:2 >>$@
	$(TIME) mono main.exe -terms:$N -threads:3 >>$@
	$(TIME) mono main.exe -terms:$N -threads:4 >>$@
	$(TIME) mono ptfll.exe -terms:$N -task:1 >>$@
	$(TIME) mono ptfll.exe -terms:$N -task:2 >>$@

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs
ptfll.exe: pitfall.cs
	mcs -target:exe -out:ptfll.exe pitfall.cs
