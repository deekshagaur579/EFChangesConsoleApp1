//using Microsoft.EntityFrameworkCore;
using EFSPConsoleApp1.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MassTransit.ValidationResultExtensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFSPConsoleApp1
{
    internal class Program
    {
       
        public static void Main(string[] args)
        {
            DbContext context = new WorkDayEntitiesNew();//WorkDayEntities3();
            WorkDayEntitiesNew entity = new WorkDayEntitiesNew();//
            Console.WriteLine("hello");
            var result = entity.get_data(true);
            DataTable dt = ToDataTable(result);
            PrintTable(dt);
            var result1 = entity.get_data1(false);
            DataTable dt1 = ToDataTable(result1);
            PrintTable(dt1);
            //DbContext context = WorkDayEntities3();
            //WorkDayEntities3 entity = new WorkDayEntities3();
            //Console.WriteLine("hello");
            //string connectionString = GetADOConnectionString();
            //Console.WriteLine(connectionString);
            //foreach (string sp in GetStoredProcedures(context))
            //{
            //    Console.WriteLine(sp);
            //    Console.WriteLine("SELECT statements from stored procedures:" + sp);
            //    List<string> selectline = GetStoredProceduresFromDatabase(connectionString, sp);
            //    foreach (string line in selectline.Skip(1))
            //    {
            //        Console.WriteLine(line);
            //        getPrintData(connectionString, line);// from database
            //        var result = entity.get_data(true);
            //        DataTable dt = ToDataTable(result);
            //        PrintTable(dt);
            //        var result1 = entity.get_data(false);
            //        DataTable dt1 = ToDataTable(result);
            //        PrintTable(dt1);
            //    }
            //}
            Console.ReadKey();
        }
        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static string GetADOConnectionString()
        {
            //WorkDayEntities3 ctx = new WorkDayEntities3(); //create your entity object here
            //string str = ctx.Database.Connection.ConnectionString;
            //return str;
            return null;
        }

        public static List<string> GetStoredProcedures(DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var container = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);

            var storedProcedures = new List<string>();

            foreach (var functionImport in container.FunctionImports)
            {
                storedProcedures.Add(functionImport.Name);
            }
            return storedProcedures;
        }

        public static List<string> GetStoredProceduresFromDatabase(string connectionString,string sp)
        {
            string storedProcedure = "";
            List<string> spSelectStatements = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT ROUTINE_NAME, ROUTINE_DEFINITION                
                                 FROM INFORMATION_SCHEMA.ROUTINES                
                                 WHERE ROUTINE_TYPE = 'PROCEDURE' AND ROUTINE_NAME = '" + sp + "'";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            spSelectStatements = ExtractSelectStatements(reader.GetString(1));
                        }
                    }
                }
            }

            return spSelectStatements;
        }
        static List<string> ExtractSelectStatements(string spDefinition)
        {
            var selectStatements = new List<string>();
            var regex = new Regex(@"SELECT\s+(?:(?!SELECT|INSERT|UPDATE|DELETE|MERGE|ELSE).)*?(?=ELSE|$)",
                                  RegexOptions.IgnoreCase | RegexOptions.Singleline);

            var matches = regex.Matches(spDefinition);
            foreach (Match match in matches)
            {
                selectStatements.Add(match.Value.Trim());
            }

            return selectStatements;
        }

        public static void PrintTable(DataTable table)
        {
            // Print column headers
            foreach (DataColumn column in table.Columns)
            {
                Console.Write($"{column.ColumnName,-15}");
            }
            Console.WriteLine();

            // Print separator
            Console.WriteLine(new string('-', table.Columns.Count * 15));

            // Print rows
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15}");
                }
                Console.WriteLine();
            }
        }

        public static void getPrintData(string connectionString,string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Print table data
                        PrintTable(dataTable);
                    }
                }
            }
        }

    }
}
