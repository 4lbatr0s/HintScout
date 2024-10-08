namespace HintScout
{
    public class ClientHintsOptions
    {
        public List<string> AcceptClientHintList { get; set; } = new List<string>();
        public Dictionary<string, string> ClientHintToPermissionPolicyMap { get; set; } = new Dictionary<string, string>();

        public ClientHintsOptions()
        {
            AcceptClientHintList.AddRange(ClientHintHeaders.DefaultClientHintToPermissionPolicyMap.Keys);
            
            ClientHintToPermissionPolicyMap = new Dictionary<string, string>(ClientHintHeaders.DefaultClientHintToPermissionPolicyMap);
        }
    }
}