<%@ Page Title="" Language="C#" MasterPageFile="~/Site Master.Master" AutoEventWireup="true" CodeBehind="ViewPersonForm.aspx.cs" Inherits="BootstrapTest.WebForm2" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <asp:Label ID="fullName" runat="server" Text=""></asp:Label>
    <p></p>
    <asp:Label ID="ssn" runat="server" Text=""></asp:Label>
    <asp:ListBox ID="lboxAdress" runat="server"></asp:ListBox>
    <asp:ListBox ID="lboxPhone" runat="server"></asp:ListBox>
    <p></p>
    
</asp:Content>
