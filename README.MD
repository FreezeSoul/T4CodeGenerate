# This is a new version of code generate base T4. #
    
    这是一个新版的T4代码生成工具，有别于我的另一个代码生成工具，这个版本支持多种数据库（MySQL、MSSQL、Npgsql、SQLite）。
    
使用方式简要说明：

1. 在CodeGen项目中建立需要的T4模板文件
2. 设置T4模板文件属性中Custom Tool的为TextTemplatingFilePreprocessor
3. 建立对应的Partial类，增加模板文件类型实例需要访问的属性，并与其赋值
4. 在CodeGen.UI项目GenerateCodeProcessor类中增加需要的处理的T4模板元数据

PS:[我的另一个代码生成工具](https://github.com/FreezeSoul/CodeGenerator)