# Get base SDK from Microsoft:
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /Tic-Tac-Toe-API

# Copy .csproj and restore any dependencies:
COPY *.csproj ./
RUN dotnet restore

# Copy the project files:
COPY . ./
RUN dotnet publish -c Release -o out

# Generate Docker Runtime Image:
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /Tic-Tac-Toe-API
EXPOSE 80
COPY --from=build-env /Tic-Tac-Toe-API/out .
ENTRYPOINT [ "dotnet", "TicTacToeAPI.dll" ]