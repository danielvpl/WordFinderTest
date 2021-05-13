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

        [Fact]
        public void WordFinderServiceFindTestErrorMaxSize()
        {
            var matrix = new string[] { "abcdcefgh", "fgwiosdfa", "chillaaaa", "pqnsdbbbb", "uvdxycccc", "abcdcefgi", "fgwiosdfb", "chillaaab", "pqnsdbbba" };
            var wordstream = new string[] { "chill", "cold", "wind", "cloud" };

            try
            {
                var wordFinderService = new WordFinderService(matrix);
                var result = wordFinderService.Find(wordstream);
            }
            catch (Exception e)
            {
                Assert.Equal("Matrix max size is 64x64", e.Message);
            }
        }

        [Fact]
        public void WordFinderServiceFindTestErrorFormat()
        {
            var matrix = new string[] { "abcdcdefg", "fgwio", "chill", "pqnsd", "uvdxy" };
            var wordstream = new string[] { "chill", "cold", "wind", "cloud" };

            try
            {
                var wordFinderService = new WordFinderService(matrix);
                var result = wordFinderService.Find(wordstream);
            }
            catch (Exception e)
            {
                Assert.Equal("Bad formatted matrix", e.Message);
            }            
        }
    }
}
