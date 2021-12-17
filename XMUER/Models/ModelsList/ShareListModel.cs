using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace XMUER.Models.ModelsList
{
    public class ShareListModel
    {
        public List<Share> shares { get; set; }

        public ShareListModel()
        {
            shares = new List<Share>();
        }
    }
}
