﻿/*==============================================================================================================================
| Author        Ignia, LLC
| Client        Goldsim
| Project       Website
\=============================================================================================================================*/
using System.Collections.ObjectModel;
using OnTopic.Models;
using OnTopic.ViewModels;

namespace GoldSim.Web.Models.ViewModels {

  /*============================================================================================================================
  | VIEW MODEL: TRACKED NAVIGATION TOPIC
  \---------------------------------------------------------------------------------------------------------------------------*/
  /// <summary>
  ///   Provides a strongly-typed data transfer object for feeding views with information about the navigation alongside
  ///   progress tracking information.
  /// </summary>
  /// <remarks>
  ///   No topics are expected to have a <c>Navigation</c> content type. Instead, this view model is expected to be manually
  ///   constructed by the <see cref="LayoutController"/>.
  /// </remarks>
  public class TrackedNavigationTopicViewModel: PageTopicViewModel, INavigationTopicViewModel<TrackedNavigationTopicViewModel> {

    public bool? IsVisited { get; set; } = null;
    public Collection<TrackedNavigationTopicViewModel> Children { get; } = new Collection<TrackedNavigationTopicViewModel>();
    public bool IsSelected(string uniqueKey) => $"{uniqueKey}:"?.StartsWith($"{UniqueKey}:") ?? false;

    public string GetCssClass() =>
      IsVisited switch {
        null => "is-unstarted far fa-circle",
        false => "is-incomplete fas fa-adjust",
        true => "is-complete fas fa-circle"
      };

  } // Class
} // Namespace