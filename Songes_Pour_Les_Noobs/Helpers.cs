using Microsoft.AspNetCore.Components;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;

namespace Songes_Pour_Les_Noobs
{
    public static class MonsterNameMatcher
    {
        public static bool Matches(string name, string searchTerm)
        {
            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(
                name,
                searchTerm,
                CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace
            ) >= 0;
        }
    }

    public static class QueryStringHelper
    {
        public static NameValueCollection GetQuery(NavigationManager navigation)
        {
            var uri = navigation.ToAbsoluteUri(navigation.Uri);
            return HttpUtility.ParseQueryString(uri.Query);
        }
    }
}
