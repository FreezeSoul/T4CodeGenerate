# This is a new version of code generate base T4. #
    
    这是一个新版的T4代码生成工具，有别于我的另一个代码生成工具，这个版本支持多种数据库（MySQL、MSSQL、Npgsql、SQLite）。
    
新增T4模板的简要说明：

1. 在CodeGen项目中建立需要新增的T4模板文件，完成模板逻辑
2. 设置T4模板文件属性中Custom Tool的为TextTemplatingFilePreprocessor
3. 建立模板类对应的Partial类，继承ITemplate接口（参照内部示例，可新增属性）
4. 给Partial类增加OutputFileNameAttribute特性，设置输出的代码文件名称
4. 编译运行项目，选择需要生成的数据库类型，点击执行即可

PS:[我的另一个代码生成工具](https://github.com/FreezeSoul/CodeGenerator)