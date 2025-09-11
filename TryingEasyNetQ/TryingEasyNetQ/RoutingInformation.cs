namespace TryingEasyNetQ;

public record RoutingInformation(string RoutingKey, IDictionary<string, object> Headers);