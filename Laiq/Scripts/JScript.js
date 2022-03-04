var varTheme = 'classic';

function SetChosen(varCombo, varURL, varID, varValue, varHeight, varWidth) {
    varHeight = typeof varHeight !== 'undefined' ? varHeight : 30;
    varWidth = typeof varWidth !== 'undefined' ? varWidth : 200;
    $.getJSON(varURL, function (data) {
        $.each(data, function (key, value) {
            $('<option>').val(value[varID]).text(value[varValue]).appendTo($(varCombo));
        });
        $(varCombo).chosen({ width: "100%", height: "100%" });
        $(varCombo).chosen().change(function () {
            if ($(this).val() == null) {
                $(varCombo + '_chosen').find('a:first').css("border-color", "#ee0000");
            }
            else {
                $(varCombo + '_chosen').find('a:first').css("border-color", "classic");
            }
        });
    });
}

function SetChosenValue(varCombo, varValue) {
    $(varCombo).val(varValue).trigger("chosen:updated");
}






function ShowModal(varModal) {
    $('#' + varModal).modal({
        backdrop: 'static',
        keyboard: false
    });
}

function SaveBtnClick(varBtn, varPK, varCreate, varEdit, varFrm, varModal, varGrid) {
    $("#" + varBtn).click(function () {
        var validationResult = function (isValid) {
            if (isValid) {
                var varURL = ($("#" + varPK).val() == '' || $("#" + varPK).val() == null) ? varCreate : varEdit;
                if ($("#" + varPK).val() == '') {
                    $("#" + varPK).remove();
                }
                $.ajax(
                {
                    url: varURL,
                    type: 'post',
                    data: $('#' + varFrm).serialize(),
                    success: function (results) {
                        if (results == "Record Saved") {
                            //var newID = results.EduID;
                            $('#' + varFrm).append("<input type='hidden' id='" + varPK + "' name='" + varPK + "' value='' />");
                            toastr["success"]("معلومات موفقانه درج سیستم گردید");
                            $('#' + varModal).modal('toggle');
                            $('#' + varGrid).jqxGrid('updatebounddata', 'data');
                        }
                        else
                            if (results == "Record Updated") {
                                toastr["success"]("معلومات تعدیل/اصلاح گردید");
                                $('#' + varModal).modal('toggle');
                                $('#' + varGrid).jqxGrid('updatebounddata', 'data');
                            }
                            else {
                                toastr["error"](results);
                            }
                    }
                });
            }
        }
        $('#' + varFrm).jqxValidator('validate', validationResult)
    });
}
function HideModal(closeBtn, cancelBtn, frmName, modalName) {
    $("." + closeBtn).on('mousedown', function () {
        $('#' + frmName).jqxValidator('hide');
        $('#' + modalName).modal('hide');
    });
    $("#" + cancelBtn).click(function () {
        $('#' + frmName).jqxValidator('hide');
        $('#' + modalName).modal('hide');
    });
}
function makeDates(varFields, varFormName, dir) {
    for (varField in varFields) {
        var varid = varFields[varField].split("_").pop();
        dir == 'ltr' ? $('#' + varFields[varField]).calendarsPicker({ dateFormat: 'yyyy-mm-dd' }) : $('#' + varFields[varField]).calendarsPicker({ calendar: $.calendars.instance('persian') });
        $('#' + varFormName).append('<input type="text" id="' + varid + '" name="' + varid + '"  />');

        $('#' + varFields[varField]).bind('change',function (event) {
            if (event.args) {
                dir == 'ltr' ? $('#' + $(this).attr('id').split("_").pop() + '').val(event.args.value) : setPersianDate($(this).attr('id').split("_").pop() + '', event.args.value);
                return;
            }
        });
    }
}
function setPersianDate(Field, Dvalue) {
    if (Dvalue != '') {
        var calendar = $.calendars.instance('persian');
        var year = Dvalue.toString().substring(0, 4);
        var Month = Dvalue.toString().substring(5, 7);
        var Day = parseInt(Dvalue.toString().substring(8, 10), 10);
        var d = $.calendars.newDate(year, Month, Day, 'persian', 'fa');
        jd = calendar.toJD(d)
        var e = $.calendars.instance('');
        $("#" + Field).val(e.fromJD(jd));
    }
}
function EditInputs(varFields, varDataRecord) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $('#' + varid).val(varDataRecord[varid])
    }
}
function setAddBtn(varField, varDirection, varWidth, varHeight) {
    $("#" + varField).jqxButton({ width: varWidth, height: varHeight });
    var varDirection1 = varDirection == 'left' ? 'right' : 'left';
    var Direction = 'pull-' + varDirection1
    $("#" + varField).addClass(Direction);
}
function setSubmitBtn(varField, varWidth, varHeight) {
    $("#" + varField).jqxButton({ width: varWidth, height: varHeight, theme: varTheme });
}
function setCancelBtn(varField, varWidth, varHeight) {
    $("#" + varField).jqxButton({ width: varWidth, height: varHeight });
}
function clearInputs(varFields) {
    for (varField in varFields) {
        var varid = varFields[varField];
        $('#' + varid).val('');
    }
}
function clearCombs(varFields) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $('#' + varid).jqxComboBox('clearSelection');
        var varHiddenID = varFields[varField].split("_").pop();
        $("#" + varHiddenID).val('');

    }
}
function unCheckBox(varFields) {
    for (varField in varFields) {
        var varid = varFields[varField];
        $('#' + varid).attr('checked', false);
    }
}
function setGridDirection(varGridName, varDir) {
    if (varDir == 'rtl') {
        $('#' + varGridName).jqxGrid({ rtl: true });
    }
}
function fillGridByPost(df, varGridName, varURL) {
    var source =
{
    datatype: "json",
    datafields: df,
    cache: false,
    url: varURL,
    root: 'Rows',
    type: 'POST'
};

    var dataadapter = new $.jqx.dataAdapter(source, {
        loadError: function (xhr, status, error) {
            console.log(error);
        }
    }
    );

    $("#" + varGridName).jqxGrid(
    {
        source: dataadapter
    });
}
function fillGrid(df, varGridName, varURL) {
    var source =
{
    datatype: "json",
    datafields: df,
    cache: false,
    url: varURL,
    root: 'Rows'
};

    var dataadapter = new $.jqx.dataAdapter(source, {
        loadError: function (xhr, status, error) {
            console.log(error);
        }
    }
    );

    $("#" + varGridName).jqxGrid(
    {
        source: dataadapter
    });
}
function setInputNumber(varField, varWidth, varHeight) {
    $("#" + varField).jqxNumberInput({ width: varWidth, height: varHeight, spinButtons: true, theme: varTheme, max: 99999999999, digits: 8 });
}
function setInputsNumbers(varFields, varWidth, varHeight) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $("#" + varid).jqxNumberInput({ width: varWidth, height: varHeight, spinButtons: true, theme: varTheme, max: 99999999999, digits: 8 });
    }
}

