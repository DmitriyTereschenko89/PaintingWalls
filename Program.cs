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
		//int[,] dp = new int[n, n + 1];
		//return DFS(dp, cost, time, 0, n, n);
		int[,] dp = new int[n + 1, n + 1];
		for (int i = 1; i <= n; ++i)
		{
			dp[n, i] = 1000000009;
		}
		for (int i = n - 1; i >= 0; --i)
		{
			for (int remain = 1; remain <= n; ++remain)
			{
				int painted = cost[i] + dp[i + 1, Math.Max(0, remain - 1 - time[i])];
				int notPainted = dp[i + 1, remain];
				dp[i, remain] = Math.Min(painted, notPainted);
			}
		}
		return dp[0, n];
	}
}