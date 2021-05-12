using System.Collections.Generic;

namespace DomainWordFinder
{
	public class WordFinder
	{
		public readonly HashSet<string> matrix;

		public WordFinder(IEnumerable<string> matrix)
		{			
			this.matrix = new HashSet<string>(matrix);					
		}		
	}
}