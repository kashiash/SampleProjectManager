using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using SampleProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectManager.Module.Controllers
{
    public class InviceItemsDetailViewController : ViewController
    {
        SimpleAction copyToInvoiceItemsAction;
        SimpleAction addItemsAction;
        public InviceItemsDetailViewController() : base()
        {

            TargetObjectType = typeof(InvoiceItem);
            // Target required Views (use the TargetXXX properties) and create their Actions.
            addItemsAction = new SimpleAction(this, "AddItemsAction", DevExpress.Persistent.Base.PredefinedCategory.Unspecified);
            addItemsAction.Execute += addItemsAction_Execute;

            copyToInvoiceItemsAction = new SimpleAction(this, "CopyAction", DevExpress.Persistent.Base.PredefinedCategory.Unspecified);
            copyToInvoiceItemsAction.Execute += copyToInvoiceItemsAction_Execute;
            

        }
        private void copyToInvoiceItemsAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var invoiceItem = (InvoiceItem)View.CurrentObject;
            var invoice = invoiceItem.Invoice;

            foreach (var invitem in invoice.InvoiceItems)
            {
                if (invitem == invoiceItem) continue;
                foreach (var rec in invoiceItem.ItemCostCenters)
                {
                    var item = ObjectSpace.CreateObject<ItemCostCenter>();
                    item.InvoiceItem = invitem;
                    item.Amount = invitem.ItemAmount / 20.0m;
                    item.Description = rec.Description;
                    invitem.ItemCostCenters.Add(item);
                }
                ObjectSpace.SetModified(invoiceItem);
                ObjectSpace.CommitChanges();
            }
        }
        private void addItemsAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var invoiceItem = (InvoiceItem)View.CurrentObject;
            for (int i = 0; i < 20; i++)
            {
                var item = ObjectSpace.CreateObject<ItemCostCenter>();
                item.InvoiceItem = invoiceItem;
                item.Amount = invoiceItem.ItemAmount / 20.0m;
                item.Description = $"Item{i} {item.Amount}";
                invoiceItem.ItemCostCenters.Add(item);
            }
            ObjectSpace.SetModified(invoiceItem);
            ObjectSpace.CommitChanges();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }

}
