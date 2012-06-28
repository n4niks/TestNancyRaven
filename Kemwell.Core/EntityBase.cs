#region Header
/************************************************************************************************************************
* Name:  EntityBase.cs
* Description: EntityBase
* Created On:  29-May-2012
* Created By:  Swathi
* Last Modified On: 
* Last Modified By: 
* Last Modified Reason: 
************************************************************************************************************************/
#endregion Header
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Kemwell.Core
{
    /// <summary>
    /// Abstract class for Inhertance.It contains the common properties of class
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    public abstract class EntityBase : IEntityBase
    {
        #region Fields
        /// <summary>
        /// Property to hold broken rules
        /// </summary>
        private IList<string> _brokenRules = new List<string>();
        
        /// <summary>
        /// variable to hold id of an entity
        /// </summary>
        long _id;

        /// <summary>
        /// Property to check whether id has been set
        /// </summary>
        private bool _idHasBeenSet = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Property to hold Created By
        /// </summary>
        public virtual long CreatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// Property to hold Created Date
        /// </summary>
        public virtual DateTime DateCreated
        {
            get;
            set;
        }

        /// <summary>
        /// Property to hold Modified Date
        /// </summary>
        public virtual DateTime DateModified
        {
            get;
            set;
        }

        /// <summary>
        /// Property to hold Id of an entity
        /// </summary>
        public virtual long Id
        {
            //get { return _id; }
            //set
            //{
            //    if (_idHasBeenSet)
            //        ThrowExceptionIfOverwritingAnId();
            //    _id = value;
            //    _idHasBeenSet = true;
            //}
            get;
            set;
        }

        /// <summary>
        /// Property to hold Modified By
        /// </summary>
        public virtual long ModifiedBy
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Operator overload for determining inequality.
        /// </summary>
        /// <param name="base1"> The first instance of an
        /// <see cref="EntityBase"/> . </param>
        /// <param name="base2"> The second instance of an
        /// <see cref="EntityBase"/> . </param>
        /// <returns> True if not equal. </returns>
        public static bool operator !=(EntityBase base1, EntityBase base2)
        {
            return (!(base1 == base2));
        }

        /// <summary>
        /// Operator overload for determining equality.
        /// </summary>
        /// <param name="base1"> The first instance of an
        /// <see cref="EntityBase"/> . </param>
        /// <param name="base2"> The second instance of an
        /// <see cref="EntityBase"/> . </param>
        /// <returns> True if equal. </returns>
        public static bool operator ==(EntityBase base1, EntityBase base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object)base1 == null & (object)base2 == null)
            {
                return true;
            }
            // check for either of them == to null
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }
            if (base1.Id != base2.Id)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified entity is equal to the
        /// current instance.
        /// </summary>
        /// <param name="entity"> An <see cref="System.Object"/> that
        /// will be compared to the current instance. </param>
        /// <returns> True if the passed in entity is equal to the
        /// current instance. </returns>
        public override bool Equals(object entity)
        {
            if (entity == null || !(entity is EntityBase))
            {
                return false;
            }
            return (this == (EntityBase)entity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {
                sb.Append(prop.Name + "=" + prop.GetValue(this, null) + Environment.NewLine);
            }
            return sb.ToString();
        }

        public virtual IEnumerable<string> GetBrokenBusinessRules()
        {
            return _brokenRules;
        }

        /// <summary>
        /// Serves as a hash function for this type.
        /// </summary>
        /// <returns> A hash code for the current Key
        /// property. </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual bool IsValid()
        {
            ClearCollectionOfBrokenRules();
            CheckForBrokenRules();
            return _brokenRules.Count() == 0;
        }

        protected void AddBrokenRule(string brokenRule)
        {
            _brokenRules.Add(brokenRule);
        }

        protected abstract void CheckForBrokenRules();

        private void ClearCollectionOfBrokenRules()
        {
            _brokenRules.Clear();
        }

        private void ThrowExceptionIfOverwritingAnId()
        {
            throw new ApplicationException("You cannot change the id of an entity.");
        }

        #endregion Methods
    }
}