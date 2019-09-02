using SIS.MvcFramework.Attributes.Validation;

namespace MishMash.App.Models.BindingModels.ChannelBindingModels
{
    public class ChannelCreateInputBindingModel
    {
        [RequiredSis]
        public string Name { get; set; }

        [RequiredSis]
        public string Description { get; set; }

        [RequiredSis]
        public string Tags { get; set; }

        [RequiredSis]
        public string Type { get; set; }
    }
}
