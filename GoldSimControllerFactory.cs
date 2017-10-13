﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        GoldSim
| Project       Website
\=============================================================================================================================*/
using GoldSim.Web.Controllers;
using Ignia.Topics;
using Ignia.Topics.Web;
using Ignia.Topics.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoldSim.Web {

  /*============================================================================================================================
  | CLASS: HOME CONTROLLER
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides access to the default homepage for the site.
  /// </summary>
  class GoldSimControllerFactory : DefaultControllerFactory {

    /*==========================================================================================================================
    | GET CONTROLLER INSTANCE
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Overrides the factory method for creating new instances of controllers.
    /// </summary>
    /// <returns>A concrete instance of an <see cref="IController"/>.</returns>
    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {

      /*------------------------------------------------------------------------------------------------------------------------
      | Register
      \-----------------------------------------------------------------------------------------------------------------------*/
      #pragma warning disable CS0618
      var topicRepository       = TopicRepository.DataProvider;
      var rootTopic             = TopicRepository.RootTopic;
      var topicRoutingService   = new TopicRoutingService(topicRepository, requestContext);
      #pragma warning restore CS0618

      /*------------------------------------------------------------------------------------------------------------------------
      | Register routes
      \-----------------------------------------------------------------------------------------------------------------------*/
      //Add the content type to the route dictionary to enable finding views based on routing data
      if (requestContext.RouteData.Values.ContainsKey("contenttype")) {
        requestContext.RouteData.Values.Remove("contenttype");
      }
      requestContext.RouteData.Values.Add("contenttype", topicRoutingService.ContentType);

      /*------------------------------------------------------------------------------------------------------------------------
      | Resolve
      \-----------------------------------------------------------------------------------------------------------------------*/
      if (controllerType == typeof(RedirectController)) {
        return new RedirectController(topicRepository);
      }

      if (controllerType == typeof(LayoutController)) {
        return new LayoutController(topicRepository, topicRoutingService);
      }

      if (controllerType == typeof(SitemapController)) {
        return new SitemapController(topicRepository, null);
      }

      if (topicRoutingService.Topic != null) {
        return new TopicController<Topic>(topicRepository, topicRoutingService);
      }

      return base.GetControllerInstance(requestContext, controllerType);

      /*------------------------------------------------------------------------------------------------------------------------
      | Release
      \-----------------------------------------------------------------------------------------------------------------------*/
      //There are no resources to release

    }

  } //Class
} //Namespace
