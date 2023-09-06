# Setting up CI pipeline for a DotNet/GitHub project

- every branch has an action that on _push_:
  - `ci.yml`
  - _CI_
  - builds
  - tests
  - publishes coverage (to coveralls)
- `main` branch that has an action that on _opening a PR_:
  - pushes a `Debug` build to _github packages_
- `main` branch that has an action that on _push_:
  - `main-push.yml`
  - _push into main_
  - pushes a `Release` build to _nuget_ 
  
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

Let's add the `Floatingman.Common` to the project - later on we'll try to use alpha packages, but not today.

```sh
dotnet add Versioner package Floatingman.Common
```

### Configuring the Tests

Setup the tooling to generate `coverage.info` file.

```sh
dotnet add Versioner.Tests package coverlet.msbuild
```

> Don't forget to add the `TestResults/` to the `.gitignore` file.

### Versioning

```sh
dotnet tool install --global nbgv
export PATH="$PATH:/home/vscode/.dotnet/tools"
nbgv install
```
## Added Bonus

Adding a script that makes it dificult to **accidentally** push into main / master / something else.