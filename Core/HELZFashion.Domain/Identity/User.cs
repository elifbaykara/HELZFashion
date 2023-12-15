using HELZFashion.Domain.Common;
using HELZFashion.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntityBase<Guid>, ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public UserSetting UserSetting { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedByUserId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}