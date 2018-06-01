<%@ Page Title="" Language="C#"  MasterPageFile="~/Lease/MainMaster.master"  AutoEventWireup="true" CodeFile="frmDocumentDisplay.aspx.cs" Inherits="forms_frmDocumentDisplay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
    <%-- <script>
        $(document).ready(function () {
            wheelzoom(document.querySelector('img.zoom'));
        })
    </script>--%>
    <script>
        $(document).ready(function () {
            var viewer = ImageViewer();
            $('.gallery-items').click(function () {
                debugger;
                //var imgSrc = this.src;
                highResolutionImage = '';
                highResolutionImage = $(this).data('magnify-src');
                //alert(highResolutionImage);
                viewer.show(highResolutionImage, highResolutionImage);
            });
        })
    </script>

    <script type="text/javascript">
        $(document).ready(function Controls() {
            $(document).ready(function () {



                // $('.previewMainImage').magnify();
                wheelzoom(document.querySelector('img.zoom'));
                <%-- $(document).ready(function () {
                   if ($('#<%=rbnFileTrackNo.ClientID%>').is(':checked')) {
                        $('.SerchingSysNamelbl').val('');
                        $('.SerchingSysNamelbl').text('File Track No.');
                        $('.txtSysUniqueNo').css('display', 'none');
                        $('.txtSysUniqueNo').val();
                        $('.txtFileTrackNo').css('display', 'block');
                        $('._FileTrakNo').css('display', 'none');
                        $('._SysNo').css('display', 'block');
                    }
                    else if ($('#<%=rbnSysUniqueNo.ClientID%>').is(':checked')) {
                        $('.SerchingSysNamelbl').val('');
                        $('.SerchingSysNamelbl').text('Lease No.');
                        $('.txtFileTrackNo').val();
                        $('.txtFileTrackNo').css('display', 'none');
                        $('.txtSysUniqueNo').css('display', 'block');
                        $('._FileTrakNo').css('display', 'block');
                        $('._SysNo').css('display', 'none');
                    }
                });--%>

              <%--  $(document).ready(function () {
                    $('.btnSearch').click(function () {
                        $('.MainImgDiv').css('display', 'none');
                        $('.ErrorDiv').css('display', 'none');
                        $('.ErrorMsg').val('');
                        $('.SuccessDiv').css('display', 'none');
                        $('.SuccessMsg').val('');

                        if (($('#<%=rbnFileTrackNo.ClientID%>').is(':checked') && $('.txtFileTrackNo').val() == "")) {
                            $('.ErrorDiv').css('display', 'block');
                            $('.ErrorMsg').text('File Track Number is required.');
                            $('.txtFileTrackNo').focus();
                            return false;
                        }
                        else if (($('#<%=rbnSysUniqueNo.ClientID%>').is(':checked') && $('.txtSysUniqueNo').val() == "")) {
                            alert('c');
                            $('.ErrorDiv').css('display', 'block');
                            $('.ErrorMsg').text('System Unique Number is required.');
                            $('.txtSysUniqueNo').focus();
                            return false;
                        }
                        else {
                            $('.ErrorDiv').css('display', 'none');
                            $('.ErrorMsg').val('');
                            $('.loadingq').css('display', 'block');
                            return true;
                        }
                    });
                });--%>
                $(document).ready(function () {
                    $('.print-type-radio input[type="radio"]').change(function () {
                        $('.SearchDetails').css('display', 'none');

                        var radioval = $(this).val();
                        if (radioval == "rbnFileTrackNo") {
                            $('.SerchingSysNamelbl').val('');
                            $('.SerchingSysNamelbl').text('File Track No.');
                            $('.txtSysUniqueNo').val('');
                            $('.txtSysUniqueNo').css('display', 'none');
                            $('.txtFileTrackNo').css('display', 'block');
                            $('._FileTrakNo').css('display', 'none');
                            $('._SysNo').css('display', 'block');
                            $('.MainImgDiv').css('display', 'none');
                        }
                        else {
                            $('.SerchingSysNamelbl').val('');
                            $('.SerchingSysNamelbl').text('Lease No.');
                            $('.txtFileTrackNo').val('');
                            $('.txtFileTrackNo').css('display', 'none');
                            $('.txtSysUniqueNo').css('display', 'block');
                            $('._FileTrakNo').css('display', 'block');
                            $('._SysNo').css('display', 'none');
                            $('.MainImgDiv').css('display', 'none');
                        }
                    });

                    $('.btnRptPrint').click(function () {
                        debugger;
                        var printContent = document.getElementById('divHtmlReport');
                        var img = $('.previewMainImage').attr('data-magnify-src');
                        var windowUrl = 'MyPage.aspx';
                        var uniqueName = new Date();
                        var windowName = "MyPage" + uniqueName.getTime();

                        printWindow = window.open(windowUrl, windowName, 'location=1,status=1,scrollbars=1,width=800,height=600');

                        printWindow.document.write("<div style='width:100%;'>");
                        printWindow.document.write("<img style='width:100%;' id='img' src='" + img + "'/>");
                        printWindow.document.write("</div>");

                        printWindow.document.close();
                        printWindow.focus();
                        printWindow.print();
                        printWindow.close();
                        return false;

                        //var divToPrint = $('.divHtmlReport').html();
                        //// alert(divToPrint);
                        ////document.getElementById('divHtmlReport');
                        //var newWin = window.open('', 'Print-Window');
                        //newWin.document.open();
                        //newWin.document.write('<html><body onload="window.print()">' + $('.divHtmlReport').html() + '</body></html>');
                        //newWin.document.close();
                        //setTimeout(function () { newWin.close(); }, 10);
                    });
                }

                );


            });
        });

    </script>

    <script>
        $(document).ready(function Load() {
            $(document).ready(function () {
                $('.doc-service-thumbnail table tr td img').each(function (i) {
                    $(this).attr("id", "box-img-" + (i + 1));
                });

                $('.slider-btns.prev').click(function () {
                    var currimg = $('.doc-service-thumbnail table tr td img.active').attr('id');

                    var idnumberstring = currimg.split('-');
                    var idnumber = idnumberstring[2];
                    if (idnumber != 1) {
                        $('#' + currimg).removeClass('active');
                        var activethis = parseInt(idnumber) - 1;
                        $('#box-img-' + activethis).addClass('active');

                        var labeltxt = $('#box-img-' + activethis).parent('td').find('label').html();
                        $('#lblDocType').text(labeltxt);

                        var minus = $('#box-img-' + activethis).attr('src');
                        $('.previewMainImage').attr('src', minus);
                        $('.previewMainImage').attr('data-magnify-src', minus);
                        var viewer = ImageViewer();
                        $('.gallery-items').click(function () {
                            // debugger;
                            //var imgSrc = this.src;
                            highResolutionImage = '';
                            highResolutionImage = $(this).data('magnify-src');
                            viewer.show(minus, minus);
                        });
                        //$('.previewMainImage').magnify();

                    }
                });
                $('.btnNext').click(function () {
                    var currimg = $('.doc-service-thumbnail table tr td img.active').attr('id');

                    var lastimgidnumber = $('.doc-service-thumbnail table tr td img').last().attr('id').split('-')[2];
                    var idnumberstring = currimg.split('-');
                    var idnumber = idnumberstring[2];
                    if (idnumber != parseInt(lastimgidnumber)) {
                        $('#' + currimg).removeClass('active');
                        var activethis = parseInt(idnumber) + 1;
                        $('#box-img-' + activethis).addClass('active');

                        var labeltxt = $('#box-img-' + activethis).parent('td').find('label').html();
                        $('#lblDocType').text(labeltxt);

                        var plus = $('#box-img-' + activethis).attr('src');
                        $('.previewMainImage').attr('src', plus);
                        $('.previewMainImage').attr('data-magnify-src', plus);
                        var viewer = ImageViewer();
                        $('.gallery-items').click(function () {
                            // debugger;
                            //var imgSrc = this.src;
                            highResolutionImage = '';
                            highResolutionImage = $(this).data('magnify-src');
                            viewer.show(plus, plus);
                        });
                        //$('.previewMainImage').magnify();

                    }
                });


                var fimg = $('.doc-service-thumbnail table tr td img').first();
                var labeltxt = $('.doc-service-thumbnail table tr td').first().find('label').html();
                $('#lblDocType').text(labeltxt);
                var onloadactive = fimg.attr('src');
                $(fimg).addClass('active');
                $('.previewMainImage').attr('src', onloadactive);
                $('.previewMainImage').attr('data-magnify-src', onloadactive);
                var viewer = ImageViewer();
                $('.gallery-items').click(function () {
                    // debugger;
                    //var imgSrc = this.src;
                    highResolutionImage = '';
                    highResolutionImage = $(this).data('magnify-src');
                    viewer.show(onloadactive, onloadactive);
                });
                //$('.previewMainImage').magnify();


                $('.doc-service-thumbnail table tr td img').click(function () {
                    debugger;
                    var url = $(this).attr('src');
                    var labeltxt = $(this).parent('td').find('label').html();
                    $('#lblDocType').text(labeltxt);
                    var OptUrl = url;
                    $('img.active').removeClass('active');
                    $(this).addClass('active');
                    $('.previewMainImage').attr('src', url);
                    $('.previewMainImage').attr('data-magnify-src', url);
                    var viewer = ImageViewer();
                    $('.gallery-items').click(function () {
                        // debugger;
                        //var imgSrc = this.src;
                        highResolutionImage = '';
                        highResolutionImage = $(this).data('magnify-src');
                        viewer.show(url, url);
                    });
                    //$('.previewMainImage').magnify();


                    var DocType = new Array();
                    $('.ddlDocType option').each(function () {
                        // DocType.push($(this).attr('value'));
                        DocType.push($(this).attr('text'));
                    });
                    var surl = OptUrl.split('_')[2];
                    var CompairCode = surl.split('.')[0];

                    //alert(CompairCode);
                    // alert(DocType);
                });
            });

        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scr" runat="server"></asp:ScriptManager>

  

    <!-- Main content -->
    <div class="container-fluid">
        <div class="pb0" style="padding-top: 10px">
            <div id="LoadingQ" runat="server" style="display: none;" class="loadingq load">Loading&#8230;</div>
            <div class="row">
                <div class="col-xs-12 col-sm-12">
                    <div class="panel panel-primary mb0">
                        <div class="panel-heading">
                            <h3 class="panel-title">Document Display Image
                            </h3>
                        </div>
                        <div class="panel-body panel-body-form slider-form form-horizontal ">
                            <div class="col-xs-12 col-sm-5">
                                <div id="Ctrl_Container" runat="server" class="Ctrl_Container">
                                    <%--<div class="form-group">
                                        <label id="SerchingSysName" class="control-label col-xs-12 col-sm-4 SerchingSysNamelbl"></label>
                                        <div class="col-xs-12 col-sm-8">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtFileTrackNo" runat="server" MaxLength="8" placeholder="File Track No." CssClass="form-control txtFileTrackNo"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FtbtxtFileTrackNo" runat="server" TargetControlID="txtFileTrackNo" FilterMode="ValidChars" FilterType="Numbers" />
                                                <asp:TextBox ID="txtSysUniqueNo" runat="server" MaxLength="9" placeholder="Lease No." CssClass="form-control txtSysUniqueNo"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbtxtSysUniqueNo" runat="server" TargetControlID="txtSysUniqueNo" FilterMode="ValidChars" FilterType="Numbers" />
                                                <span class="input-group-btn">
                                                    <asp:Button ID="btnSearch" Text="&#xf002;" runat="server" OnClick="btnSearch_Click" CssClass="fa-html btn btn-primary pull-right btnSearch" />
                                                </span>
                                            </div>
                                        </div>

                                    </div>--%>
                                    <div id="SearchDetails" runat="server" class="SearchDetails" style="display: block;">
                                        <%--  <div class="form-group _FileTrakNo">
                                            <label class="control-label col-xs-12 col-sm-4">File Track No.</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSFileNo" runat="server" CssClass="form-control" ReadOnly="true" />
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">File Track Descr.</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSFileDesc" runat="server" CssClass="form-control" ReadOnly="true" style="height:auto;" />
                                            </div>
                                        </div>
                                        <div class="form-group _SysNo">
                                            <label class="control-label col-xs-12 col-sm-4">System No.</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSSysNo" runat="server" CssClass="form-control" ReadOnly="true"  style="height:auto;"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">System Descr.</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSSysDesc" runat="server" CssClass="form-control" ReadOnly="true"  style="height:auto;"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Subject (English)</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSSubEng" runat="server" CssClass="form-control" ReadOnly="true"  style="height:auto;"/>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-xs-12 col-sm-4">Subject (Hindi)</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="txtSSubHindi" runat="server" CssClass="form-control hindi" ReadOnly="true"  style="height:auto;"/>
                                            </div>
                                        </div>--%>


                                        <asp:HiddenField ID="schCode" runat="server" />
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
                                            <label class="control-label col-xs-12 col-sm-4">Plot Holder Name</label>
                                            <div class="col-xs-12 col-sm-8">
                                                <asp:Label ID="lblPlotHolderName" runat="server" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="col-xs-12 text-right">
                                                <span id="IdaCustomAlert" runat="server" class="IdaCustomAlert" visible="false">
                                                        <span id="IdaCustomAlertMsg" runat="server"></span>
                                                </span>
                                              
                                                <asp:Button ID="Button1" ValidationGroup="s" Text="&#xf002; Search" runat="server" CssClass="fa-html btn btn-primary btnSearch" OnClick="btnSearch_Click" />
                                                  <asp:Button ID="btnClearsearch" Text=" Clear" runat="server" OnClick="btnClearsearch_Click" CssClass="fa-html btn btn-danger btnSearch" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div runat="server" id="pnlDocType" visible="false" class="col-xs-12 col-sm-7">
                                <div  class="col-md-12">
                            <label class="col-md-3">Document Type :-</label>
                                    <label class="col-md-8 text-left" id="lblDocType"></label>
                                </div>
                                <div id="MainImgDiv" runat="server" class="row MainImgDiv" style="display: none;">
                                    <div class="col-sm-12 col-xs-12 form-horizontal">
                                        <div class="form-group">
                                            <div class="img-preview-scroll-doc scroller divHtmlReport">
                                                <span class="slider-btns prev fa-html btnPrev">&#xf053;</span>
                                                <img src="" id="preview" class="previewMainImage zoom preview gallery-items" runat="server" data-magnify-src="" />
                                                <span class="slider-btns next fa-html btnNext">&#xf054;</span>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12 col-xs-12">

                                        <div class="hide-scroll-bar">
                                            <div id="ImgDiv" runat="server" class="doc-service-thumbnail dragscroll scroller">
                                                <asp:GridView ID="gvThumbnail" runat="server" Style="border: none;" AutoGenerateColumns="false" ShowHeader="false" >
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <img id="<%# Eval("ImageID") %>" class="box-img" src="<%# Eval("ImagePath") %>" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>

                </div>
            </div>
            <asp:Label ID="lblShowImgPath" runat="server"></asp:Label>
            <asp:HiddenField ID="hfSchemeCode" runat="server" />
            <asp:DropDownList ID="ddlDocType" runat="server" CssClass="ddlDocType" AppendDataBoundItems="true" Style="display: none;"></asp:DropDownList>
            <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
        </div>
        <!-- /.content -->
        <!-- jQuery 2.1.4 -->
    </div>
</asp:Content>




