using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Models
{
    public interface ISiteRepository
    {
        IEnumerable<Page> GetPages();
        IEnumerable<Page> GetRecentPages(int count);
    }
}