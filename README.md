# Conway's Game of Life

## Install

To start working with Game of Life firstly you need to install [.NET SDK](https://learn.microsoft.com/en-us/dotnet/core/install/) (platform dependent).

Example (Ubuntu 20.04):
```
$ wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
  sudo dpkg -i packages-microsoft-prod.deb && \
  rm packages-microsoft-prod.deb && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0
```

## Usage

All commands should be executed in the root of repository directory.

Restore dependencies and build all solution:
```
$ dotnet build
```

Run tests:
```
$ dotnet test
```

Run the Game (input configuration file must be named "input.txt" and placed in the root of repository):
```
$ dotnet run --project GameOfLife.ConsoleHost/GameOfLife.ConsoleHost.csproj
```

## Author

Ivan Baturkin IP-03 student
