namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        public static void Main()
        {
            const int FieldsWithoutMines = 35;
            int pointCount = 0;
            int row = 0;
            int col = 0;
            string command = string.Empty;
            char[,] playfield = CreatePlayfield();
            char[,] mines = PutMines();
            bool isAtStartOfGame = true;
            bool steppedOnAMine = false;
            bool wonTheGame = false;
            List<ScoreInfo> highscores = new List<ScoreInfo>(6);

            do
            {
                if (isAtStartOfGame)
                {
                    Console.WriteLine("Let's play 'Minesweepers'. Try stepping only on the mine-free fields. " +
                    "Command 'top' shows the highscores, 'restart' starts a new game, 'exit' quits the game!");
                    PrintPlayfield(playfield);
                    isAtStartOfGame = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) && col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHighscores(highscores);
                        break;
                    case "restart":
                        playfield = CreatePlayfield();
                        mines = PutMines();
                        PrintPlayfield(playfield);
                        steppedOnAMine = false;
                        isAtStartOfGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ShowFieldValue(playfield, mines, row, col);
                                pointCount++;
                            }

                            if (FieldsWithoutMines == pointCount)
                            {
                                wonTheGame = true;
                            }
                            else
                            {
                                PrintPlayfield(playfield);
                            }
                        }
                        else
                        {
                            steppedOnAMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("{0}Invalid command!{0}", Environment.NewLine);
                        break;
                }

                if (steppedOnAMine)
                {
                    PrintPlayfield(mines);
                    Console.Write("{0}You died with {1} points. Enter your nickname: ", Environment.NewLine, pointCount);
                    string nickname = Console.ReadLine();
                    ScoreInfo playerScore = new ScoreInfo(nickname, pointCount);

                    if (highscores.Count < 5)
                    {
                        highscores.Add(playerScore);
                    }
                    else
                    {
                        for (int i = 0; i < highscores.Count; i++)
                        {
                            if (highscores[i].PlayerPoints < playerScore.PlayerPoints)
                            {
                                highscores.Insert(i, playerScore);
                                highscores.RemoveAt(highscores.Count - 1);
                                break;
                            }
                        }
                    }

                    highscores.Sort((ScoreInfo r1, ScoreInfo r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    highscores.Sort((ScoreInfo r1, ScoreInfo r2) => r2.PlayerPoints.CompareTo(r1.PlayerPoints));
                    ShowHighscores(highscores);

                    playfield = CreatePlayfield();
                    mines = PutMines();
                    pointCount = 0;
                    steppedOnAMine = false;
                    isAtStartOfGame = true;
                }

                if (wonTheGame)
                {
                    Console.WriteLine("{0}Congratulations! You've opened all 35 fields unharmed!", Environment.NewLine);
                    PrintPlayfield(mines);
                    Console.WriteLine("Enter your nickname: ");
                    string nickname = Console.ReadLine();
                    ScoreInfo playerScore = new ScoreInfo(nickname, pointCount);
                    highscores.Add(playerScore);
                    ShowHighscores(highscores);
                    playfield = CreatePlayfield();
                    mines = PutMines();
                    pointCount = 0;
                    wonTheGame = false;
                    isAtStartOfGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }

        private static void ShowHighscores(List<ScoreInfo> highscores)
        {
            Console.WriteLine("{0}HIGHSCORES:", Environment.NewLine);
            if (highscores.Count > 0)
            {
                for (int place = 0; place < highscores.Count; place++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields opened", place + 1, highscores[place].PlayerName, highscores[place].PlayerPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No highscores yet!{0}", Environment.NewLine);
            }
        }

        private static void ShowFieldValue(char[,] playfield, char[,] mines, int row, int col)
        {
            char minesCount = CountMines(mines, row, col);
            mines[row, col] = minesCount;
            playfield[row, col] = minesCount;
        }

        private static void PrintPlayfield(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playfield[i, j] = '?';
                }
            }

            return playfield;
        }

        private static char[,] PutMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    playfield[row, col] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randNumber = random.Next(50);
                if (!mines.Contains(randNumber))
                {
                    mines.Add(randNumber);
                }
            }

            foreach (int mine in mines)
            {
                int row = mine / cols;
                int col = mine % cols;
                if (col == 0 && mine != 0)
                {
                    row--;
                    col = cols;
                }
                else
                {
                    col++;
                }

                playfield[row, col - 1] = '*';
            }

            return playfield;
        }

        private static void CalculateFieldValues(char[,] playfield)
        {
            int rows = playfield.GetLength(0);
            int cols = playfield.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (playfield[row, col] != '*')
                    {
                        char minesCount = CountMines(playfield, row, col);
                        playfield[row, col] = minesCount;
                    }
                }
            }
        }

        private static char CountMines(char[,] playfield, int row, int col)
        {
            int count = 0;
            int rows = playfield.GetLength(0);
            int cols = playfield.GetLength(1);
            char mineSymbol = '*';
            int upperRow = row;
            int lowerRow = row;
            int leftCol = col;
            int rightCol = col;

            if (row > 0)
            {
                upperRow -= 1;
            }

            if (row < rows - 1)
            {
                lowerRow += 1;
            }

            if (col > 0)
            {
                leftCol -= 1;
            }

            if (col < cols - 1)
            {
                rightCol += 1;
            }

            for (int r = upperRow; r <= lowerRow; r++)
            {
                for (int c = leftCol; c <= rightCol; c++)
                {
                    if (r == row && c == col)
                    {
                        continue;
                    }

                    if (playfield[r, c] == mineSymbol)
                    {
                        count++;
                    }
                }
            }

            return char.Parse(count.ToString());
        }
    }
}