function setInput(varField, varWidth, varHeight) {
    $("#" + varField).jqxInput({ width: varWidth, height: varHeight, theme: varTheme });
}
function setInputDr(varField, varWidth, varHeight) {
    $("#" + varField).jqxInput({ width: varWidth, height: varHeight, theme: varTheme, rtl: true });
}
function setInputs(varFields, varWidth, varHeight) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $("#" + varid).jqxInput({ width: varWidth, height: varHeight, theme: varTheme });
    }
}
function setInputsDr(varFields, varWidth, varHeight) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $("#" + varid).jqxInput({ width: varWidth, height: varHeight, theme: varTheme, rtl: true });
    }
}
function setInputDate(varField, varWidth, varHeight) {
    $('#' + varField).jqxDateTimeInput({ width: varWidth, height: varHeight, formatString: "yyyy-MMM-dd", theme: varTheme });
    $('#' + varField).val('');
}
function setInputsDate(varFields, varWidth, varHeight) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $('#' + varid).jqxDateTimeInput({ width: varWidth, height: varHeight, formatString: "yyyy-MMM-dd", theme: varTheme });
        $('#' + varid).val('');

    }
}
function setCheckBox(varField, varWidth, varHeight) {
    $('#' + varField).jqxCheckBox({ width: varWidth, height: varHeight, theme: varTheme, checked: false });
    $('#' + varField).val(0);

}
function setCheckBoxs(varFields, varWidth, varHeight) {
    for (varField in varFields) {
        var varid = varFields[varField]
        $('#' + varid).jqxCheckBox({ width: varWidth, height: varHeight, theme: varTheme, checked: false });
        $('#' + varid).val(0);
    }
}
function makeDeletePopup(varWindow, varCancel, varOk) {
    $("#" + varWindow).jqxWindow({ width: 250, height: 120, resizable: false, theme: 'arctic', isModal: true, autoOpen: false, cancelButton: $("#Cancel2"), modalOpacity: 0.5,rtl:true });
    $("#" + varCancel).jqxButton({ height: 30, width: 80 });
    $("#" + varOk).jqxButton({ height: 30, width: 80 });
}
function makeContextMenu(varMenu, varGrid, varWidth, varHeight) {
    var contextMenu = $("#" + varMenu).jqxMenu({ width: varWidth, height: varHeight, autoOpenPopup: false, mode: 'popup', theme: 'arctic' });
    $("#" + varGrid).on('contextmenu', function () {
        return false;
    });
    $("#" + varGrid).on('rowclick', function (event) {
        if (event.args.rightclick) {
            $("#" + varGrid).jqxGrid('selectrow', event.args.rowindex);
            var scrollTop = $(window).scrollTop();
            var scrollLeft = $(window).scrollLeft();
            contextMenu.jqxMenu('open', parseInt(event.args.originalEvent.clientX) + 5 + scrollLeft, parseInt(event.args.originalEvent.clientY) + 5 + scrollTop);

            return false;
        }
    });
}
function makeCombHidden(varFields, varFormName) {
    for (varField in varFields) {
        var varid = varFields[varField].split("_").pop();
        //alert(varid);
        $('#' + varFormName).append('<input type="hidden" id="' + varid + '" name="' + varid + '"  />');
        $('#' + varFields[varField]).bind('change', function (event) {
            //alert($(this).attr('id'));
            $('#' + $(this).attr('id').split("_").pop() + '').val(event.args.item.value);
        });
    }
}
function makeNumberHidden(varFields, varFormName) {
    for (varField in varFields) {
        var varid = varFields[varField].split("_").pop();
        //alert(varFields[varField]);
        $('#' + varFormName).append('<input type="hidden" id="' + varid + '"  name="' + varid + '" />');

        $('#' + varFields[varField]).bind('change', function (event) {
            $('#' + $(this).attr('id').split("_").pop() + '').val(event.args.value);
        });
    }
}
function makeCheckHidden(varFields, varFormName) {
    for (varField in varFields) {
        var varid = varFields[varField].split("_").pop();
        //alert(varFields[varField]);
        $('#' + varFormName).append('<input type="hidden" id="' + varid + '"  name="' + varid + '" value="0" />');

        $('#' + varFields[varField]).bind('change', function (event) {
            if (event.args.checked) {
                $('#' + $(this).attr('id').split("_").pop() + '').val('1');
            } else {
                $('#' + $(this).attr('id').split("_").pop() + '').val('0');
            }
            
        });
    }
}
function makeDateHidden(varFields, varFormName) {
    for (varField in varFields) {
        var varid = varFields[varField].split("_").pop();
        $('#' + varFormName).append('<input type="hidden" id="' + varid + '" name="' + varid + '" />');
        $('#' + varFields[varField]).bind('change', function (event) {
            var mydate = new Date(event.args.date);
            var str = mydate.getFullYear() + '-' + (mydate.getMonth() + 1) + '-' + mydate.getDate()
            if (str == '1/1/1970' || str == '1970-1-1') {
                str = null;
            }
            else {
                $('#' + $(this).attr('id').split("_").pop() + '').val(str);
            }
        });
    }
}
function setCombo(varCombo, varURL, varID, varValue, varHeight, varWidth, varAuto) {

    varHeight = typeof varHeight !== 'undefined' ? varHeight : 30;
    varWidth = typeof varWidth !== 'undefined' ? varWidth : 200;
    var auto = (varAuto == 1) ? true : false;
    var source =
    {
        datatype: "json",
        datafields: [
            { name: varID },
            { name: varValue }
        ],
        url: varURL,
        async: false
    };
    var dataAdapter = new $.jqx.dataAdapter(source);

    $(varCombo).jqxComboBox({ source: dataAdapter, placeHolder: "-- انتخاب نماید --", displayMember: varValue, valueMember: varID, width: varWidth, theme: varTheme, autoDropDownHeight: auto,rtl:true,searchMode: 'containsignorecase', autoComplete: true });
}
function setComb(varCombo, varURL, varID, varValue, varTheme, varHeight, varWidth, varAuto) {
    var auto = (varAuto == 1) ? true : false;
    varHeight = typeof varHeight !== 'undefined' ? varHeight : 30;
    varWidth = typeof varWidth !== 'undefined' ? varWidth : 200;
    var source =
    {
        datatype: "json",
        datafields: [
            { name: varID },
            { name: varValue }
        ],
        url: varURL,
        async: true
    };
    var dataAdapter = new $.jqx.dataAdapter(source);

    $(varCombo).jqxComboBox({ source: dataAdapter, displayMember: varValue, valueMember: varID, width: varWidth, theme: varTheme, autoDropDownHeight: auto, searchMode: 'containsignorecase', autoComplete: true });
}
function setCombo2(varCombo, varURL, varID, varValue, varTheme, varHeight, varWidth, varAuto) {

    varHeight = typeof varHeight !== 'undefined' ? varHeight : 30;
    varWidth = typeof varWidth !== 'undefined' ? varWidth : 200;
    var auto = (varAuto == 1) ? true : false;
    var source =
    {
        datatype: "json",
        datafields: [
            { name: varID },
            { name: varValue }
        ],
        url: varURL,
        async: true
    };
    var dataAdapter = new $.jqx.dataAdapter(source);

    $(varCombo).jqxComboBox({ source: dataAdapter, placeHolder: " All ", displayMember: varValue, valueMember: varID, width: varWidth, theme: varTheme, autoDropDownHeight: auto });
    //return dataAdapter;
}
//THE CONTROLER SHOULD BE [HTTPOST] AND USE PREFIX '%' AT THE START AND END OF STRING
function AComplete(varTextBox,varURL,varField) {
    $("#" + varTextBox).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: varURL,
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.varField, value: item.varField };
                    }))
                }
            })
        },
        messages: {
            noResults: "", results: ""
        }
    });
}

function setCombMulti(varCombo, varURL, varID, varValue, varTheme, varHeight, varWidth, varAuto) {
    var auto = (varAuto == 1) ? true : false;
    varHeight = typeof varHeight !== 'undefined' ? varHeight : 30;
    varWidth = typeof varWidth !== 'undefined' ? varWidth : 200;
    var source =
    {
        datatype: "json",
        datafields: [
            { name: varID },
            { name: varValue }
        ],
        url: varURL,
        async: true
    };
    var dataAdapter = new $.jqx.dataAdapter(source);

    $(varCombo).jqxComboBox({ source: dataAdapter, displayMember: varValue, valueMember: varID, width: varWidth, theme: varTheme, autoDropDownHeight: auto, searchMode: 'containsignorecase', autoComplete: true, multiSelect: true });
}