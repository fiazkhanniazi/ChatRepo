

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44319/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (model) {
    
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.
    //if (model.message.includes("Bot")) {
    //    model.targetUserName = "Bot";
    //}
    li.textContent = `${model.targetUserName} : ${model.message}          ${model.dateTime}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
   
    var message = document.getElementById("messageInput").value;

    var model = { TargetUserName: '', Message: message, DateTime: Date.DateTime }
    connection.invoke("SendMessageAsync", model).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});