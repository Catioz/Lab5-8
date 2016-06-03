
$(document).ready(function () {
    function koModel() {
        this.name = ko.observable("");
        var mas = [];

        this.createNotepad = function () {
            $.post("/Home/Create", { Name: this.name() });
            $.post("/Home/Image", { Name: this.name() });
            Add(this.name());
        };
        function Add(name) {
            if (name) {
                mas.push(name);
                var list = document.getElementById('list');
                var li = document.createElement('li');
                li.innerHTML = name;
                list.appendChild(li)
            }
        };
    };
    ko.applyBindings(new koModel());

    var  name = "";
    save.onclick = function () {
        var text = $('#text').val();
        $.post("/Home/Record", { Name: name, Text: text });
    };
    $('#list').click(function (event) {
        name = event.target.innerHTML;
        $('#namelist').val(name);
        image(name);
        load(name);
    });
    function load(name) {
        $.post("/Home/Load", { Name: name }).success(function (text) {
            $('#text').val(text);
        });
    };
    function image(name) {
        $('img').attr('src', '/Content/name/' + name +'.jpg');
    };


});