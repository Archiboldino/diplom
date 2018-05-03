using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oprForm
{
    public class Document
    {
        public int event_id;
        public string document_code;
        public string description;

        public override string ToString()
        {
            return description;
        }
    }

    public class DocumentMapper
    {
        public static Document Map(List<Object> row)
        {
            var d = new Document
            {
                event_id = Int32.Parse(row[0].ToString()),
                document_code = row[1].ToString(),
                description = row[2].ToString()
            };
            return d;
        }
    }
}
