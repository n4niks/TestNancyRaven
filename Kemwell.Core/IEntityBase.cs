#region Header
/************************************************************************************************************************
* Name:  IEntityBase.cs
* Description: IEntityBase
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

namespace Kemwell.Core
{
    /// <summary>
    /// Interface for Entity Base
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Property to hold Id of Entity
        /// </summary>
        long Id { get; set; }
        /// <summary>
        /// Property to hold Created Date
        /// </summary>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Property to hold Modified Date
        /// </summary>
        DateTime DateModified { get; set; }
        /// <summary>
        /// Property to hold Modified By
        /// </summary>
        long ModifiedBy { get; set; }
        /// <summary>
        /// Property to hold Created By
        /// </summary>
        long CreatedBy { get; set; }
    }
}
