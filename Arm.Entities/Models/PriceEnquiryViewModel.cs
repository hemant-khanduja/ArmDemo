// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceEnquiryViewModel.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The price enquiry view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Entities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The price enquiry view model.
    /// </summary>
    public class PriceEnquiryViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceEnquiryViewModel"/> class.
        /// </summary>
        public PriceEnquiryViewModel()
        {
            this.Products = new List<ProductModel>();
        }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        [Required]
        [Display(Name = "PostCode")]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        [Required]
        [Display(Name = "Products")]
        public List<ProductModel> Products { get; set; }

        /// <summary>
        /// Gets or sets the selected products.
        /// </summary>
        public IEnumerable<string> SelectedProducts { get; set; }
    }
}