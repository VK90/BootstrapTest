<%@ Page Title="" Language="C#" MasterPageFile="~/Site Master.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="BootstrapTest.WebForm1" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<%--        <div class="alert alert-danger fade in" id="Erroreee">
            <a href="#" id="MyErrorMess" class="close" data-dismiss="alert" aria-hidden="true" aria-label="close">&times;</a>
            <strong>Danger!</strong> Inte nog info för att skapa ny person
        </div>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="litContactTable" runat="server"></asp:Literal>
    <script>

        function showModal(SSN, firstName, LastName, actionText) {
            $('input.tbSSN').val(SSN);
            $('input.tbFName').val(firstName);
            $('input.tbLName').val(LastName);
            document.getElementById('modalTitle').innerHTML = actionText;
            //document.getElementById('divText').innerHTML = actionText;
            $('input.tbSSNtmp').val(SSN);
            $('#myModal').modal();
            
        }
    </script>
    
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 id="modalTitle" class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <div id="divText"></div>
                    <p>
                    <asp:Label CssClass="Label1" ID="Label1" runat="server" Text="SSN"></asp:Label>
                    <asp:TextBox CssClass="tbSSN" ID="tbSSN" runat="server"></asp:TextBox><br/>
                    <asp:TextBox CssClass="tbSSNtmp" ID="tbSSNtmp" hidden="true" runat="server"></asp:TextBox><br/>
                    <asp:Label ID="Label" runat="server" Text="Firstname"></asp:Label>
                    <asp:TextBox CssClass="tbFName" ID="tbFName" runat="server"></asp:TextBox><br/>
                    <asp:Label ID="Label3" runat="server" Text="Lastname"></asp:Label>
                    <asp:TextBox CssClass="tbLName" ID="tbLName" runat="server"></asp:TextBox>
                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

