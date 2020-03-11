<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgDecs.aspx.cs" Inherits="BDF.ProgramDec.WFUI.ProgDecs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="header rounded-top">
        <h3>Program Declarations</h3>
    </div>
    <p></p>

    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label3" runat="server" Text="Change Date:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlChangeDate" runat="server"
                CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlChangeDate_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label2" runat="server" Text="Student Name:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlStudents" runat="server"
                CssClass="form-control"
                AutoPostBack="true">
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-row m1-2 mt-2">
        <div class="control-label col-md-2">
            <asp:Label ID="Label4" runat="server" Text="Program Name:"></asp:Label>
        </div>
        <div class="control-label col-md-3">
            <asp:DropDownList ID="ddlPrograms" runat="server"
                CssClass="form-control"
                AutoPostBack="true">
            </asp:DropDownList>
        </div>
    </div>



    <div class="form-group ml-5 mt-2">
        <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="btn btn-primary btn-md ml-3" OnClick="btnInsert_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-md ml-3" OnClick="btnUpdate_Click"/>
        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary btn-md ml-3" OnClick="btnDelete_Click" />
    </div>
</asp:Content>
