﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        GoldSim
| Project       Website
\=============================================================================================================================*/
using Braintree;

namespace GoldSim.Web.Payments.Services {

  /*============================================================================================================================
  | INTERFACE: BRAINTREE CONFIGURATION
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides an interface for methods used to configure the Braintree payment gateway.
  /// </summary>
  public interface IBraintreeConfiguration {

    IBraintreeGateway CreateGateway();
    string GetConfigurationSetting(string setting, string defaultValue = null);
    IBraintreeGateway GetGateway();

  } // Class
} // Namespace