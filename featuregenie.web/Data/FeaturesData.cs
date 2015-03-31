﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public class FeaturesData : BaseRepository
    {
        public List<Feature> GetAll()
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature").ToList();
        }
        public Feature Get(int id)
        {
            return Db.Query<Feature>(@"SELECT * FROM genie.Feature WHERE FeatureId = @FeatureId", new { FeatureId = id }).First();
        }

        public void Create(Feature feature)
        {
            Db.Execute(@"INSERT INTO genie.Feature (Name, Description, IsEnabled, StartTime, EndTime, Ratio) VALUES (@Name, @Description, @IsEnabled, @StartTime, @EndTime, @Ratio)", feature);
        }

        public void Update(Feature feature)
        {
            Db.Execute(@"UPDATE genie.Feature SET Name = @Name, Description = @Description, IsEnabled = @IsEnabled, StartTime = @StartTime, EndTime = @EndTime, Ratio = @Ratio WHERE FeatureId = @FeatureId", feature);
        }

        public void Delete(int id)
        {
            Db.Execute(@"DELETE FROM genie.Feature WHERE FeatureId = @FeatureId", new { FeatureId = id });
        }
    }
}