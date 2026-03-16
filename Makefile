.PHONY: run build clean rebuild format

run:
	dotnet run --project SortingPlayground

build:
	dotnet build

clean:
	dotnet clean
	rm -rf SortingPlayground/bin SortingPlayground/obj

rebuild: clean build

format:
	dotnet format --severity info
