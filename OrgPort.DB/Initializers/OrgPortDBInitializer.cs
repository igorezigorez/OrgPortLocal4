﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.IO;
using System.Data.SqlServerCe;

namespace OrgPort.DB.Initializers
{
    public abstract class OrgPortDBInitializer<T>:IDatabaseInitializer<T> where T:DbContext
    {
        public abstract void InitializeDatabase(T context);

        private static string replacedConnectionString = string.Empty;

        public static string ReplacedConnectionString
        {
            get
            {
                return replacedConnectionString;
            }
        }

        protected virtual void Seed(T context)
        {
            ISeedDatabase seeder = context as ISeedDatabase;
            if (seeder != null)
            {
                seeder.Seed();
            }
        }

        protected static DbContext ReplaceSqlCeConnection(DbContext context)
        {
            if (context.Database.Connection is SqlCeConnection)
            {
                SqlCeConnectionStringBuilder builder =
                    new SqlCeConnectionStringBuilder(context.Database.Connection.ConnectionString);
                if (!String.IsNullOrWhiteSpace(builder.DataSource))
                {
                    builder.DataSource = ReplaceDataDirectory(builder.DataSource);
                    replacedConnectionString = builder.ConnectionString;
                    return new DbContext(replacedConnectionString);
                }
            }
            return context;
        }

        private static string ReplaceDataDirectory(string inputString)
        {
            string str = inputString.Trim();
            if (string.IsNullOrEmpty(inputString) ||
                !inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }
            string data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (string.IsNullOrEmpty(data))
            {
                data = AppDomain.CurrentDomain.BaseDirectory ?? Environment.CurrentDirectory;
            }
            if (string.IsNullOrEmpty(data))
            {
                data = string.Empty;
            }
            int length = "|DataDirectory|".Length;
            if ((inputString.Length > "|DataDirectory|".Length) && ('\\' == inputString["|DataDirectory|".Length]))
            {
                length++;
            }
            return Path.Combine(data, inputString.Substring(length));
        }
    }
}
