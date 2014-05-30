<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<WebUI.Models.Attendee>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>User</title>
</head>
<body>
        <div class="userName">@<%: Model.Name %></div>    
        <% foreach (var tag in Model.Tags)
           { %>
                <% if (tag != null){ %>
                <span class="tag">&nbsp;<%:tag.ToString()%></span>&nbsp;
                      <% } %>
        <%} %>
</body>
</html>
