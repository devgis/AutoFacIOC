using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacIOC
{
    /// <summary>
    /// 对redis数据源操作
    /// </summary>
    public class RedisRepository : IRepository
    {
        #region IRepository 成员

        public void Get()
        {
            Console.WriteLine("Redis数据源");
        }

        #endregion
    }
}
