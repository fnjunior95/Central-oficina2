import React, {useState} from "react";
import "../../pages/professor/Home.css"
import Title from "../../components/title/Title";
import Header from "../../components/header/Header";
import Input from "../../components/input/Input";
import Button from "../../components/button/Button";

const Cadastro = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    return (
        <div className="page">
            <Header title="LOGIN"/>
            <div className="content login">
                <Title text="CADASTRO" fontSize="3.5rem" margin="0px"/>
                <p className="text">Cadastre-se pra acessar a plataforma e registrar sua presença</p>
                <div className="inputs">
                    <p className="text no-width">Nome completo</p>
                    <Input
                    type="email"
                    placeholder="Digite seu nome"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    customStyle={{ marginBottom: '10px', padding: '10px', fontSize: '16px' }}
                    />
                    <p className="text no-width">Email</p>
                    <Input
                    type="email"
                    placeholder="Digite seu e-mail"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    customStyle={{ marginBottom: '10px', padding: '10px', fontSize: '16px' }}
                    />
                    <p className="text no-width">Senha</p>
                    <Input
                    type="password"
                    placeholder="Digite sua senha"
                    value={password}
                    onChange={(e) => setEmail(e.target.value)}
                    customStyle={{ marginBottom: '10px', padding: '10px', fontSize: '16px' }}
                    />
                </div>
                <Button text="ENTRAR"/>
            </div>
        </div>
    
    );
};

export default Cadastro;

