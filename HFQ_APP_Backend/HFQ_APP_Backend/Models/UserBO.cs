using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFQ_APP_Backend.Models
{
    public class UserBO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FavouriteColour { get; set; }
        public DateTime Dob { get; set; }

        private AgesBO _agesBO;

        public AgesBO agesBO
        {
            get
            {
                if (_agesBO == null)
                {
                    _agesBO = new AgesBO();
                    CalculateAge();
                }
                return _agesBO;
            }
            set
            {
                _agesBO = value;
                CalculateAge();
            }
        }

        private void CalculateAge()
        {
            if (_agesBO != null)
            {
                int birthYear = Dob.Year;
                int currentYear = DateTime.Now.Year;
                _agesBO.UserId = Id;
                _agesBO.OriginalAge = currentYear - birthYear;
                _agesBO.AgePlusTwenty = _agesBO.OriginalAge + 20;
            }
        }
    }
}