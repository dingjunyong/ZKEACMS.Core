﻿/*!
 * http://www.zkea.net/
 * Copyright 2017 ZKEASOFT
 * http://www.zkea.net/licenses
 */

using Easy.RepositoryPattern;
using Microsoft.EntityFrameworkCore;
using Easy.Extend;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;

namespace ZKEACMS.WebHost
{
    public class EntityFrameWorkConfigure : IOnConfiguring
    {
        public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connections = Easy.Builder.Configuration.GetSection("ConnectionStrings");
            var connectionString = connections["DefaultConnection"];
            if (connectionString.IsNotNullAndWhiteSpace())
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else if ((connectionString = connections["Sqlite"]).IsNotNullAndWhiteSpace())
            {
                optionsBuilder.UseSqlite(connectionString);
            }
            else if ((connectionString = connections["MySql"]).IsNotNullAndWhiteSpace())
            {
                optionsBuilder.UseMySQL(connectionString);
            }

        }
    }
}
