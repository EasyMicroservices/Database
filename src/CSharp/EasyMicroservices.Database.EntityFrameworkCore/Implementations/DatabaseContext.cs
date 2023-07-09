using EasyMicroservices.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.Database.EntityFrameworkCore.Implementations
{
    internal class DatabaseContext : IContext
    {
        public DatabaseContext(DbContext dbContext)
        {
            _dbContext = dbContext;
            ContextType = _dbContext.GetType();
        }

        DbContext _dbContext;
        public Type ContextType { get; set; }

        public string GetContextName()
        {
            return ContextType.Name;
        }
    }
}
