using Microsoft.AspNetCore.Mvc.Rendering;

namespace Winterra.Models.DataModels
{ 
    public static class ContentTypeOptions
    {
        public static readonly List<SelectListItem> AvailableTypes = new()
        {
            new SelectListItem { Text = "Characters", Value = "characters" },
            new SelectListItem { Text = "Highlights", Value = "highlights" },
            new SelectListItem { Text = "Lore", Value = "lore" },
            new SelectListItem { Text = "Features", Value = "features" },
            new SelectListItem { Text = "News", Value = "news" },
            new SelectListItem { Text = "Updates", Value = "updates" },
            new SelectListItem { Text = "Code of Conduct", Value = "code-of-conduct" },
            new SelectListItem { Text = "Terms of Use", Value = "terms-of-use" },
            new SelectListItem { Text = "Privacy Policy", Value = "privacy-policy" },
            new SelectListItem { Text = "Playbook", Value = "playbook" },
            new SelectListItem { Text = "Stellar", Value = "stellar" },
            new SelectListItem { Text = "Events", Value = "events" },
        };
    }
}