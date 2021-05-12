using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainWordFinder
{
    public class WordFinderService : IWordFinderService
    {
		private WordFinder _wordFinder;
		
		public WordFinderService(IEnumerable<string> matrix)
        {            
			_wordFinder = new WordFinder(matrix);		
		}

		public IList<string> Find(IEnumerable<string> wordstream)
		{
			try
			{
				validateMatrixSize();
				var leftRightSearchString = string.Join(string.Empty, _wordFinder.matrix);

				var characterMatrix = _wordFinder.matrix
					.Select(row => row.ToCharArray())
					.ToArray();

				var topDownSearchStringBuilder = new StringBuilder();

				for (var i = 0; i < characterMatrix.Length; i++)
				{
					for (var j = 0; j < characterMatrix[i].Length; j++)
					{
						topDownSearchStringBuilder.Append(characterMatrix[j][i]);
					}
				}

				var topDownSearchString = topDownSearchStringBuilder.ToString();

				var resultSet = new HashSet<string>();

				resultSet.UnionWith(wordstream.Where(searchTerm =>
													 leftRightSearchString.Contains(searchTerm.Trim())));

				resultSet.UnionWith(wordstream.Where(searchTerm =>
													 topDownSearchString.Contains(searchTerm.Trim())));

				return resultSet.ToList();
			}
			catch(Exception ex)
            {
				return new List<string>() { ex.Message };
            }
		}

		private void validateMatrixSize()
        {
			if (_wordFinder.matrix.Count > 8)
				throw new System.Exception("Matrix max size is 64x64.");

			foreach (var item in _wordFinder.matrix)
            {
				if(item.Length != _wordFinder.matrix.Count)
					throw new System.Exception("Bad formatted matrix.");
			}			
		}
	}
}
