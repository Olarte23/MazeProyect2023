using Maze.Logic;

try
{
	//var maze = new MyMaze(10, 0);
	//Console.WriteLine(maze);
	//Console.WriteLine("\nWay to Exit\n");
	//maze.FillWay();
	//Console.WriteLine(maze);

    var maze = new MazeOp(20,20);
    Console.WriteLine("\n**** Maze Proyect ****\n");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(maze);
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("\nWay to Exit\n");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Blue;
    maze.FillWay();   
    Console.WriteLine(maze);
    Console.BackgroundColor = ConsoleColor.Black;
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	
};