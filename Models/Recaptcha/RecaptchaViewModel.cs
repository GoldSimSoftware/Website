﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        Goldsim
| Project       Website
\=============================================================================================================================*/

namespace GoldSim.Web.Models.Recaptcha {

  /*============================================================================================================================
  | VIEW MODEL: RECAPTCHA
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides a strongly-typed data transfer object for values associated with the reCAPTCHA view component.
  /// </summary>
  public record RecaptchaViewModel {

    /*==========================================================================================================================
    | SITE KEY
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provides the sitekey used by the reCAPTCHA service.
    /// </summary>
    public string SiteKey { get; init; }

    /*==========================================================================================================================
    | FIELD NAME
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provides the name for the hidden field to store the reCAPTCHA token in.
    /// </summary>
    public string FieldName { get; init; } = "BindingModel.RecaptchaToken";

    /*==========================================================================================================================
    | ACTION
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provides the action to be used for this specific reCAPTCHA call.
    /// </summary>
    public string Action { get; init; }

  } // Class
} // Namespace