// -----------------------------------------------------------------------
// <copyright file="GenerateCodeRequest.cs" company="">
// Copyright (c) Code Generator. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

namespace CodeGen.UI.Models
{
    /// <summary>
    /// This class represents GenerateCodeRequest class.
    /// </summary>
    public class GenerateCodeRequest
    {
        public DbServerType ServerType { get; set; }
        public string ConnectionString { get; set; }
        public string FolderLocation { get; set; }
        public bool IncludeRelationship { get; set; }
    }
}

