/// <summary>
///   JS functions for PrizeController
/// </summary>


/// <summary>
///  Get all prizes.
/// </summary>       
/// <returns>List of prizes </returns>
function getAllPrizes()
{
    
    $.ajax({
        url: "http://" + window.location.host + "/api/prize/GetAllPrizes",
        type: 'GET',
        dataType: 'JSON',
        success: function (data) {
            ShowPrizes(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
function ShowPrizes(listOfPrizes) {
    var strResult = "<table class='table-bordered' align='left' width='90%'><thead><tr><th style='visibility:hidden;'>PrizeID</th><th>Name</th><th>Description</th><th>Is prize won by user ?</th><th>Actions</th></tr></thead><tbody>";
    $.each(listOfPrizes, function (index, prize) {
        var del = "</td><td><a href='#'"; del += " onClick='confirmDelete("; del += prize.Id; del += ");'"; del += ">Delete  |  </a>";
        var edit = "<a href='Edit/"; edit += prize.Id; edit += "'>Edit</a></td>";
        strResult += "<tr><td style='visibility:hidden;'>" + prize.Id + "</td><td> " + prize.Name + "</td><td>" + prize.Description + "</td><td>" + (prize.IsWon ? 'Yes' : 'No') + del + edit + "</tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);

}

/// <summary>
///   Get single prize object by Id.
/// </summary>
/// <param name="id"> Primary key </param>
/// <returns>Single prize object.</returns>
function getPrize(id) {
    var _url = "http://" + window.location.host + "/api/Prize/GetPrize/" + id;
    $.ajax({
        url: _url,
        type: 'GET',
        dataType: 'JSON',
        success: function (data) {
            $("#Name").val(data.Name);
            $("#Description").val(data.Description);
            if (data.IsWon == true)
            {
                $("#IsWon").prop("checked", true);
            }
            else
            {
                $("#IsWon").prop("checked", false);
            }
            
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

/// <summary>
///   Add new prize.
/// </summary>
/// <param name="prize"> Prize view model. </param>
/// <returns>Prize view model. </returns>
function savePrize()
{
    var prize = {};
    prize.Name = document.getElementById('Name').value;
    prize.Description = document.getElementById('Description').value;
    prize.IsWon = $("#IsWon").is(":checked");  

    addNewPrize(prize);
}
function addNewPrize(Prize) {

    $.ajax({
        url: "http://" + window.location.host + "/api/prize/Post",
        type: 'POST',
        data: JSON.stringify(Prize),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert("Successfully saved  !");
            window.location.href = '/Prize/Index';
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

/// <summary>
///   Gets object by primary key.
/// </summary>
/// <param name="prize"> Prize view model. </param>
/// <returns>Prize view model. </returns>
function editPrize(id) {
    var prize = {};
    prize.Id = id;
    prize.Name = document.getElementById('Name').value;
    prize.Description = document.getElementById('Description').value;
    prize.IsWon = $("#IsWon").is(":checked");

    addEditedPrize(prize);
}
function addEditedPrize(Prize) {
    var _url = "http://" + window.location.host + "/api/Prize/" + Prize.Id;
    $.ajax({
        url: _url,
        type: 'PUT',
        data: JSON.stringify(Prize),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert("Changes successfully saved !");
            window.location.href = '/Prize/Index';            
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

/// <summary>
///   Delete prize.
/// </summary>
/// <param name="id"> primary key. </param>
/// <returns>true/false. </returns>
function confirmDelete(id){
    var agree=confirm("Are you sure you want to delete this prize ?");
    if (agree)
    {
        deleteItem(id); 
    }        
    else
    {
        window.location.href = '/Prize/Index';
        return false;
    }
    
}
function deleteItem(id) {
    jQuery.support.cors = true;

    $.ajax({
        url: "http://" + window.location.host + "/api/prize/" + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //WriteResponse(data);
            window.location.href = '/Prize/Index';
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
