//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public int IdEquipment { get; set; }
        public int IdAutopart { get; set; }
        public int IdShipmen { get; set; }
        public int Qty { get; set; }
    
        public virtual Autopart Autopart { get; set; }
        public virtual Shipmen Shipmen { get; set; }
    }
}
