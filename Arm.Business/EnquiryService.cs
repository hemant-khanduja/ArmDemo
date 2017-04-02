// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnquiryService.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The enquiry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Arm.Data;
    using Arm.Entities.Models;

    /// <summary>
    /// The enquiry.
    /// </summary>
    public class EnquiryService
    {
        /// <summary>
        /// The crud operations.
        /// </summary>
        private readonly CrudOperations crudOperations;

        /// <summary>
        /// The get entities.
        /// </summary>
        private readonly GetEntities getEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnquiryService"/> class.
        /// </summary>
        public EnquiryService()
        {
            this.crudOperations = new CrudOperations();
            this.getEntities = new GetEntities();
        }

        /// <summary>
        /// The check enquiry.this method can be used for reporting purpose later as an example
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="PriceEnquiryViewModel"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// not implemented as beyond the scope of this demo
        /// </exception>
        public PriceEnquiryViewModel CheckEnquiry(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The products.
        /// </summary>
        /// <returns>
        /// The list of products
        /// </returns>
        public IEnumerable<ProductModel> Products()
        {
            return
                this.getEntities.GetProducts().Select(x => new ProductModel { ProductId = x.ProductId, Name = x.Name });
        }

        /// <summary>
        /// The submit enquiry.
        /// </summary>
        /// <param name="priceEnquiryViewModel">
        /// The price enquiry view model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SubmitEnquiry(PriceEnquiryViewModel priceEnquiryViewModel)
        {
            return this.crudOperations.AddUser(
                       this.Translate(priceEnquiryViewModel),
                       priceEnquiryViewModel.SelectedProducts.ToList()) > 0;
        }

        /// <summary>
        /// The translate.
        /// </summary>
        /// <param name="priceEnquiryViewModel">
        /// The price enquiry view model.
        /// </param>
        /// <returns>
        /// The <see cref="EnquiryUser"/>.
        /// </returns>
        private EnquiryUser Translate(PriceEnquiryViewModel priceEnquiryViewModel)
        {
            var enquiryUser = new EnquiryUser
                                  {
                                      Address_Line_1 = priceEnquiryViewModel.AddressLine1,
                                      City = priceEnquiryViewModel.City,
                                      Country = priceEnquiryViewModel.Country,
                                      Email = priceEnquiryViewModel.Email,
                                      First_Name = priceEnquiryViewModel.FirstName,
                                      Last_Name = priceEnquiryViewModel.LastName,
                                      Phone = priceEnquiryViewModel.Phone,
                                      PostCode = priceEnquiryViewModel.PostCode,
                                  };
            return enquiryUser;
        }
    }
}