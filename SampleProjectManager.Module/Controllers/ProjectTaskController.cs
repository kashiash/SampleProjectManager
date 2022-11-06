using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using SampleProjectManager.Module.BusinessObjects;

namespace SampleProjectManager.Module.Controllers
{
    public class ProjectTaskController :ViewController
    {
        public ProjectTaskController()
        {
            TargetObjectType = typeof(ProjectTask);
            TargetViewType = ViewType.Any;

            SimpleAction marklCompletedAction = new SimpleAction(this, "MarkCompleted", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit);
            marklCompletedAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
            marklCompletedAction.Execute += MarklCompletedAction_Execute; 
        }

        private void MarklCompletedAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (ProjectTask task in e.SelectedObjects)
            {
                task.EndDate = DateTime.Now;
                task.Status = ProjectTaskStatus.Completed;
                View.ObjectSpace.SetModified(task);

            }
            View.ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
    }
}
