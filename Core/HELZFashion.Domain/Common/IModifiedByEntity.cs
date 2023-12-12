using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Common
{
    public interface IModifiedByEntity
    {
        public DateTime? ModifiedOn { get; set; }
        string? ModifiedByUserId { get; set; }
    }
}
