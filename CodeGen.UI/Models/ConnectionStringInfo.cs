// -----------------------------------------------------------------------
// <copyright file="ConnectionStringInfo.cs" company="">
// Copyright (c) Code Generator. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace CodeGen.UI.Models
{
    /// <summary>
    /// This class represents ConnectionStringInfo class.
    /// </summary>
    public class ConnectionStringInfo
    {
        public DbServerType DbServerType { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }
    }
}
