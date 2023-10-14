Solution solution = new();
Console.WriteLine(solution.PaintWalls(new int[] { 1, 2, 3, 2 }, new int[] { 1, 2, 3, 2 }));
Console.WriteLine(solution.PaintWalls(new int[] { 2, 3, 4, 2 }, new int[] { 1, 1, 1, 1 }));

public class Solution
{
	private int DFS(int[,] dp, int[] cost, int[] time, int index, int remain, int n)
	{
		if (remain <= 0)
		{
			return 0;
		}
		if (index == n)
		{
			return 1000000009;
		}
		if (dp[index, remain] != 0)
		{
			return dp[index, remain];
		}
		int painted = cost[index] + DFS(dp, cost, time, index + 1, remain - 1 - time[index], n);
		int notPainted = DFS(dp, cost, time, index + 1, remain, n);
		dp[index, remain] = Math.Min(painted, notPainted);
		return dp[index, remain];
	}

	public int PaintWalls(int[] cost, int[] time)
	{
		int n = cost.Length;
		int[,] dp = new int[n, n + 1];
		return DFS(dp, cost, time, 0, n, n);
	}
}