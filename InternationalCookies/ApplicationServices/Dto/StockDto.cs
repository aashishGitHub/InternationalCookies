using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Dto
{
    public class StockDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? NumberOfItemsAvailable { get; set; }

        public int? NumberOfDefectiveItems { get; set; }

        public virtual ProductDto Product { get; set; }
    }
}
