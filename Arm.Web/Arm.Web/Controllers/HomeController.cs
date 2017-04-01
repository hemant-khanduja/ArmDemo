// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="arm">
//   arm
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Arm.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Arm.Web.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var priceEnquiryViewModel = new PriceEnquiryViewModel();

            // todo:remove these hardcoded products list to take from DB
            priceEnquiryViewModel.Products.Add(new ProductModel { Name = "Product1", ProductId = 1 });
            priceEnquiryViewModel.Products.Add(new ProductModel { Name = "Product2", ProductId = 2 });
            this.ViewBag.ShowMessage = false;
            return this.View(priceEnquiryViewModel);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="priceEnquiryViewModel">
        /// The price enquiry view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Index(PriceEnquiryViewModel priceEnquiryViewModel)
        {
            if (this.ModelState.IsValid)
            {
                if (priceEnquiryViewModel.SelectedProducts != null && priceEnquiryViewModel.SelectedProducts.Any())
                {
                    // todo:call save to db and send message 
                    this.ViewBag.ShowMessage = true;
                }
                else
                {
                    this.ModelState.AddModelError("productSelection", "Please select at least one product");
                }
            }

            this.ViewBag.ShowMessage = false;

            // todo:remove these hardcoded products list to take from DB
            priceEnquiryViewModel.Products.Add(new ProductModel { Name = "Product1", ProductId = 1 });
            priceEnquiryViewModel.Products.Add(new ProductModel { Name = "Product2", ProductId = 2 });
            return this.View(priceEnquiryViewModel);
        }
    }
}