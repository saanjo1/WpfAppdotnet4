using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp48.ViewModels
{
    public class DiscountDisplayVM
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public bool isExecuted { get; set; }
        public bool isActive { get; set; }
        public string Type { get; set; }
    }
}
