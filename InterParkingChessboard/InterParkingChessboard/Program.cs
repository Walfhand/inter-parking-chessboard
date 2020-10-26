using System;
using System.Collections.Generic;
using System.Linq;

namespace InterParkingChessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] chessboard = new int[8, 8];
            IEnumerable<Position> positions = PossibleKnightMoves(chessboard, StartPosition());
            Console.WriteLine("Here is the list of possible movements of the knight.");

            foreach (Position position in positions)
            {
                Console.WriteLine($"{MapPositionXToLetter(position.X)}; {position.Y}");
            }
        }

        public static Position StartPosition()
        {
            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            Position startPosition = new Position();
            bool yPositionIsOk = false;
            bool xPositionIsOk = false;

            while (!xPositionIsOk)
            {
                Console.WriteLine("Enter your knight's X start position. Ex: A,B,C,D,E,F,G,H");

                if (char.TryParse(Console.ReadLine(), out char xPosition) && letters.Any(l => l == char.ToUpper(xPosition)))
                {
                    startPosition.X = MapLetterXToPosition(xPosition);
                    xPositionIsOk = true;

                    while (!yPositionIsOk)
                    {
                        Console.WriteLine("Enter your knight's Y start position. Ex: 1,2,3,4,5,6,7,8");
                        if (int.TryParse(Console.ReadLine(), out int yPosition) && yPosition >= 1 && yPosition <= 8)
                        {
                            startPosition.Y = yPosition;
                            yPositionIsOk = true;
                        }
                        else
                        {
                            Console.WriteLine("The value for the start position in Y is incorrect.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("The value for the start position in X is incorrect.");
                }
            }
            return startPosition;
        }

        public static char MapPositionXToLetter(int positionX)
        {
            return (char)(positionX + 64);
        }

        public static int MapLetterXToPosition(char letter)
        {
            return char.ToUpper(letter) - 64;
        }


        static IEnumerable<Position> PossibleKnightMoves(int[,] chessboard, Position position)
        {
            Position[] possibleKnightMoves = new Position[]
            {
                new Position(2,1),
                new Position(2,-1),
                new Position(-2,1),
                new Position(-2,-1),
                new Position(1,2),
                new Position(-1,2),
                new Position(1,-2),
                new Position(-1,-2),
            };


            foreach (Position possibleKnightMove in possibleKnightMoves)
            {
                int x = position.X + possibleKnightMove.X;
                int y = position.Y + possibleKnightMove.Y;

                if (x >= 1 && y >= 1 && x <= chessboard.GetLength(0) && y <= chessboard.GetLength(1))
                {
                    yield return new Position(x, y);
                }
            }
        }
    }
}
