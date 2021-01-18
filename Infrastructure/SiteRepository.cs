using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EtAndHkIde.Infrastructure
{
    public interface ISiteRepository
    {
        /// <summary>
        /// Get a page by path, case insensitive.
        /// </summary>
        PageMetadata GetPage(string path);

        /// <summary>
        /// Get published pages sorted by publish date descending.
        /// </summary>
        IEnumerable<PageMetadata> GetPages();

        /// <summary>
        /// Get draft (null publish date) pages.
        /// </summary>
        IEnumerable<PageMetadata> GetDraftPages();

        /// <summary>
        /// Get pages for a tag
        /// </summary>
        IEnumerable<PageMetadata> GetPagesForTag(string tag);

        IEnumerable<string> GetTags();
    }

    public class SiteRepository : ISiteRepository
    {
        // pages keyed by path
        private IDictionary<string, PageMetadata> _pages;
        private IEnumerable<string> _tags;

        public SiteRepository()
        {
            // Note that classes that require DI need an empty ctor and the DI ctor must be marked with [ActivatorUtilitiesConstructor]
            var pages = new List<PageMetadata>();
            var pageTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(SitePageModel).IsAssignableFrom(x) && !x.IsAbstract);
            foreach (var pageType in pageTypes)
            {
                var fullName = pageType.FullName;
                var modelIndex = fullName.LastIndexOf("Model", StringComparison.OrdinalIgnoreCase);
                var pagesIndex = fullName.LastIndexOf("Pages", StringComparison.OrdinalIgnoreCase) + 5;
                var path = fullName.Remove(modelIndex).Substring(pagesIndex).Replace('.', '/');
                // todo classes substitute underscore for dash in the .cshtml name, need a way to get the real path
                path = path.Replace('_', '-');
                var pageModel = (SitePageModel)Activator.CreateInstance(pageType);
                pageModel.Metadata.Path = path;
                pages.Add(pageModel.Metadata);
            }
            _pages = pages.ToDictionary(k => k.Path, StringComparer.OrdinalIgnoreCase);

            var tags = new List<string>();
            tags.AddRange(TagValues.System.All);
            tags.AddRange(TagValues.People.All);
            tags.AddRange(TagValues.Places.All);
            _tags = tags;
        }

        public PageMetadata GetPage(string path)
        {
            if (_pages.TryGetValue(path, out var pageMetadata))
            {
                return pageMetadata;
            }
            return null;
        }

        public IEnumerable<PageMetadata> GetDraftPages()
        {
            // all unpublished pages
            return _pages.Values.Where(x => x.PublishDate == null || x.PublishDate > DateTime.Today).ToList();
        }

        public IEnumerable<PageMetadata> GetPages()
        {
            // published pages that are listed
            return _pages.Values.Where(x => x.PublishDate != null && x.PublishDate.Value <= DateTime.Today && x.IsPrimary).ToList();
        }

        public IEnumerable<PageMetadata> GetPagesForTag(string tag)
        {
            return _pages.Values.Where(x => x.PublishDate != null && x.PublishDate <= DateTime.Today && x.Tags.Contains(tag)).ToList();
        }

        public IEnumerable<string> GetTags() => _tags;

    }
}
