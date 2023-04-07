namespace Stuntman.Web.Data
{
    public static class SearchExtensionMethod
    {
        public static IEnumerable<string> Search(this IEnumerable<string> collection, string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
                return collection;
            return collection.Where(x => x.Contains(searchValue, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}