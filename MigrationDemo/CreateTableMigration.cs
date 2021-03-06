﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

namespace MigrationDemo
{
    [Migration("1.0.0", 1, MigrationDemoApp.ProductName)]
    public class CreateTableMigration : MigrationBase
    {
        public CreateTableMigration(ISqlSyntaxProvider sqlSyntax, ILogger logger) 
            : base(sqlSyntax, logger)
        {
        }

        public override void Down()
        {
            Logger.Debug<CreateTableMigration>("Deleting tables");
            var tables = SqlSyntax.GetTablesInSchema(Context.Database).ToArray();

            if (tables.InvariantContains(MigrationDemoApp.SimpleTableName))
            {
                Delete.Table(MigrationDemoApp.SimpleTableName);
            }
        }

        public override void Up()
        {
            Logger.Debug<CreateTableMigration>("Creating tables");

            var tables = SqlSyntax.GetTablesInSchema(Context.Database).ToArray();

            if (!tables.InvariantContains(MigrationDemoApp.SimpleTableName))
            {
                Create.Table<SimplePoco>();
            }
        }
    }
}
