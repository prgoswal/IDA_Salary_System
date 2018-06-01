<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EntryLevel.ascx.cs" Inherits="UserControl_EntryLevel" %>
<ul class="sidenav">

    <li>
        <a href="#" data-toggle="collapse" data-target="#ine" class="collapsed">
            <i class="fa fa-gears fa-sidenav"></i>
            <span class="text-sidenav">Master</span>
        </a>
        <ul class="sidenav collapse" id="ine">
            <li>

                <a href="<%# ResolveUrl("~/Legal/frmCaseMaster.aspx") %>">
                    <span class="text-sidenav">Case Master</span>
                </a>
            </li>
            <li>
                <a href="<%# ResolveUrl("~/Legal/FrmCaseStage.aspx") %>">

                    <span class="text-sidenav">Stage Master</span>
                </a>
            </li>

            <li>
                <a href="<%# ResolveUrl("~/Legal/FrmCourtType.aspx") %>">

                    <span class="text-sidenav">Court Type Master</span>
                </a>
            </li>
            <li>

                <a href="<%# ResolveUrl("~/Legal/FrmCourt.aspx") %>">
                    <span class="text-sidenav">Court Master</span>
                </a>
            </li>
            <li>

                <a href="<%# ResolveUrl("~/Legal/FrmReplyType.aspx") %>">
                    <span class="text-sidenav">Case Reply Type Master</span>
                </a>
            </li>
            <li>

                <a href="<%# ResolveUrl("~/Legal/frmAdvocateMaster.aspx") %>">
                    <span class="text-sidenav">Advocate Master</span>
                </a>
            </li>


        </ul>
    </li>





    <li>
        <a href="#" data-toggle="collapse" data-target="#ine2" class="collapsed">
            <i class="fa fa-dashboard fa-sidenav"></i>
            <span class="text-sidenav">Transaction</span>
        </a>
        <ul class="sidenav collapse" id="ine2">
            <li>

                <a href="<%# ResolveUrl("~/Legal/frmCaseDetail.aspx") %>">
                    <span class="text-sidenav">Case Detail</span>
                </a>
            </li>
            <li>

                <a href="<%# ResolveUrl("~/Legal/CaseProgressEntry.aspx") %>">
                    <span class="text-sidenav">Case Progress Entry</span>
                </a>
            </li>

        </ul>
    </li>
    <li>
        <a href="#" data-toggle="collapse" data-target="#ine1" class="collapsed">
            <i class="fa fa-dashboard fa-sidenav"></i>
            <span class="text-sidenav">Utility</span>
        </a>
        <ul class="sidenav collapse" id="ine1">
            <li>

                <a href="<%# ResolveUrl("~/Legal/Frmcasesearch.aspx") %>">
                    <span class="text-sidenav">Case Search</span>
                </a>
            </li>
            <li>

                <a href="<%# ResolveUrl("~/Legal/FrmcaseHistory.aspx") %>">
                    <span class="text-sidenav">Case History</span>
                </a>
            </li>

        </ul>
    </li>

    <li>
        <a href="#" data-toggle="collapse" data-target="#ine3" class="collapsed">
            <i class="fa fa-dashboard fa-sidenav"></i>
            <span class="text-sidenav">Updation</span>
        </a>
        <ul class="sidenav collapse" id="ine3">

            <li>

                <a href="<%# ResolveUrl("~/Legal/frmCaseDetailUpdate.aspx") %>">
                    <span class="text-sidenav">Case Detail Update</span>
                </a>
            </li>

        </ul>
    </li>



    <li>
        <a href="#" data-toggle="collapse" data-target="#ine4x" class="collapsed">
            <i class="fa fa-dashboard fa-sidenav"></i>
            <span class="text-sidenav">Report</span>
        </a>
        <ul class="sidenav collapse" id="ine4x">
            <li>

                <a href="#" data-toggle="collapse" data-target="#ine4" class="collapsed">
                    <i class="fa fa-dashboard fa-sidenav"></i>
                    <span class="text-sidenav">Master Report</span>
                </a>

                <ul class="sidenav collapse" id="ine4">
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstReplyType.aspx") %>">
                            <span class="text-sidenav">Reply Type Master Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstCourt.aspx") %>">
                            <span class="text-sidenav">Court Master Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstCaseType.aspx") %>">
                            <span class="text-sidenav">Case Type Master Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstCourtType.aspx") %>">
                            <span class="text-sidenav">Court Type Master Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstCaseStage.aspx") %>">
                            <span class="text-sidenav">Case Stage Master Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptMstAdvocate.aspx") %>">
                            <span class="text-sidenav">Advocate Master Report</span>
                        </a>
                    </li>



                </ul>
            </li>

            <li>
                <a href="#" data-toggle="collapse" data-target="#ine5" class="collapsed">
                    <i class="fa fa-dashboard fa-sidenav"></i>
                    <span class="text-sidenav">Transaction Report</span>
                </a>
                <ul class="sidenav collapse" id="ine5">

                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptCaseDetail.aspx") %>">
                            <span class="text-sidenav">Case Detail Report</span>
                        </a>
                    </li>


                </ul>
            </li>


            <li>
                <a href="#" data-toggle="collapse" data-target="#ine6" class="collapsed">
                    <i class="fa fa-dashboard fa-sidenav"></i>
                    <span class="text-sidenav">MIS Report</span>
                </a>
                <ul class="sidenav collapse" id="ine6">

                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptAdvocateCaseCount.aspx") %>">
                            <span class="text-sidenav">Advocate Case Count Report</span>
                        </a>
                    </li>

                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptOICCaseCount.aspx") %>">
                            <span class="text-sidenav">OIC Case Count Report</span>
                        </a>
                    </li>

                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptCourtTypeCaseCount.aspx") %>">
                            <span class="text-sidenav">Court Type Case Count Report</span>
                        </a>
                    </li>
                    <li>
                        <a href="<%# ResolveUrl("~/Legal/MstReport/RptCourtPlaceCaseCount.aspx") %>">
                            <span class="text-sidenav">Court Place Case Count Report</span>
                        </a>
                    </li>

                </ul>
            </li>

        </ul>



    </li>


</ul>
