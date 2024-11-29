import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Button.css'; 

const Button = ({ text, onClick }) => {
  const navigate = useNavigate();

  const handleClick = () => {
    if (onClick) {
      onClick(); 
    }
    navigate('/outra-pagina');
  };

  return (
    <button className="button" onClick={handleClick}>
      {text}
    </button>
  );
};

export default Button;
