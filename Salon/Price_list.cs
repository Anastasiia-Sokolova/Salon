//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price_list
    {
        public int MasterId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}