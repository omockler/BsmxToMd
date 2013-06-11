using System;
using System.Text;

namespace BsmxToMd
{
	public static class BlogUtils
	{
		public static string GenerateHeader(this Recipe recipe)
		{
			var sb = new StringBuilder();
			sb.AppendLine("---");
			sb.AppendLine("layout: post");
			sb.AppendFormat("title: {0}\n", recipe.Name);
			sb.AppendFormat("description: {0}\n", recipe.Name);
			sb.AppendFormat("modified: {0}\n", DateTime.Now);
			sb.AppendLine("category: beers");
			sb.AppendLine("tags: []");
			sb.AppendLine("image:");
			sb.AppendLine("  texture-feature-05.jpg");
			sb.AppendLine("---");
			sb.AppendLine ();
			return sb.ToString();
		}
	}
}

