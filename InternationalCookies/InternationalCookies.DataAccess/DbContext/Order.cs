namespace InternationalCookies.DataAccess.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public DateTime? DateOfOrder { get; set; }

        public int CustomerId { get; set; }

        public decimal? TotalCost { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
