
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
        var del = "</td><td><a href=Delete/"; del += prize.Id; del += ">Delete  |  </a>";
        var edit = "<a href=Edit/"; edit += prize.Id; edit += ">Edit</a></td>";
        strResult += "<tr><td style='visibility:hidden;'>" + prize.Id + "</td><td> " + prize.Name + "</td><td>" + prize.Description + "</td><td>" + (prize.IsWon ? 'Yes' : 'No') + del + edit + "</tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);

}

function savePrize()
{
    var prize = {};
    prize.Name = document.getElementById('Name').value;
    prize.Description = document.getElementById('Description').value;
    prize.IsWon = document.getElementById('IsWon').value;;
   
    addNewPrize(prize);
}



function addNewPrize(Prize) {

    $.ajax({
        url: "http://" + window.location.host + "/api/prize/Post",
        type: 'POST',
        data: JSON.stringify(Prize),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert("Uspešno sačuvano !");

        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}


function deleteItem() {
    jQuery.support.cors = true;
    var id = 8;

    $.ajax({
        url: "http://" + window.location.host + "/api/prize/" + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}