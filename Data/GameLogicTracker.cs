using TicTacToeAPI.Models;

namespace TicTacToeAPI.Data
{
    public class GameLogicTracker
    {
        private static char[,] board;

        /** <summary> (Helper Function) Populates board with values for the game and moves selected. </summary> **/
        /** <returns> Boolean depicting if the board is full of player marked spots (which if so is true). </summary> **/
        private static bool populateBoard(Game game, List<Move> moves)
        {
            board = new char[3,3];

            // Fill player marked board spots:
            foreach (Move m in moves)
            {
                if (m.Player.playerID == game.player1ID)
                {
                    board[m.row, m.column] = 'X';
                }
                else if (m.Player.playerID == game.player2ID)
                {
                    board[m.row, m.column] = 'O';
                }
            }

            // Fill empty board spots:
            bool isFull = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] != 'X' && board[i,j] != 'O')
                    {
                        board[i,j] = '*';
                        isFull = false;
                    }
                }
            }

            return isFull;
        }

        /** <summary>
            Updates given game entity with appropriate status for the moves made.
        </summary> **/
        public static int GetGameStatus(Game game, List<Move> moves)
        {
            // Populate board and store whether or not the board is full:
            bool isFull = populateBoard(game, moves);

            // Check Rows for a Win:
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] == '*') continue;
                char storedElementA = board[i,0];
                bool foundWinner = true;

                for (int j = 1; j < 3; j++)
                {
                    if (storedElementA != board[i,j])
                    {
                        foundWinner = false;
                        break;
                    }
                }

                if (foundWinner)
                {
                    if (storedElementA == 'X') return 1;
                    else return 2;
                }
                else
                {
                    continue;
                }
            }

            // Check Columns for a Win:
            for (int i = 0; i < 3; i++)
            {
                if (board[0,i] == '*') continue;
                char storedElementB = board[0,i];
                bool foundWinner = true;

                for (int j = 1; j < 3; j++)
                {
                    if (storedElementB != board[j,i])
                    {
                        foundWinner = false;
                        break;
                    }
                }

                if (foundWinner)
                {
                    if (storedElementB == 'X') return 1;
                    else return 2;
                }
                else
                {
                    continue;
                }
            }

            // Check Descending Diagonal for a Win:
            char storedElementC = board[0,0];
            bool foundWinnerC = true;
            for (int i = 1; i < 3; i++)
            {
                if (board[i,i] != storedElementC) 
                {
                    foundWinnerC = false;
                    break;
                }
            }
            if (foundWinnerC)
            {
                if (storedElementC == 'X') return 1;
                else if (storedElementC == 'O') return 2;
            }
            
            // Check Ascending Diagonal for a Win:
            char storedElementD = board[2,0];
            bool foundWinnerD = true;
            for (int i = 1; i < 3; i++)
            {
                if (board[2-i,i] != storedElementD) 
                {
                    foundWinnerD = false;
                    break;
                }
            }
            if (foundWinnerD)
            {
                if (storedElementD == 'X') return 1;
                else if (storedElementD == 'O') return 2;
            }
            
            // Determine State with No Winner:
            if (isFull) return 3;
            else return 0;
        }

        /** <summary> Prints the layout of the board for the game selected. </summary> **/
        /** <returns> The layout of the board in a string. </summary> **/
        public static string printBoard(Game game, List<Move> moves)
        {
            // Populate Board:
            populateBoard(game, moves);

            // Print all board spots:
            string output = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    output += board[i,j] + "\t";
                }
                output += "\n";
            }

            return output;
        }

        /** <summary> Prints the layout of the board for the game selected at Row 0. </summary> **/
        /** <returns> The layout of Row 0 of the board in a string. </summary> **/
        public static string printBoardRow0(Game game, List<Move> moves)
        {
            // Populate Board:
            populateBoard(game, moves);

            // Print all board spots:
            string output = "|";

            for (int j = 0; j < 3; j++)
            {
                output += board[0,j] + "|";
            }

            return output;
        }

        /** <summary> Prints the layout of the board for the game selected at Row 1. </summary> **/
        /** <returns> The layout of Row 1 of the board in a string. </summary> **/
        public static string printBoardRow1(Game game, List<Move> moves)
        {
            // Populate Board:
            populateBoard(game, moves);

            // Print all board spots:
            string output = "|";

            for (int j = 0; j < 3; j++)
            {
                output += board[1,j] + "|";
            }

            return output;
        }

        /** <summary> Prints the layout of the board for the game selected at Row 2. </summary> **/
        /** <returns> The layout of Row 2 of the board in a string. </summary> **/
        public static string printBoardRow2(Game game, List<Move> moves)
        {
            // Populate Board:
            populateBoard(game, moves);

            // Print all board spots:
            string output = "|";

            for (int j = 0; j < 3; j++)
            {
                output += board[2,j] + "|";
            }

            return output;
        }
    }
}