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
	[NavigationItem("Marketing")]
	public class Testimonial : BaseObject
	{
		public Testimonial(Session session) : base(session)
		{ }



		Customer customer;
		string tags;
		DateTime createdOn;
		string quote;
		string highlight;


		[Size(SizeAttribute.Unlimited)]
		public string Quote
		{
			get => quote;
			set => SetPropertyValue(nameof(Quote), ref quote, value);
		}
		[Size(512)]
		public string Highlight
		{
			get => highlight;
			set => SetPropertyValue(nameof(Highlight), ref highlight, value);
		}


		public DateTime CreatedOn
		{
			get => createdOn;
			set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
		}

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Tags
		{
			get => tags;
			set => SetPropertyValue(nameof(Tags), ref tags, value);
		}

		
		[Association("Customer-Testimonials")]
		public Customer Customer
		{
			get => customer;
			set => SetPropertyValue(nameof(Customer), ref customer, value);
		}
	}
}
