using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{
    public class IssueModel
    {
        public IssueModel()
        {

        }
        public Issue issueAttempt(String subjectIssueText, String descriptionText)
        {
            return DatabaseReader.issueQuerySingle("issue = '" + subjectIssueText + "' and description = '" + descriptionText + "';");
        }
    }
}