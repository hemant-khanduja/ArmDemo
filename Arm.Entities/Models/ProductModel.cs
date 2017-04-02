// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductModel.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The product model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Entities.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The product model.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether is checked.
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductId { get; set; }
    }
}