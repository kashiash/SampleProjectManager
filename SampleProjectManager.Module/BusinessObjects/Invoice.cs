using DevExpress.Pdf.Native.BouncyCastle.Utilities;
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
    public class Invoice : BaseObject
    {
        public Invoice(Session session) : base(session)
        { }


        decimal invoiceAmount;
        string invoiceNumber;
        string invoiceDate;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceDate
        {
            get => invoiceDate;
            set => SetPropertyValue(nameof(InvoiceDate), ref invoiceDate, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceNumber
        {
            get => invoiceNumber;
            set => SetPropertyValue(nameof(InvoiceNumber), ref invoiceNumber, value);
        }

        public decimal InvoiceAmount
        {
            get => invoiceAmount;
            set => SetPropertyValue(nameof(InvoiceAmount), ref invoiceAmount, value);
        }

        [Association("Invoice-InvoiceItems"), Aggregated]
        public XPCollection<InvoiceItem> InvoiceItems
        {
            get
            {
                return GetCollection<InvoiceItem>(nameof(InvoiceItems));
            }
        }

        internal void RecalculateTotals(bool forceChangeEvents)
        {
            decimal oldInvoiceAmount = InvoiceAmount;
            decimal tmpInvoiceAmount = 0m;
            foreach (var rec in InvoiceItems)
            {
                tmpInvoiceAmount += rec.ItemAmount;
            }
            InvoiceAmount = tmpInvoiceAmount;
            if (forceChangeEvents)
            {
                OnChanged(nameof(InvoiceAmount), oldInvoiceAmount, InvoiceAmount);
            }
        }
    }
}
