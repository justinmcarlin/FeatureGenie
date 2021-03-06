﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public class ApplicationsRepository : BaseRepository
    {
        public List<Application> GetAll()
        {
            return Db.Query<Application>(@"SELECT ApplicationId, Name FROM genie.Application").ToList();
        }

        public void Add(Application application)
        {
            Db.Execute(@"INSERT INTO [genie].[Application] ([Name], [Description]) VALUES (@Name, @Description)",
                new {application.Name, application.Description});
        }
    }
}