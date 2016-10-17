using System;
using System.Collections.Generic;
using System.Linq;
using Training4Developers.Interfaces;
using Training4Developers.Enums;

namespace Training4Developers.Models {
	public class Student : IStudent {
		private IList<IContactInfo> _contactInfos;
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public IEnumerable<IContactInfo> EmailAddresses {
			get {
				return _contactInfos.Where(contactInfo => contactInfo.Method == ContactMethods.EmailAddress);
			}
		}
		public Student() {
			_contactInfos = new List<IContactInfo>();
		}
		public IStudent AppendEmailAddress(IContactInfo emailAddress) {

			if (emailAddress == null) {
				throw new NullReferenceException("Email Address cannot be null.");
			}

			this._contactInfos.Add(emailAddress);

			return this;
		}
		public IStudent RemoveEmailAddress(int emailAddressId) {

			if (emailAddressId < 1) {
				throw new Exception("Email Address Id must be greater than zero.");
			}

			this._contactInfos.Remove(this._contactInfos.Single(contactInfo =>
				contactInfo.Id == emailAddressId));

			return this;
		}
	}

}