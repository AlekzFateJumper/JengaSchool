using System;
using System.Collections.Generic;

namespace JengaSchool.Data
{
    [Serializable]
    public class BlockData
    {
        public int id;
        public string subject;
        public string grade;
        public int mastery;
        public string domainid;
        public string domain;
        public string cluster;
        public string standardid;
        public string standarddescription;

        public BlockData() {}
    }

    [Serializable]
    public class ListData
    {
        public List<BlockData> list;
    }
}
