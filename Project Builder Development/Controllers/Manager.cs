﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;
using Project_Builder_Development.Models;

namespace Project_Builder_Development.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                // Idea Maps

                // Category Maps

                cfg.CreateMap<Category,CategoryBaseViewModel>();
                cfg.CreateMap<CategoryAddViewModel, Category>();

                // Skill Maps
                cfg.CreateMap<Skill,SkillBaseViewModel>();
                cfg.CreateMap<SkillAddViewModel, Skill>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Idea Functions...

        /*public IEnumerable<IdeaBaseViewModel> GetAllIdeas()
        {
            return mapper.Map<IEnumerable<Idea>, IEnumerable<IdeaBaseViewModel>>(ds.Ideas);
        }

        public IdeaBaseViewModel GetOneIdea(int? id)
        {
            var obj = ds.Ideas.SingleOrDefault(i => id == i.IdeaId);
            return obj == null ? null : mapper.Map<Idea, IdeaBaseViewModel>(obj);
        }

        public IdeaBaseViewModel IdeaAdd(IdeaAddViewModel newIdea)
        {
            var addedIdea = ds.Ideas.Add(mapper.Map<IdeaAddViewModel, Idea>(newIdea));
            ds.SaveChanges();

            return addedIdea == null ? null : mapper.Map<Idea, IdeaBaseViewModel>(addedIdea);
        }*/

        // Category Functions

        public IEnumerable<CategoryBaseViewModel> GettAllCategories()
        {
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryBaseViewModel>>(ds.Categories);
        }

        public CategoryBaseViewModel GetOneCategory(int? id)
        {
            var obj = ds.Categories.SingleOrDefault(c => id == c.CategoryId);
            return mapper.Map<Category, CategoryBaseViewModel>(obj);
        }

        public CategoryBaseViewModel AddCategory(CategoryAddViewModel newCategory) {
            var addedCategory = ds.Categories.Add(mapper.Map<CategoryAddViewModel,Category>(newCategory));
            ds.SaveChanges();

            return addedCategory == null ? null : mapper.Map<Category,CategoryBaseViewModel>(addedCategory);
        }

        // Skill Functions

        public IEnumerable<SkillBaseViewModel> GetAllSkills()
        {
            return mapper.Map<IEnumerable<Skill>, IEnumerable<SkillBaseViewModel>>(ds.Skills);
        }

        public SkillBaseViewModel GetOneSkill(int? id)
        {
            var obj = ds.Skills.SingleOrDefault(s => id == s.SkillId);
            return mapper.Map<Skill, SkillBaseViewModel>(obj);
        }

        public SkillBaseViewModel AddSkill(SkillAddViewModel newSkill) {
            var addedSkill = ds.Skills.Add(mapper.Map<SkillAddViewModel,Skill>(newSkill));
            ds.SaveChanges();

            return addedSkill == null ? null : mapper.Map<Skill, SkillBaseViewModel>(addedSkill);
        }
    }
}