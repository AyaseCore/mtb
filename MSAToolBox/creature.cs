//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSAToolBox
{
    using System;
    using System.Collections.Generic;
    
    public partial class creature
    {
        public long guid { get; set; }
        public int id { get; set; }
        public int map { get; set; }
        public int zoneId { get; set; }
        public int areaId { get; set; }
        public byte spawnMask { get; set; }
        public long phaseMask { get; set; }
        public int modelid { get; set; }
        public sbyte equipment_id { get; set; }
        public float position_x { get; set; }
        public float position_y { get; set; }
        public float position_z { get; set; }
        public float orientation { get; set; }
        public long spawntimesecs { get; set; }
        public float spawndist { get; set; }
        public int currentwaypoint { get; set; }
        public long curhealth { get; set; }
        public long curmana { get; set; }
        public byte MovementType { get; set; }
        public long npcflag { get; set; }
        public long unit_flags { get; set; }
        public long dynamicflags { get; set; }
        public Nullable<short> VerifiedBuild { get; set; }
    }
}
