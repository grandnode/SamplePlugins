using Grand.Core;
using Grand.Core.Plugins;
using Grand.Domain.Data;
using Grand.Domain.Tasks;
using Grand.Framework.Menu;
using Grand.Services.Cms;
using Grand.Services.Common;
using Grand.Services.Security;
using Grand.Services.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class ExamplePlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly IScheduleTaskService _scheduleTaskService;
        private readonly IPermissionService _permissionService;
        private readonly IServiceProvider _serviceProvider;

        public ExamplePlugin(IWebHelper webHelper, IScheduleTaskService scheduleTaskService, IPermissionService permissionService, IServiceProvider serviceProvider)
        {
            _webHelper = webHelper;
            _scheduleTaskService = scheduleTaskService;
            _permissionService = permissionService;
            _serviceProvider = serviceProvider;
        }

        #region Methods

        public override async Task Install()
        {
            IRepository<ScheduleTask> _scheduleTaskRepository = _serviceProvider.GetRequiredService<IRepository<ScheduleTask>>();

            string taskLogSomething = "Grand.Plugin.Misc.ExamplePlugin.Tasks.ExampleTask, Grand.Plugin.Misc.ExamplePlugin";
            var task =  await FindScheduledTask(taskLogSomething);
            if (task == null)
            {
                task = new ScheduleTask {
                    ScheduleTaskName = "Example Task",
                    Type = taskLogSomething,
                    Enabled = false,
                    StopOnError = false,
                    TimeInterval = 1,
                };
                _scheduleTaskRepository.Insert(task);
            }

            await base.Install();
        }
        public override async Task Uninstall()
        {
            string taskLogSomething = "Grand.Plugin.Misc.ExamplePlugin.Tasks.ExampleTask, Grand.Plugin.Misc.ExamplePlugin";
            var task = await FindScheduledTask(taskLogSomething);
            if (task != null)
                await _scheduleTaskService.DeleteTask(task);
            await base.Uninstall();
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ExamplePlugin/Configure";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { "category_details_tabs" };
        }

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "";
            if (widgetZone == "category_details_tabs")
            {
                viewComponentName = "examplePluginCategoryTab";
            }
        }

        public async Task ManageSiteMap(SiteMapNode rootNode)
        {
            if (await _permissionService.Authorize(StandardPermissionProvider.ManagePlugins))
            {
                var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Grandnode Team");
                if (pluginNode == null)
                {
                    rootNode.ChildNodes.Add(new SiteMapNode() {
                        SystemName = "Grandnode Team",
                        Title = "Grandnode Team",
                        Visible = true,
                        IconClass = "icon-puzzle",
                    });
                    pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Grandnode Team");
                }

                var Menu = new SiteMapNode();
                Menu.Title = "Example Plugin";
                Menu.Visible = true;
                Menu.SystemName = "ExamplePlugin";

                Menu.ChildNodes.Add(new SiteMapNode() {
                    Title = "Settings",
                    Visible = true,
                    SystemName = "ExamplePlugin.Settings",
                    ControllerName = "ExamplePlugin",
                    ActionName = "Configure",
                    RouteValues = new RouteValueDictionary() { { "area", "Admin" } },
                });
                Menu.ChildNodes.Add(new SiteMapNode() {
                    Title = "Support",
                    Visible = true,
                    SystemName = "ExamplePlugin.Support",
                    Url = "https://docs.grandnode.com/",
                    RouteValues = new RouteValueDictionary() { { "area", "Admin" } },
                });

                if (pluginNode != null)
                    pluginNode.ChildNodes.Add(Menu);
                else
                    rootNode.ChildNodes.Add(Menu);
            }
        }
        private Task<ScheduleTask> FindScheduledTask(string name)
        {
            return _scheduleTaskService.GetTaskByType(name);
        }

        #endregion
    }
}
