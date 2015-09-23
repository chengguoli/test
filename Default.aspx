<%@ Page Language="C#" CodeFile="DBHelper.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>Test</title>
    </head>
    <body>
        <form id="form1" runat="server">
        <div>
            <%
                DBHelper.validateUser("200233","hello");
    
            %>
        </div>
        </form>
    </body>
</html>
