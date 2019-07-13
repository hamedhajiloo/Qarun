using Data.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.DataInitializer
{
    public class CategoryDataInitializer : IDataInitializer
    {
        private readonly IRepository<Role> repository;

        public CategoryDataInitializer(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public void InitializeData()
        {
            if (!repository.TableNoTracking.Any(p => p.Name=="Admin"))
            {
                repository.Add(new Role
                {
                    Name = "Admin",
                    Description="Admin"
                });
            }
            if (!repository.TableNoTracking.Any(p => p.Name == "User"))
            {
                repository.Add(new Role
                {
                    Name = "User",
                    Description= "User"
                });
            }

        }
    }
}
