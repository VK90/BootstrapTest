using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactList;
using System.Configuration;

namespace BootstrapTest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string CON_STR = ConfigurationManager.ConnectionStrings["CON_STR"].ConnectionString;
        List<ContactList.Adress> adressList = new List<Adress>();
        List<ContactList.Phone> phoneList = new List<Phone>();
       
         protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                string id = Request.QueryString["ID"].ToString();
                ContactList.Contact tmp = (ContactManager.GetContactInfoById(id, CON_STR));
                fullName.Text = tmp.FirstName + " " + tmp.LastName; 
                adressList = ContactManager.GetAdressesOfContact(id, CON_STR);
                phoneList = ContactManager.GetPhoneOfContact(id, CON_STR);
                loadInfo();
            }
            else
            {
                for (int i = 0; i<100;i++)
                {
                    fullName.Text += "ERROR!1!11!!";
                }
            }

        }

        protected void loadInfo()
        {
            if (adressList.Count > 0)
            {
                foreach (Adress ad in adressList)
                {
                    lboxAdress.Items.Add(new ListItem(ad.AdressName + " " + ad.City));
                }
            }
            if (phoneList.Count > 0)
            {
                foreach (Phone ph in phoneList)
                {
                    lboxPhone.Items.Add(new ListItem(ph.PhoneNumber));
                }
            }
        }
    }
}