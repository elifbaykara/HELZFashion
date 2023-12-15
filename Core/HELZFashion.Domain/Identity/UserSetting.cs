using HELZFashion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Identity
{
    public class UserSetting : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}