﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        Goldsim
| Project       Website
\=============================================================================================================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldSim.Web.Models.Forms.BindingModels {

  /*============================================================================================================================
  | BINDING MODEL: ACADEMIC FORM (STUDENT)
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides a strongly-typed binding model representing the student version of the academic form.
  /// </summary>
  public class StudentAcademicFormBindingModel : AcademicFormBindingModel {

    /*==========================================================================================================================
    | CONSTRUCTOR
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Initializes a new instance of the <see cref="StudentAcademicFormBindingModel"/> object.
    /// </summary>
    public StudentAcademicFormBindingModel() {
      Sponsor = new CoreContact();
    }

    /*==========================================================================================================================
    | PROPERTY: SPONSOR
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Gets or sets the academic sponsor of the student (usually their instructor or academic advisor).
    /// </summary>
    [Display(Name="Student Sponsor")]
    public CoreContact Sponsor { get; }

  }

}