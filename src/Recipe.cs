using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BsmxToMd
{
	public class Recipe
	{
		public string Name { get; set; }
		public string BrewedOn { get; set; }
		public ICollection<Grain> Grains { get; set; }
		public ICollection<Hop> Hops { get; set; }
		public string Yeast { get; set; }
		public string Notes { get; set; }

		public string Slug {
			get
			{
				return Name.Replace (" ", string.Empty).Replace ('/', '-');
			}
		}

		public string ToMarkdown()
		{
			var sb = new StringBuilder ();
			sb.Append (this.GenerateHeader());

			sb.AppendLine ();
			sb.AppendLine ("## Grain");
			sb.AppendLine ();
			if (Grains.Any ()) 
			{
				sb.AppendLine ("| Name | Amount %|");
				sb.AppendLine ("| ---- | ------: |");
				foreach (var grain in Grains) {
					sb.AppendLine (grain.ToMarkdown());
				}
				sb.AppendLine ();
			}
			if (Hops.Any ()) 
			{
				sb.AppendLine ("## Hops");
				sb.AppendLine ();
				sb.AppendLine ("| Name | Amount | Time |");
				sb.AppendLine ("| ---- | -----: | ---: |");
				foreach (var hop in Hops) {
					sb.AppendLine (hop.ToMarkdown());
				}
				sb.AppendLine ();
			}
			sb.AppendLine ("## Yeast");
			sb.AppendLine (Yeast);
			sb.AppendLine ();
			sb.AppendLine ("## Notes");
			sb.AppendLine (Notes);

			return sb.ToString ();
		}
	}
}

