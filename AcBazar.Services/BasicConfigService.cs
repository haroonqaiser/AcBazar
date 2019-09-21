using AcBazar.Database;
using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Services
{
    public class BasicConfigService
    {
        #region Singleton
        private static BasicConfigService instance { get; set; }
        public static BasicConfigService Instance
        {
            get
            {
                if (instance == null) instance = new BasicConfigService();
                return instance;
            }
        }
        BasicConfigService()
        {
        }

        #endregion
        public BasicConfiguration GetBasicConfiguration(string Key)
        {
            using (var context = new ACContext())
            {
                return context.BasicConfiguration.Find(Key);
            }

        }

        public List<BasicConfiguration> GetBasicConfigurations()
        {
            using (var context = new ACContext())
            {
                return context.BasicConfiguration.ToList();
            }

        }
    }
}
