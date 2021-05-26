﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        GoldSim
| Project       Website
\=============================================================================================================================*/
using System.Threading.Tasks;

namespace GoldSim.Web.Services {

  /*============================================================================================================================
  | INTERFACE: REQUEST VALIDATOR
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Validates that a request is from a human, as determined by e.g. a CAPTCHA service.
  /// </summary>
  public interface IRequestValidator {

    /*==========================================================================================================================
    | IS VALID?
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Determines whether the current request is considered valid.
    /// </summary>
    Task<bool> IsValid(string requestType, string requestToken);

  } // Interface
} // Namespace