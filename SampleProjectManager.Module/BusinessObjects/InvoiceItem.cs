using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectManager.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class InvoiceItem : BaseObject
    {
        public InvoiceItem(Session session) : base(session)
        { }


        decimal itemAmount;
        string productName;
        Invoice invoice;

        [Association("Invoice-InvoiceItems")]
        public Invoice Invoice
        {
            get => invoice;
            set
            {
                var oldInvoice = invoice;
                var modified = SetPropertyValue(nameof(Invoice), ref invoice, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    oldInvoice?.RecalculateTotals(true);
                    invoice?.RecalculateTotals(true);
                }
            }
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }


        public decimal ItemAmount
        {
            get => itemAmount;
            set => SetPropertyValue(nameof(ItemAmount), ref itemAmount, value);
        }
        [Association("InvoiceItem-ItemCostCenters"), Aggregated]

        public XPCollection<ItemCostCenter> ItemCostCenters
        {
            get
            {
                return GetCollection<ItemCostCenter>(nameof(ItemCostCenters));
            }
        }
    }
}
