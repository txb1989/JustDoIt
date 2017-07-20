using Jst.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jst.Core.Entities
{
    #region 实体基类
    public class EntityBase<TPrimarykey> : IEntity<TPrimarykey>
    {
        public TPrimarykey Id { get; set; }

        /// <summary>
        /// 检查是否是瞬时对象 (Id是否有值).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        public virtual bool IsTransient()
        {
            if (EqualityComparer<TPrimarykey>.Default.Equals(Id, default(TPrimarykey)))
            {
                return true;
            }

            //如果主键是int或者longxing
            if (typeof(TPrimarykey) == typeof(int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimarykey) == typeof(long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }

        /// <summary>
        /// 重载Equal方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TPrimarykey>))
            {
                return false;
            }

            //相同的引用实例，
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            //两个都是瞬时对象，返回false
            var other = (EntityBase<TPrimarykey>)obj;
            if (IsTransient() && other.IsTransient())
            {
                return false;
            }

            //Must have a IS-A relation of types or must be same type
            //IS-A关系，应该有相同的基类，说白了就是判断两个是否是继承关系，如果是继承关系，也可能是一样的
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            #region 这里是租户的判断，我先注释掉，我的框架还没考虑这个。
            //if (this is IMayHaveTenant && other is IMayHaveTenant &&
            //    this.As<IMayHaveTenant>().TenantId != other.As<IMayHaveTenant>().TenantId)
            //{
            //    return false;
            //}

            //if (this is IMustHaveTenant && other is IMustHaveTenant &&
            //    this.As<IMustHaveTenant>().TenantId != other.As<IMustHaveTenant>().TenantId)
            //{
            //    return false;
            //} 
            #endregion

            return Id.Equals(other.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(EntityBase<TPrimarykey> left, EntityBase<TPrimarykey> right)
        {
            if (Equals(left, null))
            {
                return Equals(right, null);
            }

            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(EntityBase<TPrimarykey> left, EntityBase<TPrimarykey> right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{GetType().Name} {Id}]";
        }
    }

    public class EntityBase : EntityBase<long>
    {

    }

    #endregion

    #region 创建实体

    public class CreationEntityBase<TPrimaryKey, TForeinkey> : EntityBase<TPrimaryKey>, ICreate<TForeinkey> where TForeinkey:struct
    {
        public DateTime CreateTime { get; set; }

        public TForeinkey? CreateUserId { get; set; }
    }

    public class CreationAuditUserEntityBase<TPrimaryKey, TForeinkey, TUser> : CreationEntityBase<TPrimaryKey, TForeinkey>, ICreateAudit<TUser, TForeinkey> where TForeinkey : struct
    {
        [ForeignKey("CreateUserId")]
        public TUser CreateUser { get; set; }
    }

    #endregion

    #region 更新实体

    public class UpdateEntityBase<TPrimaryKey, TForeinkey> : EntityBase<TPrimaryKey>, IUpdate<TForeinkey> where TForeinkey : struct
    {
        public DateTime? UpdateTime { get; set; }

        public TForeinkey? UpdateUserId { get; set; }
    }

    public class UpdateEntityAuditUserEntityBase<TPrimaryKey, TForeinkey, TUser> : UpdateEntityBase<TPrimaryKey, TForeinkey>, IUpdateAuditUser<TUser, TForeinkey> where TForeinkey : struct
    {
        [ForeignKey("UpdateUserId")]
        public TUser UpdateUser { get; set; }
    }

    #endregion

    #region 审核实体

    public class AuditEntityBase<TPrimaryKey, TForeinkey> : EntityBase<TPrimaryKey>, IAudit<TForeinkey> where TForeinkey : struct
    {
        public string AuditReason { get; set; }

        public DateTime AuditTime { get; set; }

        public TForeinkey? AuditUserId { get; set; }
    }

    public class AuditUserEntityBase<TPrimaryKey, TForeinkey, TUser> : AuditEntityBase<TPrimaryKey, TForeinkey>, IAuditUser<TForeinkey, TUser> where TForeinkey : struct
    {
        [ForeignKey("AuditUserId")]
        public TUser AuditUser { get; set; }
    }

    #endregion

    #region 假删除实体

    public class SoftDeleteEntityBase<TPrimaryKey, TForeinkey> : EntityBase<TPrimaryKey>, ISoftDeleted<TForeinkey> where TForeinkey : struct
    {
        public TForeinkey? DeleteUserId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeleteTime { get; set; }
    }

    public class SoftDeleteUserEntityBase<TPrimaryKey, TForeinkey, TUser> : SoftDeleteEntityBase<TPrimaryKey, TForeinkey>, ISoftDeleteUser<TForeinkey, TUser> where TForeinkey : struct
    {
        [ForeignKey("DeleteUserId")]
        public TUser DeleteUser { get; set; }
    }

    #endregion

    #region All
    public class CreateAndUpdateEntityBase<TPrimaryKey, TForeinkey> : CreationEntityBase<TPrimaryKey, TForeinkey>, IUpdate<TForeinkey> where TForeinkey : struct
    {
        public DateTime? UpdateTime { get; set; }

        public TForeinkey? UpdateUserId { get; set; }
    }

    public class CreateAndUpdateUserEntityBase<TPrimaryKey, TForeinkey, TUser> : CreationAuditUserEntityBase<TPrimaryKey, TForeinkey, TUser>, IUpdateAuditUser<TUser, TForeinkey> where TForeinkey : struct
    {
        public DateTime? UpdateTime { get; set; }

        [ForeignKey("UpdateUserId")]
        public TUser UpdateUser { get; set; }

        public TForeinkey? UpdateUserId { get; set; }
    }
    
    #endregion
}
