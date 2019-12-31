// Modal Message
$(function () {
    $("#modalMessageSend").click(function (event) {
        var content = $("#modalMessageContent").val();
        content = content.trim();
        if (content.length > 0) {
            var resText = $.ajax({
                url: "/Messages/Create",
                async: true,
                type: "POST",
                data: {
                    content: content
                }
            }).responseText;
        }
        $("#modalMessageContent").val("");
        $("#modalMessage").modal("hide");
    });
});