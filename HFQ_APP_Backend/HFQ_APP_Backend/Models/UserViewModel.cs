using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFQ_APP_Backend.Models
{
    public class UserViewModel
    {
        public List<UserBO> userBOs { get; set; }
        public List<TopColoursBO> topColoursBOs { get; set; }
        public List<AgesBO> agesBOs { get; set; }
    }
}
//    users": [
//    {
//      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//      "firstName": "string",
//      "lastName": "string",
//      "email": "string",
//      "dob": "2024-02-15T18:53:16.127Z",
//      "favouriteColour": "string"
//    }
//  ],
//  "ages": [
//    {
//      "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
//      "originalAge": 0,
//      "agePlusTwenty": 0
//    }
//  ],
//  "topColours": [
//    {
//      "colour": "string",
//      "count": 0
//    }
//  ]