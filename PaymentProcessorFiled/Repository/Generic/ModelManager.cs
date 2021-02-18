using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentProcessorFiled.Data;
using PaymentProcessorFiled.Domains.Abstract;
using PaymentProcessorFiled.Exceptions;

namespace PaymentProcessorFiled.Repository.Generics
{
    public class ModelManager<TModel> : IModelManager<TModel>
        where TModel : class, IModel, new()
    {
        private readonly ApplicationDbContext _ctx;

        public ModelManager()
        {}
        public ModelManager(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public virtual async ValueTask<TModel> AddAsync(TModel model)
        {
            model.DateAdded = DateTime.Now;
            await _ctx.Set<TModel>().AddAsync(model);
            return model;
        }


        public virtual TModel Update(TModel model)
        {
            model.DateModified = DateTime.Now;
            _ctx.Entry<TModel>(model).State = EntityState.Modified;
            return model;
        }

        



    }
}
