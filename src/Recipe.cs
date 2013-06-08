using System.Collections.Generic;
using System.Text;

namespace BsmxToMd
{
	public class Recipe
	{
		public string Name { get; set; }
		public ICollection<Grain> Grains { get; set; }
		public ICollection<Hop> Hops { get; set; }
		public string Yeast { get; set; }
		public string Notes { get; set; }

		public string ToMarkdown()
		{
			var sb = new StringBuilder ();
			sb.AppendFormat ("#{0}", Name);
			sb.AppendLine ();
			sb.AppendLine ("## Grain");
			sb.AppendLine ("| Name | Amount %|");
			sb.AppendLine ("| ---- | ------: |");
			foreach (var grain in Grains) 
			{
				sb.AppendLine (grain.ToMarkdown());
			}
			sb.AppendLine ();
			sb.AppendLine ("## Hops");
			sb.AppendLine ("| Name | Amount | Time |");
			sb.AppendLine ("| ---- | -----: | ---: |");
			foreach (var hop in Hops) 
			{
				sb.AppendLine (hop.ToMarkdown());
			}
			sb.AppendLine ();
			sb.AppendLine ("## Yeast");
			sb.AppendLine (Yeast);
			sb.AppendLine ("## Notes");
			sb.AppendLine (Notes);

			return sb.ToString ();
		}
	}
}

