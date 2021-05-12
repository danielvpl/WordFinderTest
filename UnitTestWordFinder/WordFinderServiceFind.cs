using DomainWordFinder;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestWordFinder
{
    public class WordFinderServiceFind
    {
        [Fact]
        public void WordFinderServiceFindTest()
        {
            var matrix = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
            var wordstream = new string[] { "chill", "cold", "wind", "cloud" };            

            var wordFinderService = new WordFinderService(matrix);
            var result = wordFinderService.Find(wordstream);

            Assert.Equal(result, new List<string>() { "chill", "cold", "wind" });
        }
    }
}
