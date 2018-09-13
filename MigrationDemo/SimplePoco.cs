using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace MigrationDemo
{
    [TableName("DemoPocoTable")]
    [PrimaryKey("Id")]
    public class SimplePoco
    {
        [PrimaryKeyColumn]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
    }
}
