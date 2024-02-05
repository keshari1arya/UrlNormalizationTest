namespace UnitTestProject
{
    public class UrlNormalizationHelper : IUrlNormalizationHelper
    {
        public int CountUniqueUrls(string[] urls)
        {
            if (urls == null || urls.Length == 0)
                return 0;

            var uniqueUrls = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var url in urls)
            {
                var uri = new Uri(url);
                var normalizedUrl = $"{uri.Scheme}://{uri.Host}";
                uniqueUrls.Add(normalizedUrl);
            }

            return uniqueUrls.Count;
        }
        public Dictionary<string, int> CountUniqueUrlsPerTopLevelDomain(string[] urls)
        {
            if (urls == null || urls.Length == 0)
                return new Dictionary<string, int>();

            var topLevelDomainCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var url in urls)
            {
                var uri = new Uri(url);

                if (topLevelDomainCount.ContainsKey(uri.Host))
                {
                    topLevelDomainCount[uri.Host]++;
                }
                else
                {
                    topLevelDomainCount[uri.Host] = 1;
                }
            }

            return topLevelDomainCount;
        }
    }
}