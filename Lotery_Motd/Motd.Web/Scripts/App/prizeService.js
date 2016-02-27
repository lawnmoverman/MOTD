
function getAllPrizes()
{
    
    $.ajax({
        url: 'api/prize/GetAllPrizes',
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
    var strResult = "<table><th>prizeID</th><th> Name</th><th> Description</th><th> Is won</th>";
    $.each(listOfPrizes, function (index, prize) {
        strResult += "<tr><td>" + prize.Id + "</td><td> " + prize.Name + "</td><td>" + prize.Description + "</td><td>" + prize.IsWon + "</td></tr>";
    });
    strResult += "</table>";
    $("#divResult").html(strResult);
}

function savePrize()
{
    var prize = {};
    prize.Name = "Nova Nagrada";
   // prize.Description = $('#txtaddEmpid').val();

    prize.Description = "Opis";
    prize.IsWon = true;
    addNewPrize(prize);
}


function addNewPrize(Prize) {

    $.ajax({
        url: 'api/prize/addNewPrize',
        type: 'Post',
        data: JSON.stringify(Prize),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert("SAcuvano");

        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

}