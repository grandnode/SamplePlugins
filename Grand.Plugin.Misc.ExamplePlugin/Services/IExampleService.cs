using Grand.Plugin.Misc.ExamplePlugin.Domains;
using System;
using System.Collections.Generic;
using System.Text;
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
