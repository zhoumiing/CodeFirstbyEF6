# CodefirstByEF6
 Code first testing to create tables in sqlite by EF6


[功能描述]：以编写代码，通过EF6管理数据库的开发模式。

[开发环境]：
mac os 11
visual studio for mac
.net 6

[项目结构]：
visual studio for mac, web and console/app/asp.net core 模版创建项目
framework: .net 6.0
option: no https, use controller, enable openAPI, Do not use top-level statement.

[使用说明]：
重现项目，只需要修改Models/ Dbconn.cs 文件
"Data Source= "，定义本地sqlite3的db文件路径。

NuGet安装以下包：
Microsoft.EntityFrameworkCore，EF框架基本包。
Microsoft.EntityFrameworkCore.sqlite， sqlite数据库，需要EF支持sqlite 的包。
Microsoft.EntityFramework.Core.Design，使用Migrations所需要的包。
根据情况安装 Microsoft.EntityFramework.Core.tools, 以获得dotnet ef tools

cli 命令：
dotnet ef migrations add 1stCreate --project= {本地csproj文件路径}

dotnet ef migrations list --project= {本地csproj文件路径}


