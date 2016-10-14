
run: DynamicLinq/bin/Debug/DynamicLinq.exe
	@#@mono $<

DynamicLinq/bin/Debug/DynamicLinq.exe: DynamicLinq/Program.cs
	@xbuild DynamicLinq.sln
