using System.Collections.Generic;

namespace DomainWordFinder
{
    public interface IWordFinderService
    {
        IList<string> Find(IEnumerable<string> wordstream);
    }
}
