import React, {useState} from "react";
import Title from "../../components/title/Title";
import Header from "../../components/header/Header";
import Input from "../../components/input/Input";
import Button from "../../components/button/Button";
import ImageButton from "../../components/image-button/ImageButton";
import "../../pages/professor/Workshop.css"

const WorkshopCadastro = () => {
    const [name, setName] = useState('');
    const [selectedImage, setSelectedImage] = useState(null);

    const handleImageSelect = (image) => {
      setSelectedImage(image);
      console.log("Imagem selecionada:", image);
    };

    return(
        <div className="page">
        <Header title="SAIR"/>
        <div className="content">
          <Title text="NOVO WORKSHOP" fontSize="3.5rem" />
          <div className="inputs">
            <p className="text">Nome</p>
            <Input
            type="name"
            placeholder=""
            value={name}
            onChange={(e) => setName(e.target.value)}
            customStyle={{ marginBottom: '10px', padding: '10px', fontSize: '16px' }}
            />
            <p className="text">Descrição</p>
            <Input
            type="name"
            placeholder=""
            value={name}
            onChange={(e) => setName(e.target.value)}
            customStyle={{ marginBottom: '10px', padding: '10px', fontSize: '16px' }}
            />
            <p className="text">Ícone</p>
            <ImageButton/>
        </div>
        <Button text="Salvar"/>
        </div>
        </div>
    );
};

export default WorkshopCadastro;