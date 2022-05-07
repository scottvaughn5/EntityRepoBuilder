using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.QueryBuilder
{
    public class Queries
    {
        public static string ConvertRead(string read_fields, string table_name, string table_alias)
        {
            return $"select {read_fields} from {table_name} {table_alias}";
        }

        public static string ConvertUpdate(string update_fields, string table_name, string table_alias)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("update ");
            builder.Append(table_alias);
            builder.AppendLine(" set ");
            builder.AppendLine(update_fields);
            builder.AppendLine(" from ");
            builder.Append(table_name);
            builder.Append(" ");
            builder.AppendLine(table_alias);
            return builder.ToString();
        }

        public static string ConvertCreate(string create_fields, string table_name, string table_alias)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("insert into ");
            builder.Append(table_name);
            builder.Append(" ( ");
            builder.AppendLine(create_fields);
            builder.Append(") values ");
            return builder.ToString();
        }
        public string Destroy => @"
            delete from {table_name} where {id_column} in {id_tuple}            
";
    }
}
