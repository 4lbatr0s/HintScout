using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace HintScout;

public class ClientHintsService : IClientHintsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ClientHintsOptions _options;

    public ClientHintsService(IHttpContextAccessor httpContextAccessor, ClientHintsOptions options)
    {
        _httpContextAccessor = httpContextAccessor;
        _options = options;
    }

    public string CreateUserAgent()
    {
        IDictionary<string, string> hints = GetAllClientHints();
        StringBuilder sb = new StringBuilder("Mozilla/5.0 (");

        if (hints.TryGetValue(ClientHintHeaders.DevicePlatformHeader, out string? platform))
        {
            sb.Append(platform);
            
            if (hints.TryGetValue(ClientHintHeaders.DevicePlatformVersionHeader, out string? version))
            {
                sb.Append($" {version}");
            }
        }

        sb.Append(") ");

        if (hints.TryGetValue(ClientHintHeaders.BrandHeader, out string? brand))
        {
            sb.Append(brand);
        }

        if (hints.TryGetValue(ClientHintHeaders.DeviceMobileOrNotHeader, out string? mobile) && mobile == ClientHintHeaders.MobileDeviceIndicator)
        {
            sb.Append(" Mobile");
        }

        return sb.ToString().Trim();
    }

    public T GetClientHintValue<T>(string headerName)
    {
        HttpContext httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext is null)
        {
            return default;
        }

        if (httpContext.Request.Headers.TryGetValue(headerName, out StringValues values))
        {
            string value = values.ToString();
            
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default;
            }
        }

        return default;
    }

    public IDictionary<string, string> GetAllClientHints()
    {
        HttpContext? httpContext = _httpContextAccessor.HttpContext;
        
        if (httpContext == null)
        {
            return new Dictionary<string, string>();
        }

        return _options.AcceptClientHintList
            .Where(header => httpContext.Request.Headers.TryGetValue(header, out _))
            .ToDictionary(header => header, header => httpContext.Request.Headers[header].ToString());
    }
}