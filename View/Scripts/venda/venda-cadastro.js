$(function () {
    $("#venda-cliente").select2({
        ajax: {
            url: "/pessoa/obtertodosselec2",
            dataType: "Json"
        }
    });
});