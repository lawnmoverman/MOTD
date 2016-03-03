
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

function getPrize(id) {
    var temp = "http://" + window.location.host + "/api/Prize/GetPrize/1";
    $.ajax({        
        url: "http://" + window.location.host + "/api/Prize/GetPrize/1",
        type: 'GET',
        dataType: 'JSON',
        success: function (data) {
            ShowPrize(data);

        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}

function ShowPrizes(listOfPrizes) {
    var strResult = "<table class='table-bordered' align='left' width='90%'><thead><tr><th style='visibility:hidden;'>PrizeID</th><th>Name</th><th>Description</th><th>Is prize won by user ?</th><th>Actions</th></tr></thead><tbody>";
    $.each(listOfPrizes, function (index, prize) {
        var del = "</td><td><a href='#'"; del += " onClick='confirmDelete("; del+=prize.Id; del+=");'"; del += ">Delete  |  </a>";
        var edit = "<a href='Edit/"; edit += prize.Id; edit += "'>Edit</a></td>";
        strResult += "<tr><td style='visibility:hidden;'>" + prize.Id + "</td><td> " + prize.Name + "</td><td>" + prize.Description + "</td><td>" + (prize.IsWon ? 'Yes' : 'No') + del + edit + "</tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);

}


function ShowPrize(Prize) {
    var strResult = "<form id='formoid' title='' method='post'><div><label class='title'>Prize name";
    strResult+="</label><input type='text' id='Name' name='name' value='" +Prize.Name  + "'>";
    strResult += "</div><div><label class='title'>Description</label><input type='text' id='Description' name='Description' value='" + Prize.Description + "'>";
    strResult+="</div><div><label class='title'>Is prize won </label><input type='checkbox' id='IsWon' name='IsWon' value='" +Prize.IsWon +"'>";
    strResult += "</div><div><input type='button' onclick='savePrize()' id='submitButton' name='submitButton' value='Save changes'>   "; 
    strResult += "<input type='button' onclick=window.location.href id='cancelButton' name='cancelButton' value='Cancel'></div></form>";
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


function deleteItem(id) {
    jQuery.support.cors = true;
    
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

 
function confirmDelete(id){
    var agree=confirm("Are you sure you want to delete this prize ?");
    if (agree)
    {
        deleteItem(id);
        window.location.href = 'Index';
    }        
    else
    {
        return false;
    }
    
}
