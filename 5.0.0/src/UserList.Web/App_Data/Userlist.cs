using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserList.Web.App_Data
{
    using System;
    using System.Collections.Generic;

    public partial class News
    {
        public int id { get; set; }
        public int AuthenticUserId { get; set; }
        public string NewsTitle { get; set; }
        public string Fullnews { get; set; }
        public string NewsImg { get; set; }
        public System.DateTime NewsCreationDate { get; set; }
        public string fileExtension { get; set; }

    }
}
