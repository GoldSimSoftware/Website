﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        Goldsim
| Project       Website
\=============================================================================================================================*/
using System;
using GoldSim.Web.Administration.Models.Invoices;
using GoldSim.Web.Administration.Models.Licenses;
using GoldSim.Web.Courses.Models;
using GoldSim.Web.Forms.Models;
using GoldSim.Web.Models;
using GoldSim.Web.Models.ContentTypes;
using GoldSim.Web.Payments.Models;
using OnTopic.Editor.AspNetCore.Infrastructure;

namespace GoldSim.Web {

  /*============================================================================================================================
  | CLASS: GOLDSIM TOPIC VIEW MODEL LOOKUP SERVICE
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides a mapping between string and class names to be used when mapping <see cref="Topic"/> to a <see
  ///   cref="TopicViewModel"/> or derived class.
  /// </summary>
  public class GoldSimTopicViewModelLookupService : EditorViewModelLookupService {

    /*==========================================================================================================================
    | CONSTRUCTOR
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Instantiates a new instance of the <see cref="GoldSimViewModelLookupService"/>.
    /// </summary>
    /// <returns>A new instance of the <see cref="GoldSimViewModelLookupService"/>.</returns>
    internal GoldSimTopicViewModelLookupService() : base() {

      /*------------------------------------------------------------------------------------------------------------------------
      | Add content type view models
      \-----------------------------------------------------------------------------------------------------------------------*/
      Add(typeof(ApplicationBasePageTopicViewModel));
      Add(typeof(ApplicationContainerTopicViewModel));
      Add(typeof(ApplicationIndexTopicViewModel));
      Add(typeof(ApplicationPageTopicViewModel));
      Add(typeof(DocumentPointerTopicViewModel));
      Add(typeof(EmailTopicViewModel));
      Add(typeof(ExampleApplicationTopicViewModel));
      Add(typeof(ExampleIndexTopicViewModel));
      Add(typeof(FaqItemTopicViewModel));
      Add(typeof(FaqTopicViewModel));
      Add(typeof(FollowupTopicViewModel));
      Add(typeof(GlossaryItemTopicViewModel));
      Add(typeof(GlossaryTopicViewModel));
      Add(typeof(HomeTopicViewModel));
      Add(typeof(ModulePageTopicViewModel));
      Add(typeof(PaymentsTopicViewModel));
      Add(typeof(SearchTopicViewModel));
      Add(typeof(TechnicalPaperListTopicViewModel));
      Add(typeof(TechnicalPaperTopicViewModel));

      /*------------------------------------------------------------------------------------------------------------------------
      | Add courseware specific view models
      \-----------------------------------------------------------------------------------------------------------------------*/
      Add(typeof(CourseListTopicViewModel));
      Add(typeof(CourseTopicViewModel));
      Add(typeof(UnitTopicViewModel));
      Add(typeof(LessonTopicViewModel));

      /*------------------------------------------------------------------------------------------------------------------------
      | Form models
      \-----------------------------------------------------------------------------------------------------------------------*/
      Add(typeof(FormPageTopicViewModel));
      Add(typeof(TrialFormTopicViewModel));
      Add(typeof(InstructorAcademicFormTopicViewModel));
      Add(typeof(StudentAcademicFormTopicViewModel));
      Add(typeof(PaymentFormBindingModel));

      /*------------------------------------------------------------------------------------------------------------------------
      | License administration
      \-----------------------------------------------------------------------------------------------------------------------*/
      Add(typeof(InvoiceTopicViewModel));
      Add(typeof(LicenseAdministrationTopicViewModel));
      Add(typeof(LicenseRequestTopicViewModel));

      /*------------------------------------------------------------------------------------------------------------------------
      | Override Ignia viw models
      \-----------------------------------------------------------------------------------------------------------------------*/
      Replace(typeof(ContentListTopicViewModel));
      Replace(typeof(NavigationTopicViewModel));
      Replace(typeof(PageGroupTopicViewModel));

      /*------------------------------------------------------------------------------------------------------------------------
      | Function: Replace
      \-----------------------------------------------------------------------------------------------------------------------*/
      void Replace(Type type) {
        if (Contains(type.Name)) {
          Remove(type.Name);
        }
        Add(type);
      }

    }

  } //Class
} //Namespace