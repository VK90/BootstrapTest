using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactList;
using System.Configuration;

namespace BootstrapTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string CON_STR = ConfigurationManager.ConnectionStrings["CON_STR"].ConnectionString;
        List<ContactList.Contact> myContacts = new List<ContactList.Contact>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["DelId"] != null)
            {
                ContactManager.DeleteContact(Request.QueryString["DelId"].ToString(), CON_STR);
                Response.Redirect("~/Main.aspx");
            }
            myContacts = ContactManager.LoadContacts(CON_STR);
            LoadContacts();
        }

        protected void LoadContacts()
        {
            if (myContacts.Count > 0)
            {
                string info = "";
                #region Some text
                info += "<div class=\"container\">";
                info += "<div class=\"table-responsive\">";
                info += "<table class=\"table\">";
                info += "<thead>";
                info += "<tr>";
                info += " <th>#</th>";
                info += " <th>Firstname</th>";
                info += " <th>Lastname</th>";
                info += " <th>SSN</th>";
                info += " <th>&nbsp</th>";
                info += "</tr>";
                info += "</thead>";
                info += "<tbody>";
                #endregion

                int counter = 1;
                foreach (var tmpContact in myContacts)
                {

                    info += "<tr>";
                    info += $" <td>{counter++}</td>";
                    info += $" <td>{tmpContact.FirstName}</td>";
                    info += $" <td>{tmpContact.LastName}</td>";
                    info += $" <td>{tmpContact.PersonNr}</td>";
                    info += " <td> </td>";

                    info += " <td>";
                    info += $"<a href='/ViewPersonForm.aspx?ID={ContactManager.GetContactId(tmpContact.PersonNr, CON_STR)}'\">View</a>";
                    info += "&nbsp;|&nbsp;";
                    info += $"<a onClick=\"showModal('{tmpContact.PersonNr}','{tmpContact.FirstName}','{tmpContact.LastName}','Edit contact');\">Edit</a>";
                    info += "&nbsp;|&nbsp;";
                    info += $"<a href='/Main.aspx?DelId={tmpContact.PersonNr}'\">Delete</a>";
                    info += " </td>";
                    info += "</tr>";
                }
                #region Some text 
                info += "</tbody>";
                info += "</table>";
                info += "</div>";
                info += "</div>";
                #endregion
                litContactTable.Text = info;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (tbSSNtmp.Text == "")
            {
                if (tbFName.Text != "" && tbLName.Text != "" && tbSSN.Text != "")
                {
                    ContactManager.AddContact(tbFName.Text, tbLName.Text, tbSSN.Text, CON_STR);
                    Response.Redirect("~/Main.aspx");
                }
                else
                {
                    Response.Write($"<script('#MyErrormessagescript>').style='display=block'</script>");

                }
            }
            else
            {
                string ssn = tbSSNtmp.Text;
                string id = ContactManager.GetContactId(ssn, CON_STR);
                ContactList.Contact tmpContact = ContactManager.GetContactInfoById(id, CON_STR);

                if (id != "" && tmpContact != null)
                {
                    string fname = "";
                    string lname = "";
                    string newSSN = ssn;

                    if (tbFName.Text != "") { fname = tbFName.Text; }
                    else { fname = tmpContact.FirstName; }

                    if (tbLName.Text != "") { lname = tbLName.Text; }
                    else { lname = tmpContact.LastName; }

                    if (tbSSN.Text != "") { newSSN = tbSSN.Text; }
                    else { newSSN = ssn; }
                    int test = 0;

                    Contact tmpCon = new Contact(fname, lname, newSSN);

                    try
                    {
                        DateTime de = new DateTime();
                        if (DateTime.TryParse(tmpCon.PersonNr.Substring(0, 4) + "-" + tmpCon.PersonNr.Substring(4, 2) + "-" + tmpCon.PersonNr.Substring(6, 2), out de))
                            test = 1;
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }

                    if (test == 1)
                    {
                        ContactManager.EditContact(id, fname, lname, newSSN, CON_STR);
                    }
                }
            }
            Response.Redirect("~/Main.aspx");
        }
    }
}