using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Common
{
    public class EntityBase<TKey> : ICreatedByEntity, IModifiedByEntity, IDeletedByEntity
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }



    }
}
