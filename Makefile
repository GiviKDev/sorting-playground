.PHONY: run build clean rebuild format format-check pre-commit

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

format-check:
	dotnet format --severity info --verify-no-changes

pre-commit: format-check build
