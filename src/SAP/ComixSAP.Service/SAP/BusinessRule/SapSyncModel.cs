using System.Collections.Generic;

namespace ComixSAP.Service
{
    public class SapSyncModel
    {
        // 方法名
        public string Name { get; set; }
        // 参数字符串
        public string paramStr { get; set; }
        // 是否同步
        public bool IsSync { get; set; }
        // 同步类型（0:增量|1:全量）
        public string SyncType { get; set; }

        public string rfcFunName { get; set; }
        //映射关系表
        private HashSet<string> _rfctables;
        public HashSet<string> rfcTables
        {
            get
            {
                if (_rfctables == null)
                    _rfctables = new HashSet<string>(); 
                return _rfctables;
            }
            set { _rfctables = value; }
        }
    }

}
