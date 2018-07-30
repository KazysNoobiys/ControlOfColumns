using System.ComponentModel.DataAnnotations;

namespace ControlOfColumns.WEB.Models
{
    public class ColumnsAdmin
    {
        public bool NameEnabled { get; set; }
        public bool PriceEnabled { get; set; }
        public bool QuantityEnabled { get; set; }
        public bool DescriptionEnabled { get; set; }
        public bool CommnetsEnabled { get; set; }
    }
}