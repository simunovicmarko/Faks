<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DSR_1_Naloga._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <%--<link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1//resources/demos/style.css">--%>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script
        src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>

    <script src="JavaScript.js" type="text/javascript"></script>


    <style>
        #custom-handle {
            width: 3em;
            height: 1.6em;
            top: 50%;
            margin-top: -.8em;
            text-align: center;
            line-height: 1.6em;
        }

        #custom-handle2 {
            width: 3em;
            height: 1.6em;
            top: 50%;
            margin-top: -.8em;
            text-align: center;
            line-height: 1.6em;
        }

        .Slajder {
            margin: 15px;
        }
    </style>

    <script>
        $(function () {
            var handle = $("#custom-handle");
            let temp = $("#MainContent_st1")[0].value;
            if (Number.isNaN(parseInt(temp))) 
                temp = undefined;
            

            $("#slider").slider({
                create: function () {
                    handle.text(temp ? temp : 0);
                },
                slide: function (event, ui) {
                    handle.text(ui.value);
                    //Hranjene trenutnih podatkov v TB
                    document.getElementById("MainContent_s1").value = ui.value;
                }
            });
            
        });
    </script>

    <script>
        $(function () {
            var handle = $("#custom-handle2");
            let temp = $("#MainContent_st2")[0].value;

            if (Number.isNaN(parseInt(temp))) 
                temp = undefined;
            

            $("#slider2").slider({
                create: function () {
                    handle.text(temp ? temp : 0);

                },
                slide: function (event, ui) {
                    handle.text(ui.value);
                    //Hranjene trenutnih podatkov v TB
                    document.getElementById("MainContent_s2").value = ui.value;
                }
            });
        });

        $(function () {
            $("input[type=radio]").checkboxradio();

            $('input[type=radio]').change(function () {
                document.getElementById("MainContent_ope").value = $(this).val();
            })
        });


    </script>

    <%--ASP dobijo vrednost iz URI--%> 
    <asp:HiddenField ID="oper" runat="server" Value="+" />
    <asp:HiddenField ID="st1" runat="server" Value="0" />
    <asp:HiddenField ID="st2" runat="server" Value="0" />

    <%--TextBoxi za hranjene trenuutnih podatkov--%>
    <asp:TextBox ID="s1" Style="display: none" runat="server" Text="0" />
    <asp:TextBox ID="s2" Style="display: none" runat="server" Text="0" />
    <asp:TextBox ID="ope" Style="display: none" runat="server" Text="plus" />

    <h1>Kalkulator</h1>

    <div id="slider" class="Slajder">
        <div id="custom-handle" class="ui-slider-handle"></div>
    </div>

    <%--radio--%>
    <div class="widget">
        <fieldset>
            <legend>Operacija: </legend>
            <label for="pristej">Pristej</label>
            <input type="radio" name="radio-1" id="pristej" value="plus" checked>
            <label for="odstej">Odstej</label>
            <input type="radio" name="radio-1" id="odstej" value="minus">
            <label for="mnozi">Pomnoži</label>
            <input type="radio" name="radio-1" id="mnozi" value="krat">
            <label for="deli">Deli</label>
            <input type="radio" name="radio-1" id="deli" value="deljeno">
        </fieldset>
    </div>



    <div id="slider2" class="Slajder">
        <div id="custom-handle2" class="ui-slider-handle"></div>
    </div>

    <asp:Button ID="izracunajBTN" OnClick="GremoDrgam" class="ui-button ui-widget ui-corner-all" runat="server" Text="Izračunaj" />

    <br />
    <label style="margin:10px; margin-top:30px">
        Rezultat:
        <input id="res">
    </label>
</asp:Content>
