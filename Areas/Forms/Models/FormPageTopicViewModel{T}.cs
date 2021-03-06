﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        GoldSim
| Project       Website
\=============================================================================================================================*/
using OnTopic.Models;

namespace GoldSim.Web.Forms.Models {

  /*============================================================================================================================
  | CLASS: FORM PAGE VIEW MODEL {T}
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   A view model for rendering a form page with a strongly-typed binding model.
  /// </summary>
  public record FormPageTopicViewModel<T> : FormPageTopicViewModel where T : class, ITopicBindingModel, new() {

    /*==========================================================================================================================
    | CONSTRUCTOR
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Initializes a new instance of a <see cref="FormPageTopicViewModel"/> with appropriate dependencies.
    /// </summary>
    /// <returns>A <see cref="FormPageTopicViewModel"/>.</returns>
    public FormPageTopicViewModel(T bindingModel = null) {
      BindingModel = bindingModel ?? new T();
    }

    /*==========================================================================================================================
    | BINDING MODEL
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provides a reference to the binding model that should be used for the form itself.
    /// </summary>
    /// <returns>The <typeparamref name="T"/> binding model.</returns>
    public T BindingModel { get; }

  } // Class
} // Namespace