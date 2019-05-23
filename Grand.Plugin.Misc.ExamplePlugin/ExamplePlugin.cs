using Grand.Core;
using Grand.Core.Data;
using Grand.Core.Domain.Tasks;
using Grand.Core.Infrastructure;
using Grand.Core.Plugins;
using Grand.Framework.Menu;
using Grand.Plugin.Misc.ExamplePlugin.Middleware;
using Grand.Services.Common;
using Grand.Services.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class ExamplePlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        private readonly IWebHelper _webHelper;
        private readonly IScheduleTaskService _scheduleTaskService;

       

        public ExamplePlugin(IWebHelper webHelper, IScheduleTaskService scheduleTaskService)
        {
            _webHelper = webHelper;
            _scheduleTaskService = scheduleTaskService;
        }
        #region Methods

        public override async Task Install()
        {
            IRepository<ScheduleTask> _scheduleTaskRepository = EngineContext.Current.Resolve<IRepository<ScheduleTask>>();

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
        public void ManageSiteMap(SiteMapNode rootNode)
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
                Url = "http://docs.nop4you.com/",
                RouteValues = new RouteValueDictionary() { { "area", "Admin" } },
            });

            if (pluginNode != null)
                pluginNode.ChildNodes.Add(Menu);
            else
                rootNode.ChildNodes.Add(Menu);
        }
        private Task<ScheduleTask> FindScheduledTask(string name)
        {
            return _scheduleTaskService.GetTaskByType(name);
        }

        #endregion
    }
}
