import React from 'react';
import { Link, useOutletContext } from 'react-router-dom';

const Home = () => {
    const [users, setUsers] = useOutletContext();

    const usersDisplay = users.map((user) => {
        return (
            <li key={user.id}>
                <div className="element">
                    <p>{user?.firstName}</p>
                </div>
                <div className="element">
                    <p>{user?.lastName}</p>
                </div>
                <div className="element">
                    <p>{user?.phone}</p>
                </div>
                <div className="element">
                    <p>{user?.email}</p>
                </div>
                <div className="wrapper_row gap2">
                    <div className="element">
                        <Link className='btn btn_delete' to={`/edit/${user.id}?mode=delete`}>Delete</Link>
                    </div>
                    <div className="element">
                        <Link className='btn btn_edit' to={`/edit/${user.id}?mode=edit`}>Edit</Link>
                    </div>
                </div>
            </li>
        );
    });

    return (
        <>
            <section id="home">
                <div className="container">
                    <div className="wrapper">
                        <ul className="wrapper_column gap2">
                            {usersDisplay}
                        </ul>
                    </div>
                </div>
            </section>
        </>
    );
}

export default Home;