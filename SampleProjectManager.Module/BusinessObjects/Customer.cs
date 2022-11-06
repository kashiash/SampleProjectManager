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
	public class Customer : BaseObject
	{
		public Customer(Session session) : base(session)
		{ }


		string krs;
		string regon;
		string vatNumber;
		string workingAddress;
		string residenceAddress;
		string occupation;
		string company;
		string email;
		string lastName;
		string firstName;

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string FirstName
		{
			get => firstName;
			set => SetPropertyValue(nameof(FirstName), ref firstName, value);
		}


		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string LastName
		{
			get => lastName;
			set => SetPropertyValue(nameof(LastName), ref lastName, value);
		}


		[Size(20)]
		public string VatNumber
		{
			get => vatNumber;
			set => SetPropertyValue(nameof(VatNumber), ref vatNumber, value);
		}


		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Regon
		{
			get => regon;
			set => SetPropertyValue(nameof(Regon), ref regon, value);
		}

		
		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Krs
		{
			get => krs;
			set => SetPropertyValue(nameof(Krs), ref krs, value);
		}

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Email
		{
			get => email;
			set => SetPropertyValue(nameof(Email), ref email, value);
		}

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Company
		{
			get => company;
			set => SetPropertyValue(nameof(Company), ref company, value);
		}

		[Size(SizeAttribute.DefaultStringMappingFieldSize)]
		public string Occupation
		{
			get => occupation;
			set => SetPropertyValue(nameof(Occupation), ref occupation, value);
		}



		[Size(255)]
		public string ResidenceAddress
		{
			get => residenceAddress;
			set => SetPropertyValue(nameof(ResidenceAddress), ref residenceAddress, value);
		}


        [Size(255)]
        public string WorkingAddress
		{
			get => workingAddress;
			set => SetPropertyValue(nameof(WorkingAddress), ref workingAddress, value);
		}



		[Association("Customer-Testimonials")]
		public XPCollection<Testimonial> Testimonials
		{
			get
			{
				return GetCollection<Testimonial>(nameof(Testimonials));
			}
		}
		public string FullName { get {
				string namePart = string.Format("{0} {1}", FirstName, LastName);
				return Company != null ? string.Format("{0} {1}", namePart, Company) : namePart;
			}
		}

		byte[] photo;
		[ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
		public byte[] Photo
		{
			get => photo;
			set => SetPropertyValue(nameof(Photo), ref photo, value);
		}
	}
}
