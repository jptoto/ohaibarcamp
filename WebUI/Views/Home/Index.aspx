<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUI.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<% foreach (var attendee in Model.Attendees)
    { %>
         <a rel="facebox" href="<%: Url.Action("User", "Home", new { id = attendee.Id }) %>"><img src="<%: attendee.AvatarURL %>" /></a>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SideContent" runat="server">
    nuthin yet
</asp:Content>
