import React from 'react';
import './Header.css';
import logo from '../../assets/images/logo.png';
import Title from '../title/Title';


const Header = ({ title }) => {
  return (
    <header className="header">
      <div className="header-logo">
      <img src={logo} alt="Logo" className="img-logo"/>
      </div>
      <Title text={title} fontSize="1.6rem" />
    </header>
  );
};

export default Header;
