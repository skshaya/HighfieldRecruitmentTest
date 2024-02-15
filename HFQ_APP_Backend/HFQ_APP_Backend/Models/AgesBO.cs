using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFQ_APP_Backend.Models
{
    public class AgesBO
    {
        public Guid UserId { get; set; }
        public int OriginalAge { get; set; }
        public int AgePlusTwenty { get; set; }

        
    }
}