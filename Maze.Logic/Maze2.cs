using System.Security.Cryptography;

namespace Maze.Logic
{
    public  class MazeOp
    {
        private char[,] _maze;

        public MazeOp(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
            
        }        

        public int N { get; }

        public int Obstacles { get; }
        public int row = 1;
        public int column = 0;


        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $" {_maze[i, j]} ";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
            FillObstacles();
            
        }

        public void FillWay()  
        {
            do
            {
                if (column < N - 1)
                {
                    do
                    {
                        FillRight();
                    } while (FillRightValidator());
                    //if (_maze[row + 1, column] != ' ')
                    //{
                    //    throw new Exception("No puede bajar");
                       
                    //}

                    if ((_maze[row, column] == ' '))
                    {
                        _maze[row, column] = 'D';
                        row++;
                        if (_maze[row, column] != ' ')
                        {
                            if (_maze[row, column] != ' ' && _maze[row - 1, column - 1] == ' ')
                            {
                                FillLeft();
                            }
                            else
                            {
                                return;
                                //throw new Exception("No puede mover a la izquierda");
                            }
                        }

                    }
                }            

            } while (column < N - 1 && row < N - 2);
            _maze[row, column] = 'R';
            column++;
            _maze[row, column] = 'F';


        }

        private bool FillRightValidator()
        {
            bool validator = true;

            if (!(_maze[row, column + 1] != ' '))
            {
                validator = true;
            }
            else validator = false;            

            return validator;
            
        }

        private void FillLeft()
        {
            row--;
            _maze[row, column] = 'L';
            column--;
           
                if ((_maze[row + 1, column] != ' '))
                {
                    do
                    {
                        _maze[row, column] = 'L';
                        column--;
                        if (_maze[row, column] != ' ')
                        {
                        return;
                        // throw new Exception("No puede seguir moviendo a la izquierda");
                        }

                    } while (_maze[row + 1, column] != ' ');
                    _maze[row, column] = 'D';
                    row++;
            }
                else
                {
                    _maze[row, column] = 'D';
                    row++;
                }                

        }

        private void FillRight()
        {
            if (_maze[row, column] == ' ' && _maze[row, column + 1] == ' ')
            {
                _maze[row, column] = 'R';
                column++;
            }           
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!(i == 1 && j == 1 || i == N - 2 && j == N - 2))
                {
                    if (_maze[i , j] == ' ')
                    {
                        _maze[i, j] = '*';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                _maze[0, i] = '*';
            }
            for (int i = 0; i < N - 1; i++)
            {
                _maze[1, i] = ' ';
            }

            _maze[1, N - 1] = '*';
            for (int i = 2; i < N - 2; i++)
            {
                _maze[i, 0] = '*';
                for (int j = 1; j < N - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N - 1] = '*';
            }
            _maze[N - 2, 0] = '*';
            for (int i = 1; i < N ; i++)
            {
                _maze[N-2, i] = ' ';
            }
            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '*';
            }
        }
    }
}