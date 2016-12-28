using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using gShell.dotNet.Utilities.OAuth2;

namespace gShell.Cmdlets.Utilities.OAuth2
{
    /// <summary>
    /// A cmdlet base for APIs that accept standard parameters
    /// </summary>
    public abstract class StandardParamsCmdletBase : AuthenticatedCmdletBase
    {
        #region Properties

        /// <summary>
        /// <para type="description">A Standard Query Parameters Object.</para>
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public StandardQueryParameters StandardQueryParams { get; set; }

        #endregion
    }
}
