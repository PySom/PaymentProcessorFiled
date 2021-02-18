using Microsoft.EntityFrameworkCore;
using PaymentProcessorFiled.Domains.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentProcessorFiled.Repository.Generics
{
    public interface IModelManager<TModel>
        where TModel : class, IModel, new()
    {
        ValueTask<TModel> AddAsync(TModel model);
        TModel Update(TModel model);
    }
}
