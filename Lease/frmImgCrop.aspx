<%@ Page Title="" Language="C#" MasterPageFile="~/Lease/MainMaster.master" AutoEventWireup="true" CodeFile="frmImgCrop.aspx.cs" Inherits="forms_frmImgCrop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/wheelzoom.js"></script>
    <script>
        $(document).ready(function () {
            wheelzoom(document.querySelector('img.zoom'));
        });
    </script>

    <script>
        $(document).ready(function () {
            //$('.previewMainImage').magnify();

            $('section.content').css('padding-bottom', '0');
            //$('.box-img').each(function (i) {
            //    $(this).attr("id", "box-img-" + (i + 1));
            //});
            $(".thumbnail-img-grid tr td input:checkbox").each(function (index) {
                var labelfor = $(this).attr('id');
                $(this).parent('label').attr('for', labelfor)
            });
            var temp = $('#box-img-0').attr('src');
            $('.previewMainImage').attr('src', temp);
            $('.previewMainImage').attr('data-magnify-src', temp);
            var viewer = ImageViewer();
            $('.gallery-items').click(function () {
                // debugger;
                //var imgSrc = this.src;
                highResolutionImage = '';
                highResolutionImage = $(this).data('magnify-src');
                viewer.show(temp, temp);
            });
            $('.thumbnail-img-grid tr td label').click(function () {

                var source = $(this).find('.box-img').attr('src');
                $('.previewMainImage').attr('src', source);
                $('.previewMainImage').attr('data-magnify-src', source);
                //$('.previewMainImage').magnify();
                //   wheelzoom(document.querySelector('img'));
                var viewer = ImageViewer();
                $('.gallery-items').click(function () {
                    // debugger;
                    //var imgSrc = this.src;
                    highResolutionImage = '';
                    highResolutionImage = $(this).data('magnify-src');
                    viewer.show(source, source);
                });
                //});
                //$('.thumbnail-img-grid tr td').click(function () {

                $('.selected-img-grid-div').html('');
                $('.SelectedImgDiv').css('display', 'none');
                //$('.selected-img-grid tr').html('');
                var array = [];
                var length = $('.gvrows').length;
                for (var i = 0; i < length; i++) {
                    var checkid = '#ContentPlaceHolder1_gvThumbnail_chkImg_' + i;
                    if ($(checkid).is(':checked')) {
                        var imgid = '#box-img-' + i;
                        array.push($(imgid).attr('src'));
                    }
                }
                //$('.thumbnail-img-grid').find('input[type="checkbox"]:checked').each(function () {
                //    debugger;
                //    var url = $(this).next('img').attr('src');
                //    if (url != undefined) {
                //        array.push(url);
                //    }
                //});
                //$(".thumbnail-img-grid tbody tr td label span input:checkbox").each(function (index) {
                //    if ($(this).is(':checked')) {
                //        var url = $(this).next('img').attr('src');
                //        if (url != undefined) {
                //            array.push(url);
                //        }
                //    }
                //});
                console.log(array);
                $.each(array, function (index, value) {
                    $('.SelectedImgDiv').css('display', 'block');
                    $('.selected-img-grid-div').prepend('<div class="imgdiv"><img id="' + index + '" src="' + array[index] + '"/></div>');
                    //$('.selected-img-grid tr').append('<td><img id="' + index + '" src="' + array[index] + '"></td>');//<span class="remove-icon">&times;</span>
                })
            });
            //$('.previewMainImage').magnify();
            wheelzoom(document.querySelector('img'));
        });

        $(document).ready(function () {
            $('.btnSave').click(function () {
                <%-- var secCD = $('#<%=ddlSectionName.ClientID%>').val();
                var SubSecCD = $('#<%=ddlSubSectionName.ClientID%>').val();
                var fileTrackNo = $('#<%=ddlFileTrackNo.ClientID%>').val();
                var docType = $('#<%=ddlDocType.ClientID%>').val();--%>



            });
        });

    </script>
    <%--<script type="text/javascript">
        
            $(document).ready(function () {
                //$('#ContentPlaceHolder1_SelectedImgDiv').css('display', 'none');
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                if (prm != null) {
                    prm.add_endRequest(function (sender, e) {
                        if (sender._postBackSettings.panelsToUpdate != null) {
                            $(".chosen-select").chosen(); $(".chosen-select-deselect").chosen({ allow_single_deselect: true });
                            $('.chosen-search input[type="text"]').addClass('form-control');
                            $('.chosen-select').addClass('form-control');
                        }
                    });
                }
            });
       
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <script type="text/javascript">
                //Sys.Application.add_load(SaveValidate);
            </script>--%>
    <asp:HiddenField ID="schCode" runat="server" />

    <!-- Main content -->
    <div class="container-fluid">
        <div class="pb0" style="padding-top: 20px">
            <div class="row">
                <div id="LoadingQ" runat="server" style="display: none;" class="loadingq load">Loading&#8230;</div>


                <div class="col-xs-12 col-sm-12">
                    <div class="panel panel-primary silver box-solid silver-box-doctype">
                        <div class="panel panel-primary mb0">
                            <div class="panel-heading">
                                <h3 class="panel-title">Image Cropping
                                </h3>
                            </div>
                            <div class="panel-body panel-body-form slider-form">

                                <div class="col-xs-12 col-sm-5">

                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Service No.</label>
                                            <div class="col-xs-12 col-sm-8 mrg">
                                                <asp:TextBox ID="txtServiceNo" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="fte1" runat="server" ValidChars="0123456789" TargetControlID="txtServiceNo" />
                                                <asp:RequiredFieldValidator SetFocusOnError="true" ID="rq" runat="server" ControlToValidate="txtServiceNo" ValidationGroup="s" ErrorMessage="Please Enter Service No." ForeColor="Red" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Scheme Name</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="lblSchName" runat="server" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Plot No.</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="lblPlotNo" runat="server" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Holder Name</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="lblPlotHolderName" runat="server" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-xs-12 text-right">
                                                <div id="IdaCustomAlert" class="IdaCustomAlert" runat="server">
                                                    <span id="IdaCustomAlertMsg" runat="server"></span>
                                                </div>
                                               
                                                <asp:Button ID="btnSearch" ValidationGroup="s" Text="&#xf002; Search" runat="server" CssClass="fa-html btn btn-primary btnSearch" OnClick="btnSearch_Click" />
                                                 <asp:Button ID="btnClearsearch" Text=" Clear" runat="server" OnClick="btnClearsearch_Click" CssClass="fa-html btn btn-danger btnSearch" />
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-12 ">
                                                <div id="SelectedImgDiv" runat="server" class="SelectedImgDiv" style="display: none">
                                                    <div class="selected-img-grid-div scroller"></div>
                                                    <div class="form-group">
                                                        <label class="control-label col-xs-12 col-sm-4">Document Type</label>
                                                        <div class="col-xs-12 col-sm-8 mrg">
                                                            <asp:DropDownList ID="ddlDocType" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="req2" runat="server" ErrorMessage="Please Select Document Type" InitialValue="-Select-" ForeColor="Red" ControlToValidate="ddlDocType" ValidationGroup="a" CssClass="errorMsg"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>

                                                    <div class="col-xs-12 text-right">

                                                        <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="a" CssClass="btn btn-success btnSave" OnClick="btnSave_Click" />
                                                        <asp:Button ID="btnClear" Text="Clear" runat="server" CssClass="btn btn-default btnClear" OnClick="btnClear_Click" />
                                                        <a href="Dashboard.aspx" class="btn btn-danger">Exit</a>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-7">
                                    <div id="MainImgDiv" style="display: none" runat="server" class="row">
                                        <div class="col-sm-2 col-xs-4">
                                            <div class="thumbnail-img-grid-height tablescroller1 scroller">
                                                <%--<table class="thumbnail-img-grid withtable1" >
                                            <tr>
                                                <td>
                                                    <asp:CheckBox Text="" runat="server" />
                                                    <img src="img/user.png"  class="box-img" id="img1"/>
                                                </td>
                                            </tr>
                                        </table>--%>
                                                <asp:GridView ID="gvThumbnail" runat="server" CssClass="thumbnail-img-grid withtable1" Style="border: none;" AutoGenerateColumns="false" ShowHeader="false">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-CssClass="gvrows">
                                                            <ItemTemplate>
                                                                <label>
                                                                    <asp:CheckBox ID="chkImg" runat="server" />
                                                                    <img id="box-img-<%#Container.DataItemIndex%>" class="box-img" src="<%# Eval("ImagePath") %>" />

                                                                </label>
                                                                <asp:HiddenField ID="hfOrignalPath" Value='<%# Eval("OrignalImgPath") %>' runat="server" />
                                                                <asp:HiddenField ID="hfTempImgPath" Value='<%# Eval("ImagePath") %>' runat="server" />
                                                                <asp:HiddenField ID="hfIndex" Value='<%# Eval("Index") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="col-sm-10 col-xs-8 form-horizontal">
                                            <div class="form-group">
                                                <div class="img-preview-scroll scroller">
                                                    <!-- previewMainImage-->
                                                    <img id="preview" alt="Select Document" class="previewMainImage zoom gallery-items" runat="server" data-magnify-src="~/img/user.png" />
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>
                </div>
                <asp:HiddenField ID="hfSystemID" runat="server" />
                <asp:HiddenField ID="hfImageCount" runat="server" />
                <asp:HiddenField ID="hfImageIndex" runat="server" />
                <asp:HiddenField ID="hfImagePath" runat="server" />
            </div>
            <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
        </div>
        <!-- /.content -->
        <!-- jQuery 2.1.4 -->
    </div>
</asp:Content>


