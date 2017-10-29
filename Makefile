dotnet.build:
	dotnet build	

fortran.build:
	gfortran -shared -fPIC main.f90 -o bin/Debug/netcoreapp2.0/libmain.so

run:
	sudo dotnet run

build: dotnet.build fortran.build 

all: build run
