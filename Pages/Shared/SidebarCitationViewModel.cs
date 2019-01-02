namespace EtAndHkIde.Pages.Shared
{
    public class SidebarCitationViewModel
    {
        public enum CitationType
        {
            Undefined,
            Book,
            Magazine,
            Newspaper
        }

        public SidebarCitationViewModel(CitationType type, string url, string linkText)
        {
            Type = type;
            Url = url;
            LinkText = linkText;
        }

        public CitationType Type { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }
    }
}