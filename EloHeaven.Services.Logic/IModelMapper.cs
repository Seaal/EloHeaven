using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloHeaven.Services.Logic
{
    public interface IModelMapper<TEntity, TModel>
    {
        TEntity ToEntity(TModel model);
        TModel ToModel(TEntity entity);
    }
}
