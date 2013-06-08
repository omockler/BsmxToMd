using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BsmxToMd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			FileInfo file = new FileInfo ("../../../../../Documents/BeerSmith2/Recipe.bsmx");
			var bsFile = file.OpenText ().ReadToEnd ();
			var recipeStrings = bsFile.Split (new string[] {"<Recipe>"}, StringSplitOptions.None);

			var recipes = new List<Recipe> (); 
			foreach (var r in recipeStrings) {
				//Does the recipe name match my namin convention (i.e. '032 - ')
				if (Regex.IsMatch (r, "[0-9]{3}\\s-\\s")) {
					var recipe = new Recipe { Grains = new List<Grain>(), Hops = new List<Hop>()};
					var parts = Regex.Split (r, "<\\/[^<]+?>");
					//Match the name of the recipe
					recipe.Name = parts.FirstOrDefault (s => s.Contains ("F_R_NAME")).Split ('>') [1];

					//Get all the grains
					var grainStrings = Regex.Split (r, "<Grain>").Skip (1).ToList ();
					grainStrings.ForEach (item => recipe.Grains.Add(new Grain(item)));

					//Get all the hops
					var hopStrings = Regex.Split (r, "<Hops>").Skip (1).ToList ();
					hopStrings.ForEach (item => recipe.Hops.Add(new Hop(item)));

					//Right now I am only going to care about one yeast but this should be updated in the future
					var yeastString = Regex.Split (r, "<Hops>").Skip (1).FirstOrDefault();
					if (!string.IsNullOrEmpty (yeastString)) 
					{
						recipe.Yeast = Regex.Match (yeastString, "(?<=<F_Y_LAB>)(?<=^|>)[^><]+?(?=<|$)").Value;
						if (!string.IsNullOrEmpty (recipe.Yeast))
							recipe.Yeast += " ";
						recipe.Yeast += Regex.Match (yeastString, "(?<=<F_Y_NAME>)(?<=^|>)[^><]+?(?=<|$)").Value;
					}

					recipe.Notes = Regex.Match(r, "(?<=<F_R_NOTES>)(?<=^|>)[^><]+?(?=<|$)").Value;
					recipes.Add (recipe);
				}
			}
			//recipes.ForEach (item => Console.WriteLine(item.ToMarkdown()));
			foreach (var item in recipes) 
			{
				using (StreamWriter outfile = new StreamWriter(item.Name.Substring(0, 3) + ".md"))
				{
					outfile.Write(item.ToMarkdown());
				}
			}
		}
	}
}
