﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList.Controllers
{
    namespace Database
    {
        public enum DataType
        {
            ftInt,
            ftVarchar,
            ftBool,
        }
        public struct DbColumn
        {
            public string Name;
            public Type Type;
            private FieldInfo Infos;

            public DbColumn(FieldInfo fieldInfo)
            {
                Name = fieldInfo.Name;
                Type = fieldInfo.FieldType;
                Infos = fieldInfo;
            }
        }
        public sealed class DbController : ApiController
        {
            private static ApplicationDbContext _context;

            public static ApplicationDbContext Context
            {
                get => (_context != null) ? _context : _context = new ApplicationDbContext();
            }

            public static IEnumerable<DbColumn> PollSchema<T>() where T: new()
            {
                T instance = new T();

                var columns = new List<DbColumn>();
                
                foreach(FieldInfo field in instance.GetType().GetFields()) 
                    columns.Add(new DbColumn(field));

                return columns;
            }

        }
    }
}