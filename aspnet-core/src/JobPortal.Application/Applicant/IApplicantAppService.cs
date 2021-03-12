using JobPortal.Applicant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Applicant
{
   public interface IApplicantAppService
    {

        void CreateApplicant(CreateApplicantDTO input);
    }
}
