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
    
    public partial class game_event
    {
        public byte eventEntry { get; set; }
        public System.DateTime start_time { get; set; }
        public System.DateTime end_time { get; set; }
        public decimal occurence { get; set; }
        public decimal length { get; set; }
        public int holiday { get; set; }
        public string description { get; set; }
        public byte world_event { get; set; }
        public Nullable<byte> announce { get; set; }
    }
}
