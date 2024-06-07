﻿<%@ Page Title="Club Deportivo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class = "col-xs-4">
            <p>Actividades</p>
            <asp:ListBox ID = "listBoxActividades" Rows ="20" Width = "450px" SelectionMode ="Single" runat="server" AutoPostBack="True">

            </asp:ListBox>
        </div>
    </div>
</asp:Content>
