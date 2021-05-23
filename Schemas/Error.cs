using System.Collections.Generic;

namespace ClientsApi.Schemas
{
    public class Error
    {
        public int Code { get; set; }
        public string Key { get; set; }
        public IEnumerable<ErrorMessage> Messages { get; set; }
    }
}