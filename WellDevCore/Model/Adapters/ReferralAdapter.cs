using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using PSW_Web_app.dtos;
using Model.Doctor;
using bolnica.Model.dtos;

namespace bolnica.Model.Adapters
{
    public class ReferralAdapter
    {
        public static ReferralDto ReferralToReferralDto(Referral referral)
        {
            ReferralDto dto = new ReferralDto();
            dto.Period = referral.Period.StartDate.ToString();
            dto.Specialist = referral.Doctor.FullName;
            dto.Text = referral.Text;
            return dto;
        }
    }
}
