## Description

This app was developed for the LaunchPad Vog App Developer's Code Challenge. This application is a .NET 6.0 Web API that manages Tic-Tac-Toe games with the use of three client-accessible endpoints. The endpoints and their functionality can be found in the documentation below.


## Installation and Run

1. Download/Clone the repository onto your development computer.
2. Ensure Docker Compose is installed on the development computer you use to run this project.
3. Run the following commands to build and run the docker container:

	docker-compose build
	docker-compose up
	
## Alternative Installation and Run

*This installation method should be used in the case that the development computer cannot run the Dockerfile configuration or cannot install Docker Compose*

1. Download/Clone the repository onto your development computer.
2. Unzip the Source File Folder
3. Ensure the .NET 6.0 SDK is installed
4. Install the following packages:
* 
5. Run the following commands inside the unzipped source file folder:

	dotnet run
	docker-compose up

## IMPORTANT NOTE

The API has been configured to host and listen on http://localhost:5000. Please ensure that all requests are sent to this address with their associated routes following.

## API Endpoints

Since Postman was used during the development of this program, it is suggested to use the Postman platform to perform endpoint connections, however, this is not mandatory. 

## Endpoint 1
The client can start and create new games with an expected response, including the game's unique game ID and the player IDs of the two players partaking in that game.
This endpoint takes in the parameters of the names of the two players starting that game.

*Method:* POST

*URL:*
http://localhost:5000/game

*URL Parameters:*
player1Name (ex: player1Name="Jack"), player2Name (ex: player2Name="Jack")

## Endpoint 2
The client can register moves for a player partaking in a game and receive information on the game's current progress. Appropriate errors are returned given invalid input. This endpoint takes in the parameters gameID.

*Method:* POST

*URL:*
http://localhost:5000/game/{gameid}/move

*URL Parameters:*
player1Name (ex: player1Name="Jack"), player2Name (ex: player2Name="Jack")

## Endpoint 3
The client can retrieve a list of the currently active Tic-Tac-Toe games taking place. Clients can also see information, such as the number of moves made in each active game and the players playing in those games.

##
