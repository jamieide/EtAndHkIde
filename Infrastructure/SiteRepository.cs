using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EtAndHkIde.Infrastructure
{
    public interface ISiteRepository
    {
        /// <summary>
        /// Get published pages sorted by publish date descending.
        /// </summary>
        IEnumerable<PageMetadata> GetPages();

        /// <summary>
        /// Get draft (null publish date) pages.
        /// </summary>
        IEnumerable<PageMetadata> GetDraftPages();

        //PageMetadata GetPage(string path);

        /// <summary>
        /// Get pages grouped by tag
        /// </summary>
        IDictionary<string, IEnumerable<PageMetadata>> GetPagesByTag();

        IEnumerable<string> GetTags();
    }

    public class SiteRepository : ISiteRepository
    {
        private IEnumerable<PageMetadata> _pages;

        public SiteRepository()
        {
            var pages = new List<PageMetadata>();
            var pageTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract);
            foreach (var pageType in pageTypes)
            {
                var fullName = pageType.FullName;
                var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
                var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
                var path = fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
                var pageModel = (SitePageModel)Activator.CreateInstance(pageType);
                pageModel.Metadata.Path = path;
                pages.Add(pageModel.Metadata);
            }
            _pages = pages;
        }

        public IEnumerable<PageMetadata> GetDraftPages()
        {
            return _pages.Where(x => x.PublishDate == null);
        }

        public IEnumerable<PageMetadata> GetPages()
        {
            return _pages.Where(x => x.PublishDate != null);
        }

        public IDictionary<string, IEnumerable<PageMetadata>> GetPagesByTag()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTags()
        {
            throw new NotImplementedException();
        }

    }
}
