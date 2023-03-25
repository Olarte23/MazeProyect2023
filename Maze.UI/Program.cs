using Maze.Logic;

try
{
	var maze = new MyMaze(10, 10);
	Console.WriteLine(maze);
	Console.WriteLine("\nWay to Exit\n");
	maze.FillWay();
	Console.WriteLine(maze);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	
};