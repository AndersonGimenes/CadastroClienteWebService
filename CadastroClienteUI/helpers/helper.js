function FormatarCPF(cpf) {
    const elementoAlvo = cpf;

    elementoAlvo.value = FormatarCpfBase(cpf.value); 
}   

async function BuscarDados(url){
    const response = await fetch(url);
    return response.json();
}

async function DeletarDados(url){
    await fetch(url, {
        method: 'DELETE',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        }
      });
}

async function RegistrarDados(url,verbo, obj){
    const response = await fetch(url, {
        method: verbo,
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body : JSON.stringify(
            {
                Id : obj.id == "" ? 0 : parseInt(obj.id),
                Nome : obj.nome,
                Sobrenome : obj.sobrenome,
                Cpf : FormatarCpfBase(obj.cpf),
                Nascimento : FormatarData(obj.nascimento),
                Profissao : parseInt(obj.profissao)
            }
        )
      });
    return response.json();
}

function FormatarData(data){
        dia = ("0" + data.getDate()).slice(-2).toString(),
        mes = ("0" + (data.getMonth()+1)).slice(-2).toString(),
        ano = data.getFullYear();
    return `${ano}-${mes}-${dia}`;
}

function FormatarCpfBase(cpf){
    cpfAtualizado = cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, 
     function( regex, argumento1, argumento2, argumento3, argumento4 ) {
            return `${argumento1}.${argumento2}.${argumento3}-${argumento4}`;
    })  
    return cpfAtualizado; 
}