#region Header
//************************************************************************************
// Name:Syscode 
// Description: To hold Syscode Object
// Created On:  01-June-2012
// Created By:  Swathi
// Last Modified On:
// Last Modified By:
// Last Modified Reason:
//*************************************************************************************
#endregion Header
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kemwell.Core
{
    /// <summary>
    /// Object to Syscode Enitity
    /// </summary>
    public class Syscode : EntityBase
    {
        //Property to hold Syscode 
        public virtual string Code { get; set; }

        //Property to hold Syscode Name
        public virtual string Description { get; set; }

        //Property to hold SyscodeParentID 
        public virtual Syscode Parent { get; set; }

        protected override void CheckForBrokenRules()
        {
            throw new NotImplementedException();
        }

    }
}
