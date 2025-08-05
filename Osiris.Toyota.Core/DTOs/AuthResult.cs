using System.Net.Http.Headers;

namespace Osiris.Toyota.Core.DTOs
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public AuthenticationHeaderValue NewAuthHeader { get; set; }
    }
}
