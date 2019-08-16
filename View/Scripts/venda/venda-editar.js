$(function () {
    $idVenda = $("#id").val();
    $tabela = $("#venda-produtos-index").DataTable({
        ajax: "/produto/obtertodospeloidvenda?idVenda=" + $idVenda,
        serveSide: true,
        columns: [
            { data: "Nome" },
            { data: "Quantidade" },
            { data: "Valor" },
            {
                render: function (data, type, row) {
                    return "\<button class = 'btn btn-primary botao-editar'\ data-id=" + row.Id + ">Editar</button>\
                    <button class = 'btn btn-danger botao-apagar'\ data-id="+ row.Id + ">Apagar</button>";
                }
            }
        ]
    })
});