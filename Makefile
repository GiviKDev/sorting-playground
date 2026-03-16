.PHONY: run build clean rebuild format

run:
	dotnet run --project SortingPlayground

build:
	dotnet build SortingPlayground

clean:
	dotnet clean SortingPlayground
	rm -rf SortingPlayground/bin SortingPlayground/obj

rebuild: clean build

format:
	dotnet format SortingPlayground --severity info
