<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUI.Models.HomeViewModel>" %>

	<% foreach (var attendee in Model.Attendees)
    { %>
         <a rel="facebox" href="<%: Url.Action("User", "Home", new { id = attendee.Id }) %>"><img src="<%: attendee.AvatarURL %>" /></a>

    <% } %>

