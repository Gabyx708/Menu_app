using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.PersonalRequests
{
    public class PersonalPasswordRequest
    {
        public string originalPassword {  get; set; }
        public string newPassword { get; set; }
    }
}
