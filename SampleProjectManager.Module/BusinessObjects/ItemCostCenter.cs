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
    public class ItemCostCenter : BaseObject
    {
        public ItemCostCenter(Session session) : base(session)
        { }


        decimal amount;
        string description;
        InvoiceItem invoiceItem;

        [Association("InvoiceItem-ItemCostCenters")]
        public InvoiceItem InvoiceItem
        {
            get => invoiceItem;
            set => SetPropertyValue(nameof(InvoiceItem), ref invoiceItem, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        public decimal Amount
        {
            get => amount;
            set => SetPropertyValue(nameof(Amount), ref amount, value);
        }

    }
}
