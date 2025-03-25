using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_CONVERT
{
    internal class BITWARDEN
    {
        public object passwordHistory { get; set; }
        public DateTime revisionDate { get; set; }
        public DateTime creationDate { get; set; }
        public object deletedDate { get; set; }
        public Guid id { get; set; }
        public Guid organizationId { get; set; }
        public object folderId { get; set; }
        public int type { get; set; }
        public int reprompt { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public bool favorite { get; set; }
        public Login login { get; set; }
        public string[] collectionIds { get; set; }
    }

    public class Login
    {
        public object[] fido2Credentials { get; set; }
        public Uri[] uris { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public object totp { get; set; }
    }

    public class Uri
    {
        public object match { get; set; }
        public string uri { get; set; }
    }
}
