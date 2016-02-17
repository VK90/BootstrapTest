<%@ Page Title="" Language="C#" MasterPageFile="~/Site Master.Master" AutoEventWireup="true" CodeBehind="ViewPersonForm.aspx.cs" Inherits="BootstrapTest.WebForm2" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="fullName" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="ssn" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Adress"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text="Phone"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="lboxAdress" runat="server"></asp:ListBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:ListBox ID="lboxPhone" runat="server"></asp:ListBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <p></p>

</asp:Content>
