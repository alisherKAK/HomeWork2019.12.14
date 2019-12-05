$("form").submit(function (e) {
    var filePath = $("input[type=file]").val();
    $.post("/Post/Create", { ImagePath: filePath, Content: $("input[type=text]").val() });

    e.preventDefault();
    return false;
});