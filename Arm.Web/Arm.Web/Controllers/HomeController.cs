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

    using Arm.Business;
    using Arm.Entities.Models;
   
    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The enquiry service.
        /// </summary>
        private readonly EnquiryService enquiryService;

        /// <summary>
        /// The utilities.
        /// </summary>
        private readonly Utilities utilities;

        // todo: these dependencies(for other projects as well) can be injected using DI container for ex,unity

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            this.enquiryService = new EnquiryService();
            this.utilities = new Utilities();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var priceEnquiryViewModel = new PriceEnquiryViewModel();

            priceEnquiryViewModel.Products = this.enquiryService.Products().ToList();
            this.ViewBag.ShowSuccessMessage = false;
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
                    // todo:call send message 
                    if (this.enquiryService.SubmitEnquiry(priceEnquiryViewModel) && this.utilities.SendEmail(priceEnquiryViewModel))
                    {
                        this.ViewBag.ShowSuccessMessage = true;
                    }
                    else
                    {
                        this.ModelState.AddModelError("failed", "There was some issue.Please try again");
                        this.ViewBag.ShowSuccessMessage = false;
                        priceEnquiryViewModel.Products = this.enquiryService.Products().ToList();
                    }

                    return this.View(priceEnquiryViewModel);
                }
                else
                {
                    this.ModelState.AddModelError("productSelection", "Please select at least one product");
                    this.ViewBag.ShowSuccessMessage = false;
                    priceEnquiryViewModel.Products = this.enquiryService.Products().ToList();
                    return this.View(priceEnquiryViewModel);
                }
            }
            else
            {
                this.ViewBag.ShowSuccessMessage = false;
                priceEnquiryViewModel.Products = this.enquiryService.Products().ToList();
                return this.View(priceEnquiryViewModel);
            }
        }
    }
}