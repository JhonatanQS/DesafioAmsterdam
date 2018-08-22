using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAmsterdam
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        { }

        public DbSet<TableHeaders> TableHeaders { get; set; }
        public DbSet<TableData> TableData { get; set; }
    }
    public class TableHeaders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableID { get; set; }
        public string TableName { get; set; }
        public string HeaderValues { get; set; }
    }
    public class TableData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TabeleDataID { get; set; }
        public TableHeaders TableHeader { get; set; }
        public string RowData { get; set; }
    }
}
