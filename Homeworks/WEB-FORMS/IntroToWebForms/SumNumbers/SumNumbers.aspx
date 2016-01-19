<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="SumNumbers.SumNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sum Numbers</title>
</head>
<body>
    <form id="form" runat="server">
        <input id="sumA" type="number" runat="server" />
        <input id="sumB" type="number" runat="server" />
        <input id="submitBtn" value="SUM" type="submit" runat="server" OnServerClick="OnSubmitButtonClick" />
        <div><asp:Label runat="server" ID="sumResult"></asp:Label></div>
    </form>
</body>
</html>
