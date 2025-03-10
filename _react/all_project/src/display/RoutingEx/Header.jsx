import React, { useState } from 'react';
import { Link, Outlet } from 'react-router-dom';

const Header = () => {
    const [users, setUsers] = useState([
        {
            id: 1,
            firstName: "John",
            lastName: "Doe",
            email: "john@example.fr",
            phone: "0123456789",
        },
        {
            id: 2,
            firstName: "Jane",
            lastName: "Dave",
            email: "dave@example.fr",
            phone: "0123456789",
        }
    ]);

    return (
        <>
            <header>
                <div className="container">
                    <div className="element">
                        <h1>Routing ex</h1>
                    </div>
                    <div className="element_row gap2">
                        <nav>
                            <ul className='element_row gap2'>
                                <Link to={"/"}>Home</Link>
                                <Link to={`/edit/${crypto.randomUUID()}?mode=create`}>Form</Link>
                            </ul>
                        </nav>
                    </div>
                </div>
            </header>
            <Outlet context={[users, setUsers]} />
        </>
    );
}

export default Header;