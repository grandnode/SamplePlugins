using Grand.Plugin.Widgets.ExampleWidget.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Services
{
    public interface IExampleService
    {
        Task<ExampleTable> GetById(string id);
        Task<IList<ExampleTable>> GetAll();
        Task<ExampleTable> Insert(ExampleTable record);
        Task<ExampleTable> Update(ExampleTable record);
        Task Delete(ExampleTable record);

    }
}
