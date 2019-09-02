using SIS.MvcFramework.Attributes.Validation;

namespace Musaca.App.BindingModels.Products
{
    public class ProductOrderBindingModel
    {
        private const string InvalidProductName = "Invalid product.";

        [RequiredSis(InvalidProductName)]
        public string Product { get; set; }
    }
}
