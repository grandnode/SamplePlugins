using Grand.Core.Data;
using Grand.Core.Domain.Catalog;
using Grand.Plugin.Misc.ExamplePlugin.Domains;
using Grand.Services.Catalog;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IRepository<ExampleTable> _repository;

        public ExampleService(IRepository<ExampleTable> repository)
        {
            _repository = repository;
        }

        public virtual async Task Delete(ExampleTable record)
        {
           if(record == null)
                throw new NullReferenceException("Null record object");

           await _repository.DeleteAsync(record);
        }

        public virtual async Task<IList<ExampleTable>> GetAll()
        {
            return await _repository.Table.ToListAsync();
        }

        public virtual async Task<ExampleTable> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new NullReferenceException("Id is null");

            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<ExampleTable> Insert(ExampleTable record)
        {
            if (record == null)
                throw new NullReferenceException("Null record object");

            return await _repository.InsertAsync(record);
        }

        public virtual async Task<ExampleTable> Update(ExampleTable record)
        {
            if (record == null)
                throw new NullReferenceException("Null record object");

            return await _repository.UpdateAsync(record);
        }
    }
}
