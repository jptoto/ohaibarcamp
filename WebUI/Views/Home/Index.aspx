<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUI.Models.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserListing">
		<% Html.RenderPartial("UserList", Model); %>
	</div>
   


    <div id="facebox" style="display:none;">
      <div class="popup"> 
        <table> 
          <tbody> 
            <tr> 
              <td class="tl"/><td class="b"/><td class="tr"/> 
            </tr> 
            <tr> 
              <td class="b"/> 
              <td class="body"> 
                <div id="UserDetails"></div>
                <div class="footer"></div>
              </td> 
              <td class="b"/> 
            </tr> 
            <tr> 
              <td class="bl"/><td class="b"/><td class="br"/> 
            </tr> 
          </tbody> 
        </table> 
      </div> 
    </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SideContent" runat="server">

	<div style="padding:5px 5px 5px 10px;">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/"><img src="/Content/images/cloud.png" /></a><br />
	<% foreach (var tag in Model.Hashtags) {
        string fontclass = "smalltag";
        
        if (tag.Value > 0 & tag.Value < 5) {fontclass = "smalltag";}

        if (tag.Value >= 6 & tag.Value <= 10) {fontclass = "mediumtag";}

        if (tag.Value > 10) {fontclass = "largetag";}
        
        if (tag.Key != null & tag.Key != ""){ %> 
                    <span class="<%:fontclass%>"><%: Ajax.ActionLink(tag.Key, "SelectUsers", new { hashTag = tag.Key }, new AjaxOptions { UpdateTargetId = "UserListing" })%>&nbsp;</span> 
            <%}
    } %> 
	</div>
    <br />

</asp:Content>
