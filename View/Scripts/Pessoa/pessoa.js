$(function () {

    $idAlterar = -1;

    $tabelaPessoa = $("#pessoa-tabela").DataTable({
        ajax: "http://localhost:52638/pessoa/ObterTodos",
        serverSide: true,
        columns: [
            { "data": "Id" },
            { "data": "Nome" },
            { "data": "CPF" },
            {
                render: function (data, type, row) {
                    return "<button class='btn btn-primary botao-editar' data-id = '" + row.Id + "'>Editar</button>\
<button class='btn btn-danger botao-apagar' data-id = '"+ row.Id + "'>Apagar\</button>";
                }
            }
        ]
    });

    $("#pessoa-botao-salvar").on("click", function () {
        $nome = $("#pessoa-campo-nome").val();
        $cpf = $("#pessoa-campo-cpf").val();

        if ($idAlterar == -1) {
            inserir($nome, $cpf);
        } else {
            alterar($nome, $cpf);
        }

    });

    function alterar($nome, $cpf) {
        $.ajax({
            url: "http://localhost:52638/Pessoa/update",
            method: "post",
            data: {
                id: $idAlterar,
                nome: $nome,
                cpf: $cpf
            },
            success: function (data) {
                $("#modal-pessoa").modal("hide");
                $idAlterar = -1;
                $tabelaPessoa.ajax.reload();
            },
            error: function (err) {
                alert("Não foi possivel alterar")
            }
        })
    }

    function inserir($nome, $cpf) {
        $.ajax({
            url: "http://localhost:52638/Pessoa/Inserir",
            method: "post",
            data: {
                nome: $nome,
                cpf: $cpf
            },
            success: function (data) {
                $("#modal-pessoa").modal('hide');
                $tabelaPessoa.ajax.reload();
            },
            error: function (err) {
                alert("deu ruim ")
            }

        })
    }

    $(".table").on("click", ".botao-apagar", function () {
        $idApagar = $(this).data("id");
        $.ajax({
            url: "http://localhost:52638/Pessoa/apagar?id=" + $idApagar,
            method: "get",
            success: function (data) { $tabelaPessoa.ajax.reload() },
            error: function (err) {
                alert("nao foi possivel apagar")
            }
        });
    });

    $(".table").on("click", ".botao-editar", function () {
        $idAlterar = $(this).data("id");

        $.ajax({
            url: "http://localhost:52638/Pessoa/obterpeloid?id=" + $idAlterar,
            method: "get",
            success: function (data) {
                $("#pessoa-campo-nome").val(data.Nome);//erro
                $("#pessoa-campo-cpf").val(data.CPF);
                $("#modal-pessoa").modal("show");
            },
            error: function (err) {
                alert ("na foi possivel carregar")
            }
        })
    })

});