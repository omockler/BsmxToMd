using System.Text.RegularExpressions;

namespace BsmxToMd
{
	public class Hop
	{
		public Hop(string bsmx)
		{
			Name = Regex.Match(bsmx, "(?<=<F_H_NAME>)(?<=^|>)[^><]+?(?=<|$)").Value;
			Amount = Regex.Match(bsmx, "(?<=<F_H_AMOUNT>)(?<=^|>)[^><]+?(?=<|$)").Value;
			Time = Regex.Match(bsmx, "(?<=<F_H_BOIL_TIME>)(?<=^|>)[^><]+?(?=<|$)").Value;
		}

		public string Name { get; set; }
		public string Amount { get; set; }
		public string Time { get; set; }

		public string ToMarkdown ()
		{
			return string.Format ("| {0} | {1} | {2} ", Name, Amount.Substring(0, 4), Time.Split('.')[0]);
		}
	}
}

