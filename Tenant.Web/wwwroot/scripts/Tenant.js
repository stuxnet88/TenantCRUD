$(document).ready(function () {
    loadTenant();
    var Genders = [];
    var Tenants = [];
    var selectedTenat = {};
});
function loadTenant() {
    $.getJSON('/Home/GetTenants', function (data) {
        Tenants = data.tenants;
        Genders = data.genders;
        var tenantData = '';
        $.each(Tenants, function (i, tenant) {
            tenantData += '<tr>';
            tenantData += '<td>' + tenant.firstName + '</td>';
            tenantData += '<td>' + tenant.middleName + '</td>';
            tenantData += '<td>' + tenant.lastName + '</td>';
            tenantData += '<td>' + tenant.nickName + '</td>';
            tenantData += '<td>' + GetDate(tenant.dob); + '</td>';
            tenantData += '<td>' + tenant.active + '</td>';
            tenantData += '<td>' + tenant.prefixId + '</td>';
            $.each(Genders, function (i, gender) {
                if (gender.genderId === tenant.genderId) {

                    tenantData += '<td>' + gender.name + '</td>';
                }
            });
            tenantData += '<td><a href="#" class="btn btn-primary" onclick="return GetTenantByID(' + tenant.tenantId + ')">Edit</a>   <a href="#"  class="btn btn-danger"  onclick="DeleleTenant(' + tenant.tenantId + ')">Delete</a></td>';
            tenantData += '</tr>';
        });

        $('#tanetsTable').html(tenantData);
    });
}
function SaveTenant() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var TenantId = $('#TenantId').val();
    var FirstName = $('#FirstName').val();
    var MiddleName = $('#MiddleName').val();
    var LastName = $('#LastName').val();
    var NickName = $('#NickName').val();
    var DOB = $('#DOB').val();
    var Active = $('#Active').val();
    var PrefixId = $('#PrefixId').val();
    var GenderId = "";
    $.each(Genders, function (i, gender) {
        if ($('#' + gender.genderId).prop("checked")) {
            GenderId = gender.genderId;
        }
    });
    $.post("/Home/EditTenant", { TenantId: TenantId, FirstName: FirstName, MiddleName: MiddleName, LastName: LastName, NickName: NickName, DOB: DOB, Active: Active, PrefixId: PrefixId, GenderId: GenderId }, function (data) {
        $('#myModal').modal('hide');
        clearTextBox();
        loadTenant();
    });
}

function AddTenant() {
    $('#myModal').modal('show');
    selectedTenat = {};
    BindGender(Genders, "Add");
    clearTextBox();
}
function GetDate(dob) {
    var n = dob.indexOf('T');
    dob = dob.substring(0, n !== -1 ? n : dob.length);
    return dob;
}
function GetTenantByID(TenantId) {
    selectedTenat = Tenants.find(x => x.tenantId === TenantId);
    $('#myModal').modal('show');

    $('#TenantId').val(selectedTenat.tenantId);
    $('#FirstName').val(selectedTenat.firstName);
    $('#MiddleName').val(selectedTenat.middleName);
    $('#LastName').val(selectedTenat.lastName);
    $('#NickName').val(selectedTenat.nickName);
    $('#DOB').val(GetDate(selectedTenat.dob));
    $('#PrefixId').val(selectedTenat.prefixId);
    if (selectedTenat.active === true) {

        $('#Active').attr("checked", true);
    }
    else {
        $('#Active').attr("checked", false);
    }
    BindGender(Genders, "Edit");
    return false;
}

function BindGender(Genders, actionType) {
    var genderHtml = '';
    $.each(Genders, function (i, gender) {
        genderHtml += '<div class="col-2"><label for="Gender"  style="float=right">' + gender.name + '</label></div>';

        genderHtml += ' <div class="col-1"><input type="radio" style="float=right" class="form-control" name="gender"  value=' + gender.genderId + '   placeholder = "Gender" id = "' + gender.genderId;
        if (actionType === "Edit") {
            if (selectedTenat.genderId === gender.genderId) {
                genderHtml += '" checked />';
            }
            else {
                genderHtml += '"></div>';
            }
        }
        else {
            if (i === 0) {
                genderHtml += '" checked /></div>';
            }
            else

                genderHtml += '"></div>';
        }
    });
    $('#genderData').html(genderHtml);
}
function DeleleTenant(TenantId) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.post("/Home/DeleteTenant", { TenantId: TenantId }, function (data) {
            loadTenant();
        });
    }
}

function clearTextBox() {
    $('#TenantId').val("");
    $('#FirstName').val("");
    $('#MiddleName').val("");
    $('#LastName').val("");
    $('#NickName').val("");
    $('#DOB').val("");
    $('#PrefixId').val("");
    $('#Active').val("");
    $('#GenderId').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    return false;
}
function validate() {
    var isValid = true;
    if ($('#FirstName').val().trim() === "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#MiddleName').val().trim() === "") {
        $('#MiddleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MiddleName').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() === "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#NickName').val().trim() === "") {
        $('#NickName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NickName').css('border-color', 'lightgrey');
    }
    if ($('#DOB').val().trim() === "") {
        $('#DOB').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DOB').css('border-color', 'lightgrey');
    }
    if ($('#PrefixId').val().trim() === "") {
        $('#PrefixId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PrefixId').css('border-color', 'lightgrey');
    }
    if ($('#GenderId').val() === "") {
        $('#GenderId').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#GenderId').css('border-color', 'lightgrey');
    }
    return isValid;
}
