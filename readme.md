# Setting up Versioning in Dotnet

- every branch has an action that:
  - builds
  - tests
  - publishes coverage
- `main` branch that has a release action that:
  - pushes a `Release` build to _nuget_
- when a PR is opened into `main` an action:
  - pushes a `Debug` build to _github packages_
  
## Tools in Play

### Setup Initial DotNet

- **dotnet core** just because that's what it is

```sh
dotnet new sln --name Versioner
dotnet new classlib --name Versioner
dotnet new xunit --name Versioner.Tests
dotnet new console --name Versoner.Usage

dotnet sln add Versioner
dotnet sln add Versioner.Tests
dotnet sln add Versioner.Usage
```

_Update the `.gitignore` file to include the default .dotnet stuff._

### Actions

We brought in three github action definition files.

- `any-push.yml`
- `main-push.yml`
- `main-pr.yml`

They pretty much cover off the goals from above.

### Configuring the Build

## Configuring the Tests

Setup the tooling to generate `coverage.info` file.

```sh
dotnet add Versioner.Tests package coverlet.msbuild
```

> Don't forget to add the `TestResults/` to the `.gitignore` file.

## Added Bonus

Adding a script that makes it dificult to **accidentally** push into main / master / something else.