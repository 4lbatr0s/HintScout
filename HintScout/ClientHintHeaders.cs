namespace HintScout;

public static class ClientHintHeaders
{
    public const string DeviceModelHeader = "Sec-CH-UA-Model";
    public const string DevicePlatformHeader = "Sec-CH-UA-Platform";
    public const string DevicePlatformVersionHeader = "Sec-CH-UA-Platform-Version";
    public const string BrandHeader = "Sec-CH-UA";
    public const string DeviceMobileOrNotHeader = "Sec-CH-UA-Mobile";
    public const string BrandFullVersionListHeader = "Sec-CH-UA-Full-Version-List";
    public const string BitnessHeader = "Sec-CH-UA-Bitness";
    public const string DeviceArchitectureHeader = "Sec-CH-UA-Arch";
    public const string MobileDeviceIndicator = "?1";

    public const string AcceptClientHint = "Accept-CH";
    public const string AcceptClientHintLifeTime = "Accept-CH-Lifetime";
    public const string AcceptClientHintLifeTimeValue = "86400";

    public const string PermissionsPolicy = "Permissions-Policy";

    public static readonly Dictionary<string, string> DefaultClientHintToPermissionPolicyMap = new()
    {
        { DeviceModelHeader, "ch-ua-model" },
        { DevicePlatformHeader, "ch-ua-platform" },
        { DevicePlatformVersionHeader, "ch-ua-platform-version" },
        { BrandHeader, "ch-ua" },
        { BrandFullVersionListHeader, "ch-ua-full-version-list" },
        { DeviceMobileOrNotHeader, "ch-ua-mobile" },
        { DeviceArchitectureHeader, "ch-ua-arch" },
        { BitnessHeader, "ch-ua-bitness" }
    };
}