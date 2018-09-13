# Our.Umbraco.MigrationHelper
Migration Helper class for Umbraco

Makes migrations that little bit easier by letting you impliment an Interface and that be all. 

If you have a class that impliments IUmbracoApp:

```
public class MigrationDemoApp : IUmbracoApp
{
    public string Name => "Jumoo.MySampleApp";
    public string Version => "1.0.0";
}
```

then the MigrationHelper will run all migrations that also have the same name as your appl

```
[Migration("1.0.0", 1, MigrationDemoApp.ProductName)]
public class CreateTableMigration : MigrationBase
{
   // your super migration goes here.
}

```

This might be something that belongs in the Umbraco Core ? but we are building the package to guage the intrest 
- test out the validity of the idea.
