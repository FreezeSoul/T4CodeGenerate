// -----------------------------------------------------------------------
// <copyright file="ModelTemplate.cs" company="">
// Copyright (c) Code Generator. All rights reserved. 
// This is code is based on the T4 template from the PetaPoco project which in turn is based on the subsonic project.
// This is adapted from OrmLite T4 and Dapper.SimpleCRUD Projects.
// </copyright>
// -----------------------------------------------------------------------

namespace CodeGen.Templates
{
    using Models;

    partial class Common_CodeSnippetsTemplate : ITemplate
    {
        public bool IncludeRelationships { get; set; }
        public Table Table { get; set; }
        public Tables Tables { get; set; }
    }
}