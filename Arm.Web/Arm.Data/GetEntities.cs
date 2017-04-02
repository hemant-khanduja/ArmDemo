// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEntities.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The get entities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Data
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The get entities.
    /// </summary>
    public class GetEntities
    {
        /// <summary>
        /// The get products.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Product> GetProducts()
        {
            using (var armCustomEntities = new ArmCustomEntities())
            {
                return armCustomEntities.Products.ToList();
            }
        }
    }
}