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
    
    public partial class spell_proc_event
    {
        public int entry { get; set; }
        public sbyte SchoolMask { get; set; }
        public int SpellFamilyName { get; set; }
        public long SpellFamilyMask0 { get; set; }
        public long SpellFamilyMask1 { get; set; }
        public long SpellFamilyMask2 { get; set; }
        public long procFlags { get; set; }
        public long procEx { get; set; }
        public float ppmRate { get; set; }
        public float CustomChance { get; set; }
        public long Cooldown { get; set; }
    }
}
