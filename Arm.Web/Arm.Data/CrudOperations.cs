// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrudOperations.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The crud operations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// The crud operations.
    /// </summary>
    public class CrudOperations
    {
        /// <summary>
        /// The add user.
        /// </summary>
        /// <param name="enquiryUser">
        /// The enquiry user.
        /// </param>
        /// <param name="products">
        /// The products.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int AddUser(EnquiryUser enquiryUser,List<string> products )
        {
            using (var armDbContext = new ArmCustomEntities())
            {
                try
                {
                   foreach (var product in products)
                   {
                       int productId = int.Parse(product);
                        var databaseProduct = armDbContext.Products.FirstOrDefault(x => x.ProductId == productId);

                        if (databaseProduct != null)
                        {
                            enquiryUser.Products.Add(databaseProduct);
                        }
                    }

                    armDbContext.EnquiryUsers.Add(enquiryUser);
                    var success = armDbContext.SaveChanges();
                    return success;
                }
                catch (SqlException sqlExceptione)
                {
                    // log error
                    return -1;
                }
                catch (Exception exception)
                {
                    // log error
                    return -1;
                }
            }
        }
    }
}