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
    [NavigationItem("Planning")]
    public class ProjectTask : BaseObject
	{
		public ProjectTask(Session session) : base(session)
		{ }


		string notes;
		Project project;
		DateTime endDate;
		DateTime startDate;
		Person assignedTo;
		ProjectTaskStatus status;
		string subject;

		[Size(256)]
		public string Subject
		{
			get => subject;
			set => SetPropertyValue(nameof(Subject), ref subject, value);
		}

		public ProjectTaskStatus Status
		{
			get => status;
			set => SetPropertyValue(nameof(Status), ref status, value);
		}

		public Person AssignedTo
		{
			get => assignedTo;
			set => SetPropertyValue(nameof(AssignedTo), ref assignedTo, value);
		}


		public DateTime StartDate
		{
			get => startDate;
			set => SetPropertyValue(nameof(StartDate), ref startDate, value);
		}

		public DateTime EndDate
		{
			get => endDate;
			set => SetPropertyValue(nameof(EndDate), ref endDate, value);
		}

		
		[Size(SizeAttribute.Unlimited)]
		public string Notes
		{
			get => notes;
			set => SetPropertyValue(nameof(Notes), ref notes, value);
		}

		[Association("Project-Tasks")]
		public Project Project
		{
			get => project;
			set => SetPropertyValue(nameof(Project), ref project, value);
		}
	}

public enum ProjectTaskStatus
	{
		NotStarted = 0,
		InProgress = 1,
		Completed = 2,
		Deferred = 3
	}

}
