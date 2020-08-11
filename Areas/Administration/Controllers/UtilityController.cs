﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        GoldSim
| Project       Website
\=============================================================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnTopic;
using OnTopic.Collections;
using OnTopic.Querying;
using OnTopic.Repositories;

namespace GoldSim.Web.Administration.Controllers {

  /*============================================================================================================================
  | CLASS: REPORT CONTROLLER
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Allows GoldSim to report on embedded images and links.
  /// </summary>
  [Authorize]
  [Area("Administration")]
  public class UtilityController: Controller {

    /*==========================================================================================================================
    | PRIVATE VARIABLES
    \-------------------------------------------------------------------------------------------------------------------------*/
    private readonly            ITopicRepository                _topicRepository;
    private readonly            IWebHostEnvironment             _hostingEnvironment;

    /*==========================================================================================================================
    | CONSTRUCTOR
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Initializes a new instance of a <see cref ="UtilityController"/> with necessary dependencies.
    /// </summary>
    /// <returns>A topic controller for loading OnTopic views.</returns>
    public UtilityController(
      ITopicRepository topicRepository,
      IWebHostEnvironment hostingEnvironment
    ) {
      _topicRepository          = topicRepository;
      _hostingEnvironment       = hostingEnvironment;
    }

    /*==========================================================================================================================
    | GET MATCHED TOPICS
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provides a list of topics that match the search critera.
    /// </summary>
    private ReadOnlyTopicCollection<Topic> GetMatchedTopics(string searchText) =>
      _topicRepository.Load().FindAll(t => {
        return t.Attributes.Any(a =>
          a.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase)
        );
      });

    /*==========================================================================================================================
    | ACTION: FIND
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provided a search term, will find all instances of text in the OnTopic database.
    /// </summary>
    [HttpGet]
    public IActionResult Find(string searchText) {

      var targetTopics          = GetMatchedTopics(searchText);
      var results               = new List<Tuple<string, string, string>>();

      foreach (var topic in targetTopics) {
        var url                 = topic.GetWebPath();
        foreach (var attribute in topic.Attributes) {
          if (attribute.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase)) {
            results.Add(new Tuple<string, string, string>(url, attribute.Key, attribute.Value));
          }
        }
      }

      return Json(results);

    }

    /*==========================================================================================================================
    | ACTION: REPLACE
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Provided a search term and a replacement term, will find all instances of text in the OnTopic database and replace
    ///   them.
    /// </summary>
    [HttpGet]
    public IActionResult Replace(string searchText, string replaceText) {

      var targetTopics          = GetMatchedTopics(searchText);
      var results               = new List<Tuple<string, string, string>>();

      foreach (var topic in targetTopics) {
        var url                 = topic.GetWebPath();
        foreach (var attribute in topic.Attributes) {
          if (attribute.Value.Contains(searchText, StringComparison.OrdinalIgnoreCase)) {
            var newValue        = attribute.Value.Replace(searchText, replaceText, StringComparison.OrdinalIgnoreCase);
            topic.Attributes.SetValue(attribute.Key, newValue);
            results.Add(new Tuple<string, string, string>(url, attribute.Key, newValue));
          }
        }
        _topicRepository.Save(topic);
      }

      return Json(results);

    }

    /*==========================================================================================================================
    | ACTION: RESAVE
    \-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    ///   Resaves all topics to ensure any schema changes are reflected in the persistence store.
    /// </summary>
    [HttpGet]
    public IActionResult Resave() {
      _topicRepository.Save(_topicRepository.Load(), true);
      return Json(new object());
    }

  } // Class
} // Namespace