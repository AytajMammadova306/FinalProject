using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Domain.Entities;
using Cinemastic.Persistance.Context;
using Cinemastic.Persistance.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Repositories
{
    internal class ContentRepository:Repository<Content>,IContentRepository
    {
        public ContentRepository(AppDbContext context) : base(context) { }
    }
}
