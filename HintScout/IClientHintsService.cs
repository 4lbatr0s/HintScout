namespace HintScout;

public interface IClientHintsService
{
    string CreateUserAgent();
    T GetClientHintValue<T>(string headerName);
    IDictionary<string, string> GetAllClientHints();
}