using System;

namespace car_sharing_system.Models
{
    public class Issue
    {
        public int accountID { get; private set; }
		public long submissionDate { get; private set; }
		public long? responseDate { get; private set; }
		public String subject { get; private set; }
        public String description { get; private set; }
		public String username { get; set; }

		// Constructor to be used in adding responded issue.
        public Issue(
            int accountID,
			long submissionDate,
			long responseDate,
			String subject,
            String description
            )
        {
            this.accountID = accountID;
			this.submissionDate = submissionDate;
			this.responseDate = responseDate;
			this.subject = subject;
            this.description = description;
        }

		// Constructor to be used in adding unresponded issue.
		public Issue(
			int accountID,
			long submissionDate,
			String subject,
			String description
			) {
			this.accountID = accountID;
			this.submissionDate = submissionDate;
			this.subject = subject;
			this.description = description;
		}
		
		// Constructor to be used in adding new issue.
		// Since submission date is added on database reader now
		public Issue(
			int accountID,
			String subject,
			String description
			) {
			this.accountID = accountID;
			this.subject = subject;
			this.description = description;
		}

		public bool isResponsed() {
			if (responseDate == null) {
				return false;
			} else {
				return true;
			}
		}

		public String toString()
        {
            return "accountID: " + accountID + "<br />" +
                "submissionDate: " + submissionDate + "<br />" +
                "subject: " + subject + "<br />" +
                "description: " + description + "<br />" ;
        }
    }
}