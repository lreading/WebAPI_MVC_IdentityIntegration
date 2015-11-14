using System;

namespace TestTypes
{
    public class BearerTokenModel
    {
        public String access_token { get; set; }
        public String token_type { get; set; }
        public Int64? expires_in { get; set; }
        public String UserName { get; set; }
        public DateTime? issued { get; set; }
        public DateTime? expires { get; set; }
    } // end class
} // end namespace