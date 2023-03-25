namespace Maze.Logic
{
    public  class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
        }

        public int N { get; }

        public int Obstacles { get; }

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
            int row = 1;
            int j = 0;
            do
            {
                for (; j < N - 1; j++)
                {
                    if (row == 9)
                    {
                        row--;
                        j--;
                        _maze[row, j] = 'R';

                    }
                    if (_maze[row, j + 1] == ' ')
                    {
                        _maze[row, j] = 'R';
                    }
                    else
                    {
                        if (j == N - 2)
                        {
                            for (; row < N - 1; row++)
                            {
                                if (_maze[row, j] == ' ')
                                {
                                    _maze[row, j] = 'D';                                    
                                }
                                
                                else
                                {                                    
                                    row--;
                                    _maze[row, j] = 'L';
                                    j--;
                                    if (_maze[row, j] == ' ' && _maze[row + 1, j] != ' ' && _maze[row, j - 1] != ' ')
                                    {
                                        throw new Exception("The Way is not posible.");
                                    }
                                    else
                                    {
                                        if (_maze[row, j] == ' ' && _maze[row + 1, j] == ' ')
                                        {
                                            if (_maze[row, j + 2] == ' ')
                                            {
                                                _maze[row, j] = 'D';                                               
                                                row++;
                                                _maze[row, j] = 'R';
                                            }
                                            else
                                            {
                                                _maze[row, j] = 'L';
                                            }
                                            

                                        }

                                        
                                        row++;
                                        if (!(_maze[row, j] == ' '))
                                        {
                                            row--;
                                            _maze[row, j] = 'L';
                                            j--;
                                        }
                                        

                                    }
                                    else throw new Exception("The Way is not posible.");
                                }
                               
                            }
                        }
                        else
                        {
                            _maze[row, j] = 'D';
                            j--;
                            row++;
                        }

                        if (!(_maze[row, j + 1] == ' '))
                        {
                            throw new Exception("The Way is not posible.");
                        }
                    }             
                 
                }                


            } while (j < N - 2 || row < N - 2);
            

        

        }
            //do
            //{
            //    if (_maze[row, i] == ' ')
            //    {
            //        _maze[row, i] = 'R';
            //        if (i < N - 2)
            //        {
            //            i++;
            //        } 
            //    }                
            //    else
            //    {
            //        row++;
            //        if (!(i < N - 2))
            //        {
            //            if ((_maze[row, i] == ' '))
            //            {
            //                _maze[row, i] = 'D';
            //                if (row == N - 2)
            //                {
            //                    i++;
            //                }
            //                row++;
            //                if ((_maze[row, i] == ' '))
            //                {
            //                    _maze[row, i] = 'D';
            //                }    
            //            }
            //            else throw new Exception("The Way is not posible.");
            //        }
            //        else
            //        {  
            //            i--;
            //            if ((_maze[row, i] == ' '))
            //            {
            //                _maze[row, i] = 'D';
            //                if (i < N - 2)
            //                {
            //                    i++;
            //                }
            //            }
            //            else
            //            {
            //                row--;
            //                i--;
            //                if (!(_maze[row, i] == ' '))
            //                {
            //                    throw new Exception("The Way is not posible.");
            //                }
            //                _maze[row, i] = 'L';
            //                row++;
            //                if ((_maze[row, i] == ' '))
            //                {
            //                    _maze[row, i] = 'D';
            //                    if (row != N - 2)
            //                    {
            //                        row++;
            //                        _maze[row, i] = 'D';
            //                        i++;
            //                    }
            //                    if (i < N - 2)
            //                    {
            //                        i++;
            //                    }
            //                }
            //            }
            //        }               
            //    }
        //    }
        //    while (i != N);

        //}

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
            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '*';
            }
        }
    }
}