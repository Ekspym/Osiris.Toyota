
using Osiris.Toyota.Core.Enums;

namespace Osiris.Toyota.Core.Entities
{
    public class ExternalSystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EndpointUrl { get; set; }

        // Šifrovaný přístupový token
        public string EncryptedAccessToken { get; private set; }
        public string EncryptedRefreshToken { get; private set; }
        public DateTime? TokenExpiration { get; set; }

        // Mapování pro různé systémy
        public Dictionary<string, string> FieldMappings { get; set; } = new();
        public ExternalSystemType SystemType { get; set; }
        public ExternalSystemAuthType AuthType { get; set; }

        public void SetTokens(string accessToken, string refreshToken, IDataProtector protector)
        {
            EncryptedAccessToken = protector.Protect(accessToken);
            EncryptedRefreshToken = protector.Protect(refreshToken);
        }
    }
}
