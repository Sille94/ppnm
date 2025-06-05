N=1e8
TIME = time --portability --append --output $@
Out.txt : main.exe
	>$@
	$(TIME) mono  $< -terms:$N -threads:1 >>$@
	$(TIME) mono  $< -terms:$N -threads:2 >>$@
	$(TIME) mono  $< -terms:$N -threads:3 >>$@
	$(TIME) mono  $< -terms:$N -threads:4 >>$@
	$(TIME) mono  $< -terms:$N -threads:5 >>$@

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs

