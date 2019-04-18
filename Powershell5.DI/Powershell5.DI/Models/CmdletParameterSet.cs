// ***********************************************************************
// Assembly         : Powershell5.Helpers
// Author           : josh
// Created          : 03-22-2019
//
// Last Modified By : josh
// Last Modified On : 03-22-2019
// ***********************************************************************
// <copyright file="CmdletParameterSet.cs" company="">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Powershell5.Helpers.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class CmdletParameterSet.
    /// Implements the <see cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, System.Object}" />
    public class CmdletParameterSet : Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CmdletParameterSet"/> class.
        /// </summary>
        public CmdletParameterSet()
        {
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>The cmdlet parameter dictionary.</returns>
        public CmdletParameterSet Add(string key, object value)
        {
            this.Add(key, value);
            return this;
        }
    }
}