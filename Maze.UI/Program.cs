using Maze.Logic;

try
{
	//var maze = new MyMaze(10, 0);
	//Console.WriteLine(maze);
	//Console.WriteLine("\nWay to Exit\n");
	//maze.FillWay();
	//Console.WriteLine(maze);

    var maze = new MazeOp(20,40);
    Console.WriteLine(maze);
    Console.WriteLine("\nWay to Exit\n");
    maze.FillWay();   
    Console.WriteLine(maze);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	
};