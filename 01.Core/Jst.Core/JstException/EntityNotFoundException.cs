using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.JstException
{
    public class EntityNotFoundException : JstCoreException
    {
        /// <summary>
        /// Type of the entity.
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// Id of the Entity.
        /// </summary>
        public object Id { get; set; }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/> object.
        /// </summary>
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(Type entityType,object id):base(0,"未找到实体")
        {
            EntityType = entityType;
            Id = id;
        }
      

       

      
       
    }
}
