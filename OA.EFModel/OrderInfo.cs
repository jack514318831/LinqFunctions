//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderInfo
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int UserInfoUserId { get; set; }
    
        public virtual UserInfoSet UserInfoSet { get; set; }
    }
}