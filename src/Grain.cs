using System.Text.RegularExpressions;

namespace BsmxToMd
{
	public class Grain
	{
		public Grain(string bsmx)
		{
			Name = Regex.Match(bsmx, "(?<=<F_G_NAME>)(?<=^|>)[^><]+?(?=<|$)").Value;
			Amount = Regex.Match(bsmx, "(?<=<F_G_PERCENT>)(?<=^|>)[^><]+?(?=<|$)").Value;
		}

		public string Name { get; set; }
		public string Amount { get; set; }

		public string ToMarkdown()
		{
			return string.Format ("| {0} | {1} |", Name, Amount.Substring(0, 4));
		}
	}
}