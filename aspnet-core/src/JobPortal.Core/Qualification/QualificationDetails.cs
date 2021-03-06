using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using JobPortal.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Qualification
{
    public class QualificationDetails : Entity, IAudited
    {
        public long? CreatorUserId { get ; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get; set ; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get ; set; }
    }
}
