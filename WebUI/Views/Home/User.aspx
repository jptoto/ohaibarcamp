<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebUI.Models.Attendee>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>User</title>
</head>
<body>
    
        <img src="<%: Model.AvatarURL %>" align="left" style="padding:0px 10px 0px 0px;" />
    
    
        <a href="<%: Model.TwitterURL %>" target="_blank"><%:Model.TwitterURL %></a>

        <br />

        <% foreach (var tag in Model.Tags)
           { %>
                <% if (tag != null){ %>
                <span style="background-color:Gray; padding:2px 0px 2px 0px; color:White; line-height:2; font-size:larger; font-weight:bold;">
                       &nbsp;<%:tag.ToString()%>
                </span>&nbsp;
                      <% } %>
                
        <%} %>
    
</body>
</html>
