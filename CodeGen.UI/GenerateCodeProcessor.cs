// -----------------------------------------------------------------------
// <copyright file="GenerateCodeProcessor.cs" company="">
// Copyright (c) Code Generator. All rights reserved. 
// </copyright>
// -----------------------------------------------------------------------

using System.Reflection;
using System.Text;
using System.Windows;
using CodeGen.Models;

namespace CodeGen.UI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Models;
    using Readers;
    using Templates;

    /// <summary>
    /// This class represents GenerateCodeProcessor class.
    /// </summary>
    public static class GenerateCodeProcessor
    {

        public static Task<GenerateCodeResponse> Generate(GenerateCodeRequest request)
        {
            return Task.Run(() =>
            {
                using (var schemaReader = SchemaReaderProvider.GetReader(request.ServerType))
                {
                    var connectionString = request.ConnectionString;
                    if (schemaReader == null || string.IsNullOrEmpty(connectionString))
                    {
                        return new GenerateCodeResponse();
                    }

                    var tables = schemaReader.ReadSchema(connectionString);

                    if (tables == null || tables.Count <= 0)
                    {
                        throw new Exception(string.Format("Empty database or invalid connection string: {0}", connectionString));
                    }
                    var response = new GenerateCodeResponse { Filenames = new List<string>() };
                    var templates = new Dictionary<Type, string>()
                    {
                        {typeof(Common_CodeSnippetsTemplate), "CodeSnippetsTemplate.cs"},
                    };
                    foreach (var keyValuePair in templates)
                    {
                        var templateType = keyValuePair.Key;
                        var fileName = keyValuePair.Value;
                        typeof(GenerateCodeProcessor).GetMethod("GenerateCode").MakeGenericMethod(templateType).Invoke(null, new object[]
                        {
                            tables, request, response, templateType.Name, fileName
                        });
                    }
                    return response;
                }
            });
        }


        public static GenerateCodeResponse GenerateCode<T>(Tables tables, GenerateCodeRequest request, GenerateCodeResponse response
            , string subFolder, string fileNameTemplate)
            where T : ITemplate, new()
        {
            foreach (var table in tables)
            {
                try
                {
                    var model = new T
                    {
                        IncludeRelationships = request.IncludeRelationship,
                        Table = table,
                        Tables = tables
                    };

                    string pageContent = model.TransformText();

                    var folderLocation = Path.Combine(request.FolderLocation, subFolder);

                    if (!Directory.Exists(folderLocation))
                        Directory.CreateDirectory(folderLocation);

                    string fileName = string.Format(fileNameTemplate, table.ClassName);
                    File.WriteAllText(Path.Combine(folderLocation, fileName), pageContent, Encoding.UTF8);
                    fileName = subFolder + "/" + fileName;
                    if (response.Filenames.IndexOf(fileName) < 0)
                        response.Filenames.Add(fileName);

                }
                catch (Exception e)
                {
                    MessageBox.Show(string.Format("{0} {1} Failed!", table.ClassName, subFolder));
                }
            }
            return response;
        }

    }
}
