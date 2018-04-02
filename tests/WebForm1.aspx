<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="tests.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script type="text/javascript">
        function fun() {

            var str = '<%= DateTime.Now %>';
            //前台位置1，绑定的是第三种变量类型（也是第二种方式，?因为Now是个属性）
            alert(str);
        }
    </script>
</head>
<body onload="fun()">
    <form id="form1" runat="server">   
        <div>
             <input type="text" value="<%= GetVariableStr %>" />
                                                  <%--前台位置2，绑定的是成员变量--%>
             "<%= GetFunctionStr() %>"
                                                  <%--前台位置3，绑定的是一个方法的返回值>--%>
        </div>
    </form>
</body>
</html>
