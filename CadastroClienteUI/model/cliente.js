class Cliente{
    constructor(obj){
        this._id = obj.id,
        this._nome = obj.nome,
        this._sobrenome = obj.sobrenome, 
        this._cpf = obj.cpf,
        this._nascimento = obj.nascimento,
        this._profissao = obj.profissao,
        this._idade = obj.idade
    }

    get id(){
        return this._id;
    }

    get nome(){
        return this._nome;
    }

    get sobrenome(){
        return this._sobrenome;
    }

    get cpf(){
        return this._cpf;
    }

    get nascimento(){
        return this._nascimento;
    }

    get profissao(){
        return this._profissao;
    }

    get idade(){
        return this._idade;
    }
}