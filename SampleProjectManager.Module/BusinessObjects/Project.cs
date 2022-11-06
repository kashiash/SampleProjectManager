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
    public class Project : BaseObject
	{
		public Project(Session session) : base(session)
		{ }


		string description;
		Person manager;
		string name;

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Name
		{
			get => name;
			set => SetPropertyValue(nameof(Name), ref name, value);
		}

		public Person Manager
		{
			get => manager;
			set => SetPropertyValue(nameof(Manager), ref manager, value);
		}
		
		[Size(SizeAttribute.Unlimited)]
		public string Description
		{
			get => description;
			set => SetPropertyValue(nameof(Description), ref description, value);
		}

		[Association("Project-Tasks")]
		public XPCollection<ProjectTask> Tasks
		{
			get
			{
				return GetCollection<ProjectTask>(nameof(Tasks));
			}
		}
	}
}
