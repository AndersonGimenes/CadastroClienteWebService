var mainApp = angular.module('appCadastroCliente', []);

mainApp.controller('ClientesController', ['$timeout', '$scope', async function ($timeout, $scope) {

    const urlLocal = 'file:///D:/Projetos/CadastroClienteWebService/CadastroClienteUI/index.html';
    const url = 'https://localhost:44363/v1/api/Cliente';
    
    $scope.clientes = [];
    $scope.cliente = {
        id : '',
        nome : '', 
        sobrenome : '',
        cpf : '', 
        nascimento : '',
        profissao : ''
    }

    BuscarDados(url)
        .then(clientes => {
            clientes.forEach(d => $scope.clientes.push(new Cliente(d)))
        })
        .catch(erro => console.error(erro));
    
    await $timeout(() => 'timeout', 500);
    $scope.$apply();

    $scope.ObterDetalhes = function(id){
        const url = `https://localhost:44363/v1/api/Cliente/ObterPorId/${id}`;

        BuscarDados(url)
            .then(c => $scope.cliente = c)
            .catch(erro => console.error(erro));
    }

    $scope.Deletar = function(id){
        const url = `https://localhost:44363/v1/api/Cliente?id=${id}`;

        DeletarDados(url)
            .catch(erro => console.error(erro));

        setTimeout(function(){ window.location.href = urlLocal; }, 600);
    }

    $scope.Atualizar = function(id){
        const url = `https://localhost:44363/v1/api/Cliente/ObterPorId/${id}`;

        BuscarDados(url)
            .then(c => {
                $scope.cliente = c;
                $scope.cliente.nascimento = new Date(c.nascimento);
            })
            .catch(erro => console.error(erro));
    }

    $scope.RegistrarCliente = function(obj){
        var url = 'https://localhost:44363/v1/api/Cliente';
        var verbo = obj.id != 0 ? 'PUT' : 'POST';

        cliente = new Cliente(obj);

        RegistrarDados(url, verbo, cliente)
            .catch(erro => console.error(erro));

        setTimeout(function(){ window.location.href = urlLocal; }, 600);
    }
}]);