﻿using Xigadee;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Test.Xigadee
{
    static partial class Program
    {
        enum PersistenceOptions
        {
            Sql,
            DocumentDb,
            RedisCache,
            Blob
        }

        static Lazy<ConsoleMenu> sPersistenceSettingsMenu = new Lazy<ConsoleMenu>(
            () => new ConsoleMenu(
                $"Persistence store options"
                , new ConsoleOption("Sql based Persistence"
                    , (m, o) =>
                    {
                        sContext.PersistenceType = PersistenceOptions.Sql;
                    }
                    , enabled: (m, o) => true
                    , selected: (m, o) => sContext.PersistenceType == PersistenceOptions.Sql
                )
                , new ConsoleOption("DocumentDb based Persistence"
                    , (m, o) =>
                    {
                        sContext.PersistenceType = PersistenceOptions.DocumentDb;
                    }
                    , enabled: (m, o) => true
                    , selected: (m,o) => sContext.PersistenceType == PersistenceOptions.DocumentDb
                )
                , new ConsoleOption("Blob storage based Persistence"
                    , (m, o) =>
                    {
                        sContext.PersistenceType = PersistenceOptions.Blob;
                    }
                    , enabled: (m, o) => true
                    , selected: (m, o) => sContext.PersistenceType == PersistenceOptions.Blob
                )
                , new ConsoleOption("Redis Cache based Persistence"
                    , (m, o) =>
                    {
                        sContext.PersistenceType = PersistenceOptions.RedisCache;
                    }
                    , enabled: (m, o) => true
                    , selected: (m, o) => sContext.PersistenceType == PersistenceOptions.RedisCache
                )
                , new ConsoleOption("Client RedisCache enabled"
                    , (m, o) =>
                    {
                        sContext.ClientCacheEnabled = !sContext.ClientCacheEnabled;
                    }
                    , enabled: (m, o) => true
                    , selected: (m, o) => sContext.ClientCacheEnabled
                )
                , new ConsoleOption("Server RedisCache enabled"
                    , (m, o) =>
                    {
                        sContext.ServerCacheEnabled = !sContext.ServerCacheEnabled;
                    }
                    , enabled: (m, o) => true
                    , selected: (m, o) => sContext.ServerCacheEnabled
                )
                )
            );
    }
}