// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utilities.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The utilities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Business
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;

    using Arm.Entities.Models;

    /// <summary>
    /// The utilities.
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// The message body.
        /// </summary>
        private readonly string messageBody;

        // todo:just as an example sitecore context/service/api can be used to extract message body
        // this service can be intialised by IOC and then used to extract message body,currently its hardcoded
        // private SitecoreContext sitecoreContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Utilities"/> class.
        /// </summary>
        public Utilities()
        {
            // this.sitecoreContext = "some contrxt";
            // todo as mentioned above this should be extracted from sitecore/CMS or html templates folder
            // todo:not all fields are used here,beyond scope of this demo project
            this.messageBody =
                @"Hello,<br/> Please note that followimg enquiry has been made<br/><table><tr><td>First Name</td><td>[FirstName]</td></tr><tr><td>Last Name</td><td>[LastName]</td></tr><tr><td>Email</td><td>[Email]</td><tr/><tr><td>Address Line</td><td>[AddressLine1]</td></tr><tr><td>PostCode</td><td>[PostCode]</td><tr/><tr><td>Phone</td><td>[Phone]</td><tr></tr><td>Products Comma seperated List</td><td>[ProductList]</td></tr></table>";
        }

        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="priceEnquiryViewModel">
        /// The price enquiry view model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SendEmail(PriceEnquiryViewModel priceEnquiryViewModel)
        {
            try
            {
                using (var smtp = new SmtpClient())
                {
                    // todo:this should be product names for clarity,just using product id as this is assumed to be beyond scope of this project
                    // product name can be either form posted along with ids OR we can use database call to get names from id
                    var products = string.Join(",", priceEnquiryViewModel.SelectedProducts);

                    var body = this.PrepareBody(priceEnquiryViewModel, products);
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(ConfigurationManager.AppSettings["ToAddress"]));
                    message.From = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
                    message.Subject = "Sales Enquiry";
                    message.Body = body;
                    message.IsBodyHtml = true;
                    var credential = new NetworkCredential
                                         {
                                             UserName = ConfigurationManager.AppSettings["UserName"],
                                             Password = ConfigurationManager.AppSettings["Password"]
                                         };
                    smtp.Credentials = credential;
                    smtp.Host = ConfigurationManager.AppSettings["HostName"];
                    smtp.Port = 587;

                    // todo:not using async send as its beyond scope of this demo
                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception e)
                    {
                        // todo:Please note this is just done for this project as smtp server is not setup for this demo
                        if (ConfigurationManager.AppSettings["ProjectMode"] == "demo")
                        {
                            return true;
                        }
                        else
                        {
                            // todo:log error
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception exception)
            {
                // todo: log exception
                return false;
            }
        }

        /// <summary>
        /// The prepare body.
        /// </summary>
        /// <param name="priceEnquiryViewModel">
        /// The price enquiry view model.
        /// </param>
        /// <param name="products">
        /// The products.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string PrepareBody(PriceEnquiryViewModel priceEnquiryViewModel, string products)
        {
            var body =
                this.messageBody.Replace("[FirstName]", priceEnquiryViewModel.FirstName)
                    .Replace("[LastName]", priceEnquiryViewModel.LastName)
                    .Replace("[Email]", priceEnquiryViewModel.Email)
                    .Replace("[AddressLine1]", priceEnquiryViewModel.AddressLine1)
                    .Replace("[PostCode]", priceEnquiryViewModel.PostCode)
                    .Replace("[Phone]", priceEnquiryViewModel.Phone)
                    .Replace("[ProductList]", products);
            return body;
        }
    }
}