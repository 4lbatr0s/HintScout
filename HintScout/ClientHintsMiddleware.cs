using Microsoft.AspNetCore.Http;

namespace HintScout;

public class ClientHintsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ClientHintsOptions _options;

    public ClientHintsMiddleware(RequestDelegate next, ClientHintsOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        string acceptChHeaders = string.Join(", ", _options.AcceptClientHintList);
        httpContext.Response.Headers.TryAdd(ClientHintHeaders.AcceptClientHint, acceptChHeaders);
        httpContext.Response.Headers.TryAdd(ClientHintHeaders.AcceptClientHintLifeTime, ClientHintHeaders.AcceptClientHintLifeTimeValue);

        string permissionsPolicyHeaders = string.Join(", ", _options.ClientHintToPermissionPolicyMap.Values.Select(v => $"{v}=(self)"));
        httpContext.Response.Headers.TryAdd(ClientHintHeaders.PermissionsPolicy, permissionsPolicyHeaders);

        await _next(httpContext);
    }
}