<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUI.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="UserListing">
        <% Html.RenderPartial("UserList", Model); %>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SideContent" runat="server">
    <div style="background-color:Gray; color:Black; padding:5px 5px 5px 5px;">
    <% foreach (var tag in Model.Hashtags)
        { %>
        <% string fontclass = "smalltag";
                   
            if (tag.Value > 0 & tag.Value < 2)
                fontclass = "smalltag";                           
               
            if (tag.Value >= 2 & tag.Value <= 10)
                fontclass = "mediumtag";
               
            if (tag.Value > 10)
                fontclass = "largetag";      
        %>
        <span class="<%:fontclass%>"><%: Ajax.ActionLink(tag.Key, "SelectUsers", new { hashTag = tag.Key }, new AjaxOptions { UpdateTargetId = "UserListing" })%>&nbsp;</span>
    <%} %>
    </div>
</asp:Content>
