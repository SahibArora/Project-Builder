﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Builder_Development.Models
{
    public class SkillBaseViewModel
    {

        [Required]
        [Display(Name = "Skill Id: ")]
        public int SkillId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Skill Name: ")]
        public string Name { get; set; }

        public bool Patner { get; set; }

        public bool Volunteer { get; set; }

        public IEnumerable<TaskGiven> TasksGiven { get; set; }

        public IEnumerable<Idea> Ideas { get; set; }

    }

    public class SkillAddViewModel : SkillBaseViewModel
    {

    }

    public class CategoryBaseViewModel
    {
        [Required]
        [Display(Name = "Category Id: ")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name: ")]
        public string Name { get; set; }
    }

    public class CategoryAddViewModel : CategoryBaseViewModel
    {

    }
}