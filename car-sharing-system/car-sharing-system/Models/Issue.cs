using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class Issues
    {
        public int issueID { get; private set; }
        public int accountID { get; private set; }
        public int bookingID { get; private set; }
        public int submissionDate { get; private set; }
        public String subject { get; private set; }
        public String description { get; private set; }
       
        public Issues(
            int issueID,
            int accountID,
            int bookingID,
            int submissionDate,
            String subject,
            String description
            )
        {
            this.issueID = issueID;
            this.accountID = accountID;
            this.bookingID = bookingID;
            this.submissionDate = submissionDate;
            this.subject = subject;
            this.description = description;
        }

        public String toString()
        {
            return "issueID: " + issueID + "<br />" +
                "accountID: " + accountID + "<br />" +
                "bookingID: " + bookingID + "<br />" +
                "submissionDate: " + submissionDate + "<br />" +
                "subject: " + subject + "<br />" +
                "description: " + description + "<br />" ;
        }
    }
}