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

- **dotnet core** just because that's what it is
- 

## Added Bonus

Adding a script that makes it dificult to **accidentally** push into main / master / something else.