Solution solution = new();
Console.WriteLine(solution.PaintWalls(new int[] { 1, 2, 3, 2 }, new int[] { 1, 2, 3, 2 }));
Console.WriteLine(solution.PaintWalls(new int[] { 2, 3, 4, 2 }, new int[] { 1, 1, 1, 1 }));

public class Solution
{
	private int DFS(int[] dp, int[] cost, int[] time, int index, int remain)
	{
		if (remain <= 0)
		{
			return 0;
		}
		if (index == cost.Length)
		{
			return 1000000009;
		}
		if (dp[index] != -1)
		{
			return dp[index];
		}
		int painted = cost[index] + DFS(dp, cost, time, index + 1, remain - time[index] - 1);
		int notPainted = DFS(dp, cost, time, index + 1, remain);
		dp[index] = Math.Min(painted, notPainted);
		return dp[index];
	}

	public int PaintWalls(int[] cost, int[] time)
	{
		int[] dp = new int[cost.Length];
		Array.Fill(dp, -1);
		return DFS(dp, cost, time, 0, cost.Length);
	}
}