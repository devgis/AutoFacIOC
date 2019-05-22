using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacIOC
{
    /// <summary>
    /// 数据源基类
    /// </summary>
    public class DBBase
    {
        public DBBase(IRepository iRepository)
        {
            _iRepository = iRepository;
        }
        public IRepository _iRepository;
        public void Search(string commandText)
        {
            _iRepository.Get();
        }
    }
}
