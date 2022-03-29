## Author
Emmanuel Omari-Osei

## Description

This app was developed for the LaunchPad Vog App Developer's Code Challenge. This application is a .NET 6.0 Web API that manages Tic-Tac-Toe games with the use of three client-accessible endpoints. The endpoints and their functionality can be found in the documentation below.

## Install and Run

1. Download/Clone the repository onto your development computer.
2. Ensure Docker Compose is installed on the development computer you use to run this project.
3. Run the following commands to build and run the docker container:<br />
`docker-compose build`<br />
`docker-compose up`<br />
	
## Alternate Install and Run

*This installation method should be used in the case that the development computer cannot run the Dockerfile configuration or cannot install Docker Compose*

1. Download/Clone the repository onto your development computer.
2. Unzip the Source File Folder
3. Ensure the .NET 6.0 SDK is installed
5. Install the following dotnet packages using:
`dotnet add package <PackageName>`
* AutoMapper Version 10.1.1
* AutoMapper.Extensions.Microsoft.DependencyInjection Version 8.1.1
* Microsoft.EntityFrameworkCore Version 6.0.3
* Microsoft.EntityFrameworkCore.Design Version 6.0.3
* Microsoft.EntityFrameworkCore.Sqlite Version 6.0.3
* Microsoft.Extensions.Configuration Version 6.0.1
* Swashbuckle.AspNetCore Version 6.2.3
* System.Data.SQLite.Core Version 1.0.115.5
5. Run the following command inside the unzipped source file folder: `dotnet run`

## IMPORTANT NOTE

The API has been configured to host and listen on http://localhost:5000. Please ensure that all requests are sent to this address with their associated routes following.

## API Endpoints

Since Postman was used during the development of this program, it is suggested to use the Postman platform to perform endpoint connections, however, this is not mandatory. 

### Endpoint 1
The client can start and create new games with an expected response, including the game's unique game ID and the player IDs of the two players partaking in that game.
This endpoint takes in the parameters of the names of the two players starting that game.

*Method:* POST

*URL:*
http://localhost:5000/game

*URL Parameters:*
player1Name (ex: player1Name="Jack"),<br />
player2Name (ex: player2Name="Jill")

#### Example Success Response:
```
{
    "gameID": 25,
    "status": 0,
    "player1ID": 15,
    "player2ID": 16,
    "playerTurn": 15
}
```

### Endpoint 2
The client can register moves for a player partaking in a game and receive information on the game's current progress. Appropriate errors are returned given invalid input. This endpoint takes in the parameters gameID.

*Method:* POST

*URL:*
http://localhost:5000/game/{gameID}/move

*URL Parameters:*
gameID (Included in Head URL) (ex: 19)<br />
row (ex: row=0)
column (ex: column=1)
playerID (ex: playerID=5)

#### Example Success Response
```
{
    "moveInfo": "New Move at (1,1) registered for Player 1 in Game #23",
    "board_Row0": "|O|*|*|",
    "board_Row1": "|*|X|*|",
    "board_Row2": "|*|*|X|",
    "gameStatus": "Game Still In Progress...",
    "nextTurn": 12
}
```

### Endpoint 3
The client can retrieve a list of the currently active Tic-Tac-Toe games taking place. Clients can also see information, such as the number of moves made in each active game and the players playing in those games.

*Method:* GET

*URL:*
http://localhost:5000/game

*URL Parameters:*
None

#### Example Success Response
```
[
    {
        "game": {
            "gameID": 23,
            "status": 0,
            "player1ID": 11,
            "player2ID": 12,
            "playerTurn": 11
        },
        "numberOfMoves": 2,
        "player1Name": "Player 1",
        "player2Name": "Player 2",
        "gameRow0": "|O|*|*|",
        "gameRow1": "|*|*|*|",
        "gameRow2": "|*|*|X|"
    },
    {
        "game": {
            "gameID": 24,
            "status": 0,
            "player1ID": 13,
            "player2ID": 14,
            "playerTurn": 13
        },
        "numberOfMoves": 2,
        "player1Name": "Jacob",
        "player2Name": "Yasmin",
        "gameRow0": "|*|X|*|",
        "gameRow1": "|*|*|*|",
        "gameRow2": "|*|*|O|"
    }
]
```
