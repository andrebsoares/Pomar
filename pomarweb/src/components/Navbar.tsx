import React from 'react';

const Navbar = () => {
    return (
        <nav className="uk-navbar">
            <div className="uk-navbar-left">
                <a href="/" className="uk-navbar-item uk-logo"><span uk-icon="icon: home; ratio: 1.2"></span>Pomar Web</a>
            </div>
        </nav>
    );
};

export default Navbar;