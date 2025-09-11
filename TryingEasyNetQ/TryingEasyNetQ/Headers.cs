namespace TryingEasyNetQ
{
    public static class Headers
    {
        public static IDictionary<string, object> GetModelExportedHeader() =>
            new Dictionary<string, object> { { "key", "value" } };

        public static IDictionary<string, object> GetExportModelHeader(string requesterUsername) =>
            new Dictionary<string, object> { { requesterUsername, "value" } };

        public static IDictionary<string, object> GetConfirmHeader(string requesterUsername) =>
            new Dictionary<string, object> { { requesterUsername, "value" } };
    }
}