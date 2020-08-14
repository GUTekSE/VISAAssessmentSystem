﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISAAssessmentSystem.Core.Models
{
    public class Course : BaseEntity
    {
        [DisplayName("Course Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [DisplayName("Course Name")]
        public string Name { get; set; }

    }
}
