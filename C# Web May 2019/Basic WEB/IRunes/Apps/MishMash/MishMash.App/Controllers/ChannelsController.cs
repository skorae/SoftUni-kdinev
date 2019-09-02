using MishMash.App.Models.BindingModels.ChannelBindingModels;
using MishMash.Services.Contracts;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;

namespace MishMash.App.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly IChannelsService channelsService;

        public ChannelsController(IChannelsService channelsService)
        {
            this.channelsService = channelsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ChannelCreateInputBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Channels/Create");
            }

            this.channelsService.CreateChannel(model.Name, model.Description, model.Tags, model.Type);

            return this.Redirect("/");
        }
    }
}
