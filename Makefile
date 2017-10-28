dotnet.build:
	dotnet build	

fortran.build:
	gfortran -shared -fPIC test.f90 -o bin/Debug/netcoreapp2.0/libtest.so

all: dotnet.build fortran.build

run:
	dotnet run
