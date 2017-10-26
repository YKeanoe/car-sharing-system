using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using car_sharing_system.Models;
using System.Text;

namespace car_sharing_system.Admin_Theme.pages
{
    public partial class adminissue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
			List<Issue> issues = DatabaseReader.issueQueryAdmin();
			issuetableph.Controls.Add(new LiteralControl(stringifyIssues(issues)));
		}

		private static String stringifyIssues(List<Issue> issues) {
			//List<String> issuehtml = new List<String>();
			StringBuilder issuehtml = new StringBuilder();
			int i = 0;
			if (issues != null && issues.Any()) {
				foreach (Issue issue in issues) {
					String html;
					if (issue.isResponsed()) {
						html = String.Format("<tr data-toggle=\"collapse\" data-target=\"#issue{0}\" class=\"accordion-toggle table-success\">"
											+ "<td>{1}</td>"
											+ "<td>{2}</td>"
											+ "<td>{3}</td>"
											+ "<td><i class=\"fa fa-check fa-fw\"></i></td>"
											+ "<td>{4}</td>"
											+ "</tr>"
											+ "<tr >"
											+ "<td colspan=\"6\" class=\"hiddenRow\">"
											+ "<div class=\"accordian-body collapse\" id=\"issue{0}\">"
											+ "{5}"
											+ "</div> "
											+ "</td>"
											+ "</tr>",
											i,
											new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(issue.submissionDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
											issue.username,
											issue.subject,
											new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(issue.responseDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
											issue.description);
					} else {
						html = String.Format("<tr data-toggle=\"collapse\" data-target=\"#issue{0}\" class=\"accordion-toggle table-warning\">"
										+ "<td>{1}</td>"
										+ "<td>{2}</td>"
										+ "<td>{3}</td>"
										+ "<td><i class=\"fa fa-times fa-fw\"></i></td>"
										+ "<td>-</td>"
										+ "</tr>"
										+ "<tr >"
										+ "<td colspan=\"6\" class=\"hiddenRow\">"
										+ "<div class=\"accordian-body collapse\" id=\"issue{0}\">"
										+ "{4}"
										+ "<br/>"
										+ "<a class=\"btn btn-primary btn-respond\" href=\"/dashboard/admin/respond?id={5}\" role=\"button\">Respond</a>"
										+ "</div> "
										+ "</td>"
										+ "</tr>",
										i,
										new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(issue.submissionDate)).ToLocalTime().ToString("ddddd, dd MMMM yyyy 'at' hh:mm"),
										issue.username, issue.subject,
										issue.description, issue.issueID);
					}
					i++;
					issuehtml.Append(html);
				}
			}
			return issuehtml.ToString();
		}
	}
